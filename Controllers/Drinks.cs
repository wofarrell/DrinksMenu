
using System.Net.Http.Headers;
using System.Text.Json;
using System.Text.Json.Nodes;

namespace Controllers;
internal class Drinks
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

        //working code to pull drink data by name
        async Task ProcessRepositoriesAsync(HttpClient client)
        {
            //gets json string from API
            jsonString = await client.GetStringAsync(
        "https://www.thecocktaildb.com/api/json/v1/1/search.php?s=margarita");

            //Console.Write(jsonString);
        }

        // Create a JsonNode DOM from a JSON string.
        JsonNode apiRequestNode = JsonNode.Parse(jsonString)!;

        //Create a node for specific value (in this case drink name)

        //gets Array from our API pull
        JsonNode drinksNode = apiRequestNode!["drinks"]!;
        //Console.WriteLine($"Type={drinksNode.GetType()}");
        //Console.WriteLine($"JSON={drinksNode.ToJsonString()}");

        JsonNode drinksNameNode = drinksNode[0]!;
        //Console.WriteLine($"Type={drinksNameNode.GetType()}");
        //Console.WriteLine($"JSON={drinksNameNode.ToJsonString()}");

        JsonNode drinksNameString = drinksNameNode["strDrink"]!;
        Console.WriteLine($"Type={drinksNameString.GetType()}");
        Console.WriteLine($"JSON={drinksNameString.ToJsonString()}");

        Console.WriteLine("chain under this line");
        string drinkNameChain = (string)apiRequestNode["drinks"]![0]!["strDrink"]!;
        Console.WriteLine($"drinks.0.strDrink={drinkNameChain}");
        //chaining references

        //Console.WriteLine($"Type={drinksNameNode.GetType()}");
        //Console.WriteLine($"JSON={drinksNameNode.ToJsonString()}");
        // Write JSON from a JsonNode
        //var options = new JsonSerializerOptions { WriteIndented = true };
        //Console.WriteLine(drinksNode!.ToJsonString(options));

    }

    public void DrinkInstructions()
    {

    }

}