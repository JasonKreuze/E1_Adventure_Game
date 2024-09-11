using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E1_Adventure_Game
{
    static public class Helpers
    {
        // Prompts the user with a question and returns their input in lowercase.
        // This reduces redundant code by centralizing input gathering.
        static public string Ask(string question)
        {
            Console.Write(question + " ");
            return Console.ReadLine().ToLower();
        }

        // Starts the game and displays the main menu.
        // Based on the user's input, the function either starts the game, loads from a save, shows instructions, or exits.
        // Returns true to proceed with the game, false to exit.
        static public bool gameStart()
        {
            Console.WriteLine("Druk op '1' om de game te starten, '3' om de instructies te lezen, '4' om af te sluiten");
            string userChoice = Console.ReadLine().ToLower();
            switch (userChoice)
            {
                case "1":
                    return true;  // Starts a new game
                case "2":
                    return true;  // Loads from a saved game
                case "3":
                    // Shows game instructions and then returns to the menu
                    Console.Clear();
                    Console.WriteLine("\r\n██╗███╗░░██╗░██████╗████████╗██████╗░██╗░░░██╗░█████╗░████████╗██╗███████╗░██████╗\r\n██║████╗░██║██╔════╝╚══██╔══╝██╔══██╗██║░░░██║██╔══██╗╚══██╔══╝██║██╔════╝██╔════╝\r\n██║██╔██╗██║╚█████╗░░░░██║░░░██████╔╝██║░░░██║██║░░╚═╝░░░██║░░░██║█████╗░░╚█████╗░\r\n██║██║╚████║░╚═══██╗░░░██║░░░██╔══██╗██║░░░██║██║░░██╗░░░██║░░░██║██╔══╝░░░╚═══██╗\r\n██║██║░╚███║██████╔╝░░░██║░░░██║░░██║╚██████╔╝╚█████╔╝░░░██║░░░██║███████╗██████╔╝\r\n╚═╝╚═╝░░╚══╝╚═════╝░░░░╚═╝░░░╚═╝░░╚═╝░╚═════╝░░╚════╝░░░░╚═╝░░░╚═╝╚══════╝╚═════╝░");
                    Console.WriteLine("");
                    Console.WriteLine("Je krijgt zodra je de game start een aantal prompts waarin je het verhaal door loopt.");
                    Console.WriteLine("Zodra je een keuze krijgt, kan je kiezen uit een aantal cijfers.");
                    Console.WriteLine("Wat deze opties zijn en wat ze inhouden staat erbij.");
                    Console.WriteLine("");
                    Console.WriteLine("Dat waren alle instructies");
                    Console.WriteLine("");
                    return gameStart();  // Returns to the menu after showing instructions
                case "4":
                    return false;  // Exits the game
                default:
                    // Handles invalid input by re-displaying the menu
                    Console.Clear();
                    Console.WriteLine("Geen geldige input!");
                    Console.WriteLine("");
                    return gameStart();  // Retry if the input is invalid
            }
        }

        // Displays a "Game Finished" screen using ASCII art.
        static public void gameFinish()
        {
            Console.WriteLine("\r\n░██████╗░░█████╗░███╗░░░███╗███████╗  ███████╗███╗░░██╗██████╗░███████╗██████╗░\r\n██╔════╝░██╔══██╗████╗░████║██╔════╝  ██╔════╝████╗░██║██╔══██╗██╔════╝██╔══██╗\r\n██║░░██╗░███████║██╔████╔██║█████╗░░  █████╗░░██╔██╗██║██║░░██║█████╗░░██║░░██║\r\n██║░░╚██╗██╔══██║██║╚██╔╝██║██╔══╝░░  ██╔══╝░░██║╚████║██║░░██║██╔══╝░░██║░░██║\r\n╚██████╔╝██║░░██║██║░╚═╝░██║███████╗  ███████╗██║░╚███║██████╔╝███████╗██████╔╝\r\n░╚═════╝░╚═╝░░╚═╝╚═╝░░░░░╚═╝╚══════╝  ╚══════╝╚═╝░░╚══╝╚═════╝░╚══════╝╚═════╝░");
        }

        // Prompts the user to choose a path in the game, displaying available options and handling hints.
        // Continues until a valid option is chosen. Returns a string indicating the selected path.
        static public string ChoosePath(string hint)
        {
            string userChoice = Helpers.Ask("Indien je een hint wilt druk '4', om je doel te zien druk '5', om te stoppen druk 'x'. Maak een keuze om door te gaan: ");
            switch (userChoice)
            {
                case "1":
                    return "A";  // Path A
                case "2":
                    return "B";  // Path B
                case "3":
                    return "C";  // Path C
                case "4":
                    // Displays hint if available, otherwise informs the user there's no hint
                    if (string.IsNullOrEmpty(hint) || hint == "Geen hint beschikbaar")
                    {
                        Console.WriteLine("Er is momenteel geen hint beschikbaar!\n");
                    }
                    else
                    {
                        Console.WriteLine($"Je hint: {hint}\n");
                    }
                    return ChoosePath(hint);  // Re-prompts the user after showing the hint
                case "5":
                    // Displays the user's goal and re-prompts
                    Console.WriteLine("Je doel is om de backrooms te ontsnappen!\n");
                    return ChoosePath(hint);
                case "x":
                    return "";  // Exits the choice loop
                default:
                    // Handles invalid input and re-prompts the user
                    Console.WriteLine("Geen geldige keuze!");
                    return ChoosePath(hint);  // Retry if invalid input
            }
        }

        // Loads a saved game or starts a new one based on user input.
        // Returns the content of the saved file or a default starting point.
        static public string LoadSaveFile()
        {
            string newOrSave = Helpers.Ask("Wil je een save file laden of een nieuwe beginnen? Let op dat een nieuwe beginnen de oude save file zal overschrijven!\n1 voor save file, 2 voor nieuwe save file");
            if (newOrSave == "1")
            {
                // Loads save file if it exists, otherwise returns default starting point
                if (File.Exists("../../../savegame.txt"))
                {
                    if (!string.IsNullOrEmpty(File.ReadAllText("../../../savegame.txt")))
                    {
                        return File.ReadAllText("../../../savegame.txt");  // Return saved content
                    }
                    else
                    {
                        return "1";  // No save content, start new game
                    }
                }
                else
                {
                    return "1";  // No save file, start new game
                }
            }
            else if (newOrSave == "2")
            {
                return "1";  // Start new game
            }
            else
            {
                // Handles invalid input and re-prompts the user
                Console.WriteLine("Geen geldige input!");
                return LoadSaveFile();  // Retry on invalid input
            }
        }
    }
}