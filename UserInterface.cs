using System.Linq.Expressions;
using System.Net;
using System.Threading.Tasks;
using Controllers;
using System.Text.Json;

namespace DrinksMenu;

internal class UserInterface
{
   Controllers.DrinkInformation singleDrinkController = new();
   Controllers.CategoryRequest drinkCategoryController = new();
   Controllers.Drinks drinkTypeController = new();
   Controllers.DrinkInformation drinkInfoController = new();



   //show categories

   internal async Task MainMenu()
   {
      Console.WriteLine("User Interface main menu");

      //Shows the categories of Drinks in the API
      await categoryRequest();

      Console.WriteLine("Please make a selection using the categories above");

      //Gather string for using to search drinks



      string? categorySelectionStr = "";

      bool categorySelectionBool = false;
      do
      {

         categorySelectionStr = Console.ReadLine();

         if (categorySelectionStr?.Trim().ToLower() == "exit")
         {
            break; // Exit loop immediately
         }

         if (categorySelectionStr != null)
         {
            try
            {
               await drinksListRequest(categorySelectionStr);
               categorySelectionBool = true;
            }
            catch (ArgumentException) // Catches "no data found" cases
            {
               Console.WriteLine("\nPlease enter a valid category.");
               categorySelectionBool = false; // Retry input
            }
            catch (JsonException) // Catches JSON deserialization errors
            {
               Console.WriteLine("\nInvalid response format from API. Please try again.");
               categorySelectionBool = false; // Retry input
            }
            catch (HttpRequestException) // Catches API connection issues
            {
               Console.WriteLine("\nFailed to connect to API. Please check your internet and try again.");
               categorySelectionBool = false; // Retry input
            }
            catch (Exception ex) // Catches unexpected errors
            {
               Console.WriteLine($"\nAn unexpected error occurred: {ex.Message}");
               categorySelectionBool = false; // Retry input
            }

         }
         if (categorySelectionStr == "exit")
         {
            break;
         }

      } while (categorySelectionBool == false);


      //Gather int for choosing specific drink by Id

      Console.WriteLine("Please make a selection using the Drink Ids above");

      string? drinkSelectionStr = "";
      int drinkId = 0;
      bool drinkSelectionBool = false;
      do
      {
         bool VariableEntry = false;
         drinkSelectionStr = Console.ReadLine();
         if (drinkSelectionStr != null)
         {

            if (drinkSelectionStr?.Trim().ToLower() == "exit")
            {
               break; // Exit loop immediately
            }

            VariableEntry = int.TryParse(drinkSelectionStr, out drinkId);
            if (VariableEntry == true)
            {
               try
               {
                  await drinkIdRequest(drinkId);
                  drinkSelectionBool = true;
               }
               catch (ArgumentException) // Catches "no data found" cases
               {
                  Console.WriteLine("\nPlease enter a valid category.");
                  categorySelectionBool = false; // Retry input
               }
               catch (JsonException) // Catches JSON deserialization errors
               {
                  Console.WriteLine("\nInvalid response format from API. Please try again.");
                  categorySelectionBool = false; // Retry input
               }
               catch (HttpRequestException) // Catches API connection issues
               {
                  Console.WriteLine("\nFailed to connect to API. Please check your internet and try again.");
                  categorySelectionBool = false; // Retry input
               }
               catch (Exception ex) // Catches unexpected errors
               {
                  Console.WriteLine($"\nAn unexpected error occurred: {ex.Message}");
                  categorySelectionBool = false; // Retry input
               }

            }
            else
            {
               Console.WriteLine("\nPlease enter a valid drink Id.");
            }
         }
      } while (drinkSelectionBool == false);

      //Shows the drinks by category in the API
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

   private async Task drinkIdRequest(int drinkId)
   {
      await drinkInfoController.DrinkInfo(drinkId);
   }

}