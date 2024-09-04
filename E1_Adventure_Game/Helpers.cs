using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E1_Adventure_Game
{
    static public class Helpers
    {
        static public string Ask(string question)
        {
            Console.Write(question + " ");
            return Console.ReadLine().ToLower();
        }

        static public bool GameStart()
        {
            Console.WriteLine("Druk op '1' om de game te starten, '2' om de instructies te lezen, '3' om af te sluiten");
            string input = Console.ReadLine().ToLower();
            if (input == "1")
            {
                return true;
            }
            else if (input == "2")
            {
                Console.Clear();
                Console.WriteLine("\r\n██╗███╗░░██╗░██████╗████████╗██████╗░██╗░░░██╗░█████╗░████████╗██╗███████╗░██████╗\r\n██║████╗░██║██╔════╝╚══██╔══╝██╔══██╗██║░░░██║██╔══██╗╚══██╔══╝██║██╔════╝██╔════╝\r\n██║██╔██╗██║╚█████╗░░░░██║░░░██████╔╝██║░░░██║██║░░╚═╝░░░██║░░░██║█████╗░░╚█████╗░\r\n██║██║╚████║░╚═══██╗░░░██║░░░██╔══██╗██║░░░██║██║░░██╗░░░██║░░░██║██╔══╝░░░╚═══██╗\r\n██║██║░╚███║██████╔╝░░░██║░░░██║░░██║╚██████╔╝╚█████╔╝░░░██║░░░██║███████╗██████╔╝\r\n╚═╝╚═╝░░╚══╝╚═════╝░░░░╚═╝░░░╚═╝░░╚═╝░╚═════╝░░╚════╝░░░░╚═╝░░░╚═╝╚══════╝╚═════╝░");
                Console.WriteLine("");
                Console.WriteLine("Je krijgt zodra je de game start een aantal prompts waarin je het verhaal door loopt.");
                Console.WriteLine("Zodra je een keuze krijgt, kan je kiezen uit een aantal cijfers.");
                Console.WriteLine("Wat deze opties zijn en wat ze inhouden staat erbij.");
                Console.WriteLine("");
                Console.WriteLine("Dat waren alle instructies");
                Console.WriteLine("");
                return GameStart();
            }
            else if (input == "3")
            {
                return false;
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Geen geldige input!");
                Console.WriteLine("");
                return GameStart();
            }
        }
    }
}
