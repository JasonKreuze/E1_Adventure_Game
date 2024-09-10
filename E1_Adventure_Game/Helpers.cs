using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E1_Adventure_Game
{
    static public class Helpers
    {
        // ask function to ask a question and get a response to reduce lines in the future
        static public string Ask(string question)
        {
            Console.Write(question + " ");
            return Console.ReadLine().ToLower();
        }

        // gameStart function to start the game, with the menu.
        static public bool gameStart()
        {
            Console.WriteLine("Druk op '1' om de game te starten, '2' om te starten vanaf een savefile, '3' om de instructies te lezen, '4' om af te sluiten");
            string userChoice = Console.ReadLine().ToLower();
            switch (userChoice)
            {
                case "1":
                    return true;

                case "2":
                    return true;
                case "3":
                    Console.Clear();
                    Console.WriteLine("\r\n██╗███╗░░██╗░██████╗████████╗██████╗░██╗░░░██╗░█████╗░████████╗██╗███████╗░██████╗\r\n██║████╗░██║██╔════╝╚══██╔══╝██╔══██╗██║░░░██║██╔══██╗╚══██╔══╝██║██╔════╝██╔════╝\r\n██║██╔██╗██║╚█████╗░░░░██║░░░██████╔╝██║░░░██║██║░░╚═╝░░░██║░░░██║█████╗░░╚█████╗░\r\n██║██║╚████║░╚═══██╗░░░██║░░░██╔══██╗██║░░░██║██║░░██╗░░░██║░░░██║██╔══╝░░░╚═══██╗\r\n██║██║░╚███║██████╔╝░░░██║░░░██║░░██║╚██████╔╝╚█████╔╝░░░██║░░░██║███████╗██████╔╝\r\n╚═╝╚═╝░░╚══╝╚═════╝░░░░╚═╝░░░╚═╝░░╚═╝░╚═════╝░░╚════╝░░░░╚═╝░░░╚═╝╚══════╝╚═════╝░");
                    Console.WriteLine("");
                    Console.WriteLine("Je krijgt zodra je de game start een aantal prompts waarin je het verhaal door loopt.");
                    Console.WriteLine("Zodra je een keuze krijgt, kan je kiezen uit een aantal cijfers.");
                    Console.WriteLine("Wat deze opties zijn en wat ze inhouden staat erbij.");
                    Console.WriteLine("");
                    Console.WriteLine("Dat waren alle instructies");
                    Console.WriteLine("");
                    return gameStart();

                case "4":
                    return false;

                default:
                    Console.Clear();
                    Console.WriteLine("Geen geldige input!");
                    Console.WriteLine("");
                    return gameStart();
            }
        }
        
        // Game Finished Screen.
        // TODO: Implement ending.
        static public void gameFinish()
        {
            Console.WriteLine("\r\n░██████╗░░█████╗░███╗░░░███╗███████╗  ███████╗██╗███╗░░██╗██╗░██████╗██╗░░██╗███████╗██████╗░\r\n██╔════╝░██╔══██╗████╗░████║██╔════╝  ██╔════╝██║████╗░██║██║██╔════╝██║░░██║██╔════╝██╔══██╗\r\n██║░░██╗░███████║██╔████╔██║█████╗░░  █████╗░░██║██╔██╗██║██║╚█████╗░███████║█████╗░░██║░░██║\r\n██║░░╚██╗██╔══██║██║╚██╔╝██║██╔══╝░░  ██╔══╝░░██║██║╚████║██║░╚═══██╗██╔══██║██╔══╝░░██║░░██║\r\n╚██████╔╝██║░░██║██║░╚═╝░██║███████╗  ██║░░░░░██║██║░╚███║██║██████╔╝██║░░██║███████╗██████╔╝\r\n░╚═════╝░╚═╝░░╚═╝╚═╝░░░░░╚═╝╚══════╝  ╚═╝░░░░░╚═╝╚═╝░░╚══╝╚═╝╚═════╝░╚═╝░░╚═╝╚══════╝╚═════╝░");
        }

        static public string ChoosePath(string hint)
        {
            string userChoice = Helpers.Ask("Of druk 'x' om te stoppen. Maak een keuze om door te gaan: ");
            switch (userChoice)
            {
                case "1":
                    return "A";
                case "2":
                    return "B";
                case "3":
                    return "C";
                case "4":
                    if (hint == "")
                    {
                        Console.WriteLine("Er is momenteel geen hint beschikbaar!");
                    } else if (hint == "Geen hint beschikbaar")
                    {
                        Console.WriteLine("Er is momenteel geen hint beschikbaar!");
                    } else
                    {
                        Console.WriteLine($"Je hint: {hint}\n");
                    }
                    return ChoosePath(hint);
                case "x":
                    return "";
                default:
                    Console.WriteLine("Geen geldige keuze!");
                    return ChoosePath(hint);
            }
        }

        static public string LoadSaveFile()
        {
            string newOrSave = Helpers.Ask("Wil je een save file laden of een nieuwe beginnen? Let op dat een nieuwe beginnen de oude save file zal overschrijven!\n1 voor save file, 2 voor nieuwe save file");
            if (newOrSave == "1")
            {
                if (File.Exists("../../../savegame.txt"))
                {
                    if (!string.IsNullOrEmpty(File.ReadAllText("../../../savegame.txt")))
                    {
                        return File.ReadAllText("../../../savegame.txt");
                    } else
                    {
                        return "1";
                    }
                } else
                {
                    return "1";
                }
            }
            else if (newOrSave == "2")
            {
                return "1";
            }
            else
            {
                Console.WriteLine("Geen geldige input!");
                return LoadSaveFile();
            }
        }
    }
}
