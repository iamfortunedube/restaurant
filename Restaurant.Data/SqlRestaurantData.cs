using System.Collections.Generic;
using Restaurant.BL;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Restaurant.Data
{
    public class SqlRestaurantData : IRestaurantData
    {
        private readonly AppDbContext dbContext;
        public SqlRestaurantData(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public Category AddCategory(Category newCategory)
        {
            dbContext.Add(newCategory);
            return newCategory;
        }

        public ShoppingCart AddItemToCart(ShoppingCart newCartItem)
        {
            dbContext.Add(newCartItem);
            return newCartItem;
        }

        public FoodItem AddFoodItem(FoodItem newFoodItem)
        {
            dbContext.Add(newFoodItem);
            return newFoodItem;
        }

        public int Commit()
        {
            return dbContext.SaveChanges();
        }

        public Category DeleteCategory(int Id)
        {
            var category = GetById(Id);
            if (category != null)
            {
                dbContext.Categories.Remove(category);
            }
            return category;
        }

        public FoodItem DeleteFoodItem(int Id)
        {
            var foodItem = GetFoodItemById(Id);
            if (foodItem != null)
            {
                dbContext.FoodItems.Remove(foodItem);
            }
            return foodItem;
        }

        public Category GetById(int Id)
        {
            return dbContext.Categories.Find(Id);
        }

        public IEnumerable<Category> GetCategoriesByName(string categoryName)
        {
            var query = from c in dbContext.Categories
                        where c.CategoryName.StartsWith(categoryName) || string.IsNullOrEmpty(categoryName)
                        orderby c.CategoryName
                        select c;
            return query;
        }

        public FoodItem GetFoodItemById(int Id)
        {
            return dbContext.FoodItems.Find(Id);
        }

        public IEnumerable<FoodItem> GetFoodItemByName(string foodItemName)
        {
            var query = from f in dbContext.FoodItems
                        where f.FoodItemName.StartsWith(foodItemName) || string.IsNullOrEmpty(foodItemName)
                        orderby f.FoodItemName
                        select f;
            return query;
        }
        public FoodItem GetFoodItemByCategory(int? categoryId)
        {
            return dbContext.FoodItems.SingleOrDefault(c=> c.CategoryId == categoryId);
        }

        public Category UpdateCategory(Category updatedCategory)
        {
            var entity = dbContext.Categories.Attach(updatedCategory);
            entity.State = EntityState.Modified;
            return updatedCategory;
        }

        public FoodItem UpdateFoodItem(FoodItem updatedFoodItem)
        {
            var entity = dbContext.FoodItems.Attach(updatedFoodItem);
            entity.State = EntityState.Modified;
            return updatedFoodItem;
        }

        List<FoodItem> IRestaurantData.GetFoodItemByCategory(int? categoryId)
        {
            var query = from f in dbContext.FoodItems where f.CategoryId == categoryId orderby f.FoodItemName select f;
            return query.ToList();
        }
    }
}