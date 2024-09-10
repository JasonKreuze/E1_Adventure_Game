using E1_Adventure_Game;
using System.Security.Cryptography.X509Certificates;
using System.Timers;
using static E1_Adventure_Game.SceneLoader;

namespace AdventureGame
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Game game = new Game();
            Console.WriteLine("\r\n██████╗░░█████╗░░█████╗░██╗░░██╗██████╗░░█████╗░░█████╗░███╗░░░███╗░██████╗\r\n██╔══██╗██╔══██╗██╔══██╗██║░██╔╝██╔══██╗██╔══██╗██╔══██╗████╗░████║██╔════╝\r\n██████╦╝███████║██║░░╚═╝█████═╝░██████╔╝██║░░██║██║░░██║██╔████╔██║╚█████╗░\r\n██╔══██╗██╔══██║██║░░██╗██╔═██╗░██╔══██╗██║░░██║██║░░██║██║╚██╔╝██║░╚═══██╗\r\n██████╦╝██║░░██║╚█████╔╝██║░╚██╗██║░░██║╚█████╔╝╚█████╔╝██║░╚═╝░██║██████╔╝\r\n╚═════╝░╚═╝░░╚═╝░╚════╝░╚═╝░░╚═╝╚═╝░░╚═╝░╚════╝░░╚════╝░╚═╝░░░░░╚═╝╚═════╝░\r\n\r\n░█████╗░██████╗░██╗░░░██╗███████╗███╗░░██╗████████╗██╗░░░██╗██████╗░███████╗\r\n██╔══██╗██╔══██╗██║░░░██║██╔════╝████╗░██║╚══██╔══╝██║░░░██║██╔══██╗██╔════╝\r\n███████║██║░░██║╚██╗░██╔╝█████╗░░██╔██╗██║░░░██║░░░██║░░░██║██████╔╝█████╗░░\r\n██╔══██║██║░░██║░╚████╔╝░██╔══╝░░██║╚████║░░░██║░░░██║░░░██║██╔══██╗██╔══╝░░\r\n██║░░██║██████╔╝░░╚██╔╝░░███████╗██║░╚███║░░░██║░░░╚██████╔╝██║░░██║███████╗\r\n╚═╝░░╚═╝╚═════╝░░░░╚═╝░░░╚══════╝╚═╝░░╚══╝░░░╚═╝░░░░╚═════╝░╚═╝░░╚═╝╚══════╝");
            Console.WriteLine("");
            if(Helpers.gameStart())
            {
                Console.Clear();
                string newOrSave = Helpers.LoadSaveFile();
                if (newOrSave == "1")
                {
                    SceneLoader.DisplayScene(newOrSave, game);
                } else
                {
                    SceneLoader.DisplayScene(newOrSave, game);
                }
                game.IsRunning = true;
                int i = int.Parse(newOrSave[0].ToString());
                Console.WriteLine(i);
                string currentScene = newOrSave;
                string sceneHint = "";
                while (game.IsRunning)
                {
                    i++;
                    string path;
                    string newScene = "";
                    if (game.IsRunning == true)
                    {
                        path = Helpers.ChoosePath(sceneHint);
                        if (path == "")
                        {
                            File.WriteAllText("../../../savegame.txt", currentScene.ToString());
                        }
                        newScene = i.ToString() + path;
                    }
                    currentScene = newScene;
                    Console.Clear();
                    sceneHint = SceneLoader.DisplayScene(newScene, game);

                }
            }
        }
    }
}
