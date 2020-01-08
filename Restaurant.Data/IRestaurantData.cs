using Restaurant.BL;
using System.Collections.Generic;
using System.Text;

namespace Restaurant.Data
{
    public interface IRestaurantData
    {
        IEnumerable<Category> GetCategoriesByName(string categoryName);
        Category GetById(int Id);
        Category UpdateCategory(Category updatedCategory);
        Category AddCategory(Category newCategory);
        Category DeleteCategory(int Id);

        IEnumerable<FoodItem> GetFoodItemByName(string foodItemName);
        FoodItem GetFoodItemById(int Id);
        FoodItem UpdateFoodItem(FoodItem updatedFoodItem);
        FoodItem AddFoodItem(FoodItem newFoodItem);
        FoodItem DeleteFoodItem(int Id);
        int Commit();
    }
}
