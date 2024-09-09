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
        static public string ask(string question)
        {
            Console.Write(question + " ");
            return Console.ReadLine().ToLower();
        }

        // gameStart function to start the game, with the menu.
        static public bool gameStart()
        {
            Console.WriteLine("Druk op '1' om de game te starten, '2' om de instructies te lezen, '3' om af te sluiten");
            string userChoice = Console.ReadLine().ToLower();
            switch (userChoice)
            {
                case "1":
                    return true;

                case "2":
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

                case "3":
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

        static public string choosePath()
        {
            string userChoice = Helpers.ask("Maak een keuze om door te gaan: ");
            switch (userChoice)
            {
                case "1":
                    return "A";
                case "2":
                    return "B";
                case "3":
                    return "C";
                default:
                    Console.WriteLine("Geen geldige keuze!");
                    return choosePath();
            }
        }
    }
}
