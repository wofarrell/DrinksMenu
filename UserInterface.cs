using System.Linq.Expressions;
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

      //Shows the categories of Drinks in the API
      await categoryRequest();

      Console.WriteLine("Please make a selection using the categories above");

      //Gather string for using to search drinks

      string drinkCat = "";

      string? categorySelectionStr = "";

      bool categorySelectionBool = false;
      do
      {
         
         categorySelectionStr = Console.ReadLine();
         if (categorySelectionStr != null)
         {
            try
            {
                drinkCat = categorySelectionStr;
               await drinksListRequest(drinkCat);
               categorySelectionBool = true;
            }
            catch (ArgumentException e)
            {
               Console.WriteLine("\nplease enter a valid category");
               categorySelectionBool = false;
            }
            
         }
         if (categorySelectionStr == "exit")
         {
            break;
         }

      } while (categorySelectionBool == false);


      //Gather int for choosing specific drink by Id
      string? drinkSelectionStr = "";
      int drinkSelectionInt = 0;
      bool drinkSelectionBool = false;
      do
      {
         bool VariableEntry = false;
         drinkSelectionStr = Console.ReadLine();
         if (drinkSelectionStr != null)
         {
            VariableEntry = int.TryParse(drinkSelectionStr, out drinkSelectionInt);
            Console.WriteLine($"Stack #{drinkSelectionInt} loaded");



            drinkSelectionBool = true;
         }
         if (drinkSelectionStr == "exit")
         {
            break;
         }
         if (!VariableEntry)
         {
            Console.WriteLine("\nplease enter a valid stack id");
         }
      } while (drinkSelectionBool == false);

      //Shows the drinks by category in the API
      await drinksListRequest(drinkCat);


      Console.WriteLine("Please make a selection using the drink Ids above");


      //Shows the drink information and instructions by Id
      string? drinkIdEntry = "";

      drinkIdEntry = Console.ReadLine();
      bool drinkIdbool = int.TryParse(drinkIdEntry, out int drinkId);

      Console.WriteLine("sent back to mainmenu exit");



   }

   private async Task categoryRequest()
   {

      await drinkCategoryController.DrinkCategories();


   }

   private async Task drinksListRequest(string drinkCat)
   {

      await drinkTypeController.DrinksinCategory(drinkCat);


   }



}