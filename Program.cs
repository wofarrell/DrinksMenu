using System.Net.Http.Headers;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Threading.Tasks;
using Controllers;

using DrinksMenu;

namespace Main;

internal class Program
{
    static async Task Main(string[] args)
    {

        //Console.Clear();
        UserInterface userInterface = new();
        await userInterface.MainMenu();
        


    }
}

