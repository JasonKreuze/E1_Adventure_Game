using E1_Adventure_Game;

namespace AdventureGame
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Welkom bij de Backrooms Adventure game");
            if(Helpers.GameStart())
            {
                Console.Clear();
                string playerName = Helpers.Ask("Voer een naam in: ");
                Console.WriteLine("Context: Je was hopeloos aan het zoeken naar een baan en hebt gesolliciteerd bij een Jumbo en je bent aangenomen.");
                Console.WriteLine("Het is tijd voor je eerste dag maar je ziet dat je je verslapen hebt en er over 5 minuten al moet zijn!");
                Console.WriteLine("Je haast jezelf nog om op tijd te zijn en je haalt het nog net...");
                Console.WriteLine("");
                Helpers.Ask("Druk op enter om door te gaan...");
                Console.Clear();
                Console.Write("test");
                Console.WriteLine("test2");
            }
        }
    }
}

