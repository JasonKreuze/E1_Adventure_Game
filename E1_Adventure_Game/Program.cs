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
            // Initialize a new instance of the Game class
            Game game = new Game();

            // Display the title screen using ASCII art
            Console.WriteLine("\r\n██████╗░░█████╗░░█████╗░██╗░░██╗██████╗░░█████╗░░█████╗░███╗░░░███╗░██████╗\r\n██╔══██╗██╔══██╗██╔══██╗██║░██╔╝██╔══██╗██╔══██╗██╔══██╗████╗░████║██╔════╝\r\n██████╦╝███████║██║░░╚═╝█████═╝░██████╔╝██║░░██║██║░░██║██╔████╔██║╚█████╗░\r\n██╔══██╗██╔══██║██║░░██╗██╔═██╗░██╔══██╗██║░░██║██║░░██║██║╚██╔╝██║░╚═══██╗\r\n██████╦╝██║░░██║╚█████╔╝██║░╚██╗██║░░██║╚█████╔╝╚█████╔╝██║░╚═╝░██║██████╔╝\r\n╚═════╝░╚═╝░░╚═╝░╚════╝░╚═╝░░╚═╝╚═╝░░╚═╝░╚════╝░░╚════╝░╚═╝░░░░░╚═╝╚═════╝░\r\n\r\n░█████╗░██████╗░██╗░░░██╗███████╗███╗░░██╗████████╗██╗░░░██╗██████╗░███████╗\r\n██╔══██╗██╔══██╗██║░░░██║██╔════╝████╗░██║╚══██╔══╝██║░░░██║██╔══██╗██╔════╝\r\n███████║██║░░██║╚██╗░██╔╝█████╗░░██╔██╗██║░░░██║░░░██║░░░██║██████╔╝█████╗░░\r\n██╔══██║██║░░██║░╚████╔╝░██╔══╝░░██║╚████║░░░██║░░░██║░░░██║██╔══██╗██╔══╝░░\r\n██║░░██║██████╔╝░░╚██╔╝░░███████╗██║░╚███║░░░██║░░░╚██████╔╝██║░░██║███████╗\r\n╚═╝░░╚═╝╚═════╝░░░░╚═╝░░░╚══════╝╚═╝░░╚══╝░░░╚═╝░░░░╚═════╝░╚═╝░░╚═╝╚══════╝");

            Console.WriteLine("");

            // Start the game by calling the gameStart method.
            // If the user chooses to start the game, load either a new game or a saved game.
            if (Helpers.gameStart())
            {
                Console.Clear();  // Clear the console screen for game start

                // Load either a new game or a save file.
                string newOrSave = Helpers.LoadSaveFile();

                // Display the initial scene based on the save file or new game.
                if (newOrSave == "1")
                {
                    SceneLoader.DisplayScene(newOrSave, game);  // Load the first scene if new game
                }
                else
                {
                    SceneLoader.DisplayScene(newOrSave, game);  // Load the scene from the save file
                }

                game.IsRunning = true;  // Set the game state to running
                int i = int.Parse(newOrSave[0].ToString());  // Extract the scene index from the save or new game start
                string currentScene = newOrSave;  // Store the current scene
                string sceneHint = "";  // Initialize a variable to hold scene hints

                // Main game loop that continues as long as the game is running.
                while (game.IsRunning)
                {
                    i++;  // Increment the scene index for the next scene
                    string path;
                    string newScene = "";

                    // Check if the game is still running to process the next scene.
                    if (game.IsRunning == true)
                    {
                        // Ask the player to choose a path in the game.
                        path = Helpers.ChoosePath(sceneHint);

                        // If the player chooses to exit, save the current scene.
                        if (path == "")
                        {
                            File.WriteAllText("../../../savegame.txt", currentScene.ToString());  // Save current progress
                        }

                        // Construct the new scene identifier based on the index and chosen path.
                        newScene = i.ToString() + path;
                    }

                    // Update the current scene and clear the console for the new scene display.
                    currentScene = newScene;
                    Console.Clear();

                    // Display the new scene and retrieve a hint for the next choice.
                    sceneHint = SceneLoader.DisplayScene(newScene, game);
                }
            }
        }
    }
}
