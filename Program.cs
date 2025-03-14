using System.Net.Http.Headers;

internal class Program
{
    private static async Task Main(string[] args)
    {
        Console.WriteLine("Hello, World!");



        using HttpClient client = new();
        client.DefaultRequestHeaders.Accept.Clear();
        client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));
       // client.DefaultRequestHeaders.Add("User-Agent", "1");
        
        await ProcessRepositoriesAsync(client);

        static async Task ProcessRepositoriesAsync(HttpClient client)
        {
            var json = await client.GetStringAsync(
    "https://www.thecocktaildb.com/api/json/v1/1/search.php?s=margarita");

            Console.Write(json);
        }
    }
}