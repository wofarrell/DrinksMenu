

using System.Net.Http.Headers;
using System.Text.Json;
using System.Text.Json.Nodes;

namespace Controllers;
internal class CategoryRequest
{

    private static async Task DrinksinCategory()
    {

        Console.WriteLine("JSON below!");

        string? jsonString = "";

        using HttpClient client = new();
        client.DefaultRequestHeaders.Accept.Clear();
        client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));
        // client.DefaultRequestHeaders.Add("User-Agent", "1");

        await ProcessRepositoriesAsync(client);

        async Task ProcessRepositoriesAsync(HttpClient client)
        {
            //gets json string from API
            jsonString = await client.GetStringAsync(
                "https://www.thecocktaildb.com/api/json/v1/1/list.php?c=list");

            Console.Write(jsonString);
        }

        // get list of categories https://www.thecocktaildb.com/api/json/v1/1/list.php?c=list
        // filter by cocktail /filter.php?c=Cocktail
    }
}
