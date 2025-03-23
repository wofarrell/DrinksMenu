
using System.Net.Http.Headers;
using System.Text.Json;
using System.Text.Json.Nodes;
using Models.DrinksFiltered;
namespace Controllers;
internal class Drinks
{

    public async Task DrinksinCategory(string drinkCat)
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
            await using Stream stream =
                await client.GetStreamAsync($"https://www.thecocktaildb.com/api/json/v1/1/filter.php?c={drinkCat}");
            FilteredDrinkList? filteredByCat =
                await JsonSerializer.DeserializeAsync<FilteredDrinkList>(stream);

            if (filteredByCat?.drinks == null)
            {
                throw new ArgumentException("Invalid category.");
            }

            if (filteredByCat?.drinks != null)
            {
                foreach (var category in filteredByCat.drinks)
                {
                    int dynLine = 32; //category.strCategory.Length;
                    string Line1 = new string('-', dynLine);
                    int dynEndChar = dynLine - category.strDrink.Length - 4;
                    int dynEndChar2 = dynLine - category.idDrink.Length - 4;
                    string EndLine2 = new string(' ', dynEndChar2);
                    string EndLine = new string(' ', dynEndChar);
                    Console.WriteLine(Line1);
                    Console.WriteLine($"| {category.strDrink} {EndLine}|");
                    Console.WriteLine($"| {category.idDrink} {EndLine2}|");
                    string Line2 = new string('-', dynLine);
                }

            }
            Console.WriteLine(new string('-', 32));
        }

    }


}