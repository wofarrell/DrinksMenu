

using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using Models.CategoryNames;
using Models.DrinkArray;

namespace Controllers;
public class CategoryRequest
{

    public async Task DrinksinCategory()
    {

        Console.WriteLine("JSON below!");

        //string? jsonString = "";

        using HttpClient client = new();
        client.DefaultRequestHeaders.Accept.Clear();
        client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));
        // client.DefaultRequestHeaders.Add("User-Agent", "1");


        await ProcessCategoriesAsync(client);
        //await ProcessRepositoriesAsync(client);

        async Task ProcessCategoriesAsync(HttpClient client)
        {
            await using Stream stream =
                await client.GetStreamAsync("https://www.thecocktaildb.com/api/json/v1/1/list.php?c=list");
            CatList? categoryData =
                await JsonSerializer.DeserializeAsync<CatList>(stream);

            if (categoryData?.drinks != null)
            {
            foreach (var category in categoryData.drinks)
            {
                Console.WriteLine(category.strCategory);
            }
            }

        }
        /*
                async Task ProcessRepositoriesAsync(HttpClient client)
                {
                    //gets json string from API
                    jsonString = await client.GetStringAsync(
                        "https://www.thecocktaildb.com/api/json/v1/1/list.php?c=list");

                    Console.Write(jsonString);

                }
        */

        /*        
                JsonNode apiRequestNode = JsonNode.Parse(jsonString)!;
                JsonNode drinksNode = (string)apiRequestNode!["drinks"]!["strCategory"]!;

                Console.WriteLine($"JSON={drinksNode}");
                //string returnedString = drinksNode.ToJsonString();
                //return returnedString;
                //Console.WriteLine($"Type={drinksNode.GetType()}");
                //Console.WriteLine($"JSON={drinksNode.ToJsonString()}");
          */


        // get list of categories https://www.thecocktaildb.com/api/json/v1/1/list.php?c=list
        // filter by cocktail /filter.php?c=Cocktail
    }
}
