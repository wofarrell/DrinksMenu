using System.Net;
using System.Threading.Tasks;
using Controllers;

namespace DrinksMenu;

internal class UserInterface
{
    Controllers.DrinkInformation singleDrinkController = new();
    Controllers.CategoryRequest drinkCategoryController = new();
    Controllers.Drinks drinkTypeController = new();

   

    //show categories

    internal async Task MainMenu()
    {
    Console.WriteLine("User Interface main menu");
       await categoryRequest();
       Console.WriteLine("sent back to mainmenu exit");



    }
    
    private async Task categoryRequest()
    {

       await drinkCategoryController.DrinksinCategory();
        
        
    }
    
}