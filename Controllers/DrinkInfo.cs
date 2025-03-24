using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;
using Models.DrinksFiltered;


namespace Controllers;
internal class DrinkInformation
{
    public async Task DrinkInfo(int idDrink)
    {

        using HttpClient client = new();
        client.DefaultRequestHeaders.Accept.Clear();
        client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));
        // client.DefaultRequestHeaders.Add("User-Agent", "1");

        await ProcessRepositoriesAsync(client);

        //working code to pull drink data by name
        async Task ProcessRepositoriesAsync(HttpClient client)
        {
            string? jsonString =
                await client.GetStringAsync($"https://www.thecocktaildb.com/api/json/v1/1/lookup.php?i={idDrink}");

            JsonNode apiRequestNode = JsonNode.Parse(jsonString)!;

            if (apiRequestNode == null || apiRequestNode["drinks"] == null)
            {
                throw new ArgumentException("No drink found with that drinkId.\nEnter a valid drinkId");
            }

            JsonNode? drinkNode = apiRequestNode["drinks"]?[0]; // Get the first drink

            if (drinkNode == null)
            {
                throw new ArgumentException("No drink found with that drinkId.\nEnter a valid drinkId");
            }

            // under JsonNode drinkNode, a sample of the structure is as below:
            // You can pull the value through a JsonNode by using brackets and the key name, such as drinkNode[strDrink]. that pulls the name. 
            // PrintIfNotNull() method below pulls that value for the key, then only writes if isn't null.
            /*
                {
                    "idDrink": "14378",
                    "strDrink": "Lunch Box",
                    "strDrinkAlternate": null
                } 
            */

            Console.WriteLine(new string('-', 32));
            Console.WriteLine(new string('=', 32));

            Console.WriteLine("Overview:");

            Console.WriteLine(new string('-', 32));
            PrintIfNotNull(drinkNode, "idDrink", "ID");
            PrintIfNotNull(drinkNode, "strDrink", "Name");
            PrintIfNotNull(drinkNode, "strCategory", "Category");
            PrintIfNotNull(drinkNode, "strGlass", "Glass Type");
            PrintIfNotNull(drinkNode, "strAlcoholic", "Alcoholic");
            Console.WriteLine(new string('=', 32));

            Console.WriteLine("Instructions:");
            Console.WriteLine(new string('-', 32));
            PrintIfNotNull(drinkNode, "strInstructions", "Steps");
            Console.WriteLine(new string('=', 32));

            Console.WriteLine("Ingredients:");
            Console.WriteLine(new string('-', 32));

            // ✅ Dynamically print only non-null ingredients
            for (int i = 1; i <= 15; i++)
            {
                string ingredientKey = $"strIngredient{i}";
                if (drinkNode[ingredientKey] != null)
                {
                    Console.WriteLine($"- {drinkNode[ingredientKey]!.ToString()}");
                }
            }

            Console.WriteLine(new string('=', 32));

            Console.WriteLine("Measurements:");
            Console.WriteLine(new string('-', 32));

            for (int i = 1; i <= 15; i++)
            {
                string measureKey = $"strMeasure{i}";
                if (drinkNode[measureKey] != null)
                {
                    Console.WriteLine($"- {drinkNode[measureKey]!.ToString()}");
                }
            }

            //var options = new JsonSerializerOptions { WriteIndented = true, DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull };
            //Console.WriteLine(apiRequestNode!.ToJsonString(options));
            //JsonNode drinksNode = apiRequestNode!["drinks"]!;
            Console.WriteLine(new string('-', 32));
        }
    }



    void PrintIfNotNull(JsonNode node, string jsonKeyValue, string displayName)
    {
        if (node[jsonKeyValue] != null)
        {
            Console.WriteLine($"{displayName}: {node[jsonKeyValue]!.ToString()}");
        }
    }

}




