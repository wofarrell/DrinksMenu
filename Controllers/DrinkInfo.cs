using System.Net.Http.Headers;
using System.Text.Json;
using System.Text.Json.Nodes;

namespace Controllers;
internal class DrinkInformation
{
      private static async Task DrinkInfo()
    {
        Console.WriteLine("JSON below!");

        string? jsonString = "";
        string? drinkIdEntry = "";
        
        drinkIdEntry = Console.ReadLine();
        bool drinkIdbool = int.TryParse(drinkIdEntry, out int drinkId);

        

        using HttpClient client = new();
        client.DefaultRequestHeaders.Accept.Clear();
        client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));
        // client.DefaultRequestHeaders.Add("User-Agent", "1");

        await ProcessRepositoriesAsync(client);

        //working code to pull drink data by name
        async Task ProcessRepositoriesAsync(HttpClient client)
        {
            //gets json string from API
            jsonString = await client.GetStringAsync(
        $"https://www.thecocktaildb.com/api/json/v1/1/search.php?i={drinkId}");

            //Console.Write(jsonString);
        }

        // Create a JsonNode DOM from a JSON string.
        JsonNode apiRequestNode = JsonNode.Parse(jsonString)!;

        
    }
}