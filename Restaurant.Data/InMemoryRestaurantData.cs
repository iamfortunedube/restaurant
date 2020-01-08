using Restaurant.BL;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Restaurant.Data
{
    public class InMemoryRestaurantData : IRestaurantData
    {
        List<Category> categories;
        List<FoodItem> foodItems;
        public InMemoryRestaurantData()
        {
            categories = new List<Category>()
            {
                new Category{ Id = 1, CategoryName = "Breakfast", SellingTime = "07am to 11am"},
                new Category{ Id = 2, CategoryName = "CurryBar", SellingTime = "Anytime"},
                new Category{ Id = 3, CategoryName = "ToastedSandwiches", SellingTime = "Anytime"},
                new Category{ Id = 4, CategoryName = "Salads", SellingTime = "Anytime"},
                new Category{ Id = 5, CategoryName = "Specialities", SellingTime = "Anytime"},
                new Category{ Id = 6, CategoryName = "Extras", SellingTime = "Anytime"},
                new Category{ Id = 7, CategoryName = "Gourment Burgers", SellingTime = "Anytime"},
                new Category{ Id = 8, CategoryName = "On the sweet side", SellingTime = "Anytime"},
                new Category{ Id = 9, CategoryName = "On the go meals", SellingTime = "Anytime"}
            };

            foodItems = new List<FoodItem>()
            {
                new FoodItem{Id= 100, FoodItemName = "Omelets", Description = "Fillings", GetCategory = "Breakfast", Price = 55 },
                new FoodItem{Id= 101, FoodItemName = "Indaba Breakfast", Description = "Rasher of bacon", GetCategory = "Breakfast", Price = 47 },
                new FoodItem{Id= 102, FoodItemName = "Lamb Curry Sandwitch", Description = "", GetCategory = "Curry bar", Price = 45 },
                new FoodItem{Id= 103, FoodItemName = "Chicken Curry Sandwitch", Description = "", GetCategory = "Curry bar", Price = 35 },
                new FoodItem{Id= 104, FoodItemName = "Cheese", Description = "Cheedar or mozzarella", GetCategory = "Toasted Sandwitches", Price = 28 }
            };
        }

        //Retrieve categories using category id
        public Category GetById(int Id)
        {
            return categories.SingleOrDefault(c => c.Id == Id);
        }

        //Adding new category
        public Category AddCategory(Category newCategory)
        {
            categories.Add(newCategory);
            newCategory.Id = categories.Max(c => c.Id) + 1;
            return newCategory;
        }

        //Updating existing category
        public Category UpdateCategory(Category updatedCategory)
        {
            var category = categories.SingleOrDefault(c => c.Id == updatedCategory.Id);
            if (category != null)
            {
                category.CategoryName = updatedCategory.CategoryName;
                category.SellingTime = updatedCategory.SellingTime;
            }
            return category;
        }

        public IEnumerable<Category> GetCategoriesByName(string categoryName =null)
        {
            return from c in categories
                   where string.IsNullOrEmpty(categoryName)||c.CategoryName.StartsWith(categoryName, StringComparison.OrdinalIgnoreCase)
                   orderby c.CategoryName
                   select c;
        }
        public Category DeleteCategory(int id)
        {
            var category = categories.FirstOrDefault(r => r.Id == id);
            if (category != null)
            {
                categories.Remove(category);
            }
            return category;
        }

        public FoodItem GetFoodItemById(int Id)
        {
            return foodItems.SingleOrDefault(c => c.Id == Id);
        }

        public FoodItem AddFoodItem(FoodItem newFoodItem)
        {
            foodItems.Add(newFoodItem);
            newFoodItem.Id = foodItems.Max(c => c.Id) + 1;
            return newFoodItem;
        }

        public FoodItem UpdateFoodItem(FoodItem updatedFoodItem)
        {
            var foodItem = foodItems.SingleOrDefault(c => c.Id == updatedFoodItem.Id);
            if (foodItem != null)
            {
                foodItem.FoodItemName = updatedFoodItem.FoodItemName;
                foodItem.Description = updatedFoodItem.Description;
                foodItem.GetCategory = updatedFoodItem.GetCategory;
                foodItem.Price = updatedFoodItem.Price;
            }
            return foodItem;
        }

        public IEnumerable<FoodItem> GetFoodItemByName(string foodItemName = null)
        {
            return from c in foodItems
                   where string.IsNullOrEmpty(foodItemName) || c.FoodItemName.StartsWith(foodItemName, StringComparison.OrdinalIgnoreCase)
                   orderby c.FoodItemName
                   select c;
        }

        public FoodItem DeleteFoodItem(int id)
        {
            var foodItem = foodItems.FirstOrDefault(r => r.Id == id);
            if (foodItem != null)
            {
                foodItems.Remove(foodItem);
            }
            return foodItem;
        }
        public int Commit()
        {
            return 0;
        }
    }
}
