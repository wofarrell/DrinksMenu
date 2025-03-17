using System.Net.Http.Headers;
using System.Text.Json;
using System.Text.Json.Nodes;
using Controllers;

using DrinksMenu;

namespace Main;

internal class Program
{
    static void Main(string[] args)
    {

        //Console.Clear();
        UserInterface userInterface = new();
        userInterface.MainMenu();



    }
}

