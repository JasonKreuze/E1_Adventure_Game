using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace E1_Adventure_Game
{
    class SceneLoader
    {
        // Scene class represents a single scene with its text, hint, choices, and an indicator if it's the end of the game.
        public class Scene
        {
            public string SceneText { get; set; }    // The narrative text of the scene
            public string Hint { get; set; }         // The hint for the scene, if available
            public List<string> Choices { get; set; }  // List of possible choices in the scene
            public bool IsEnd { get; set; }          // Boolean flag to indicate if the scene is the final one

            // Constructor for initializing the Scene object with text, hint, choices, and end status
            public Scene(string sceneText, string hint, List<string> choices, bool isEnd)
            {
                SceneText = sceneText;
                Hint = hint;
                Choices = choices;
                IsEnd = isEnd;
            }
        }

        // Function to load scenes from a text file based on the scene identifier passed as an argument
        public static Scene LoadScenes(string scene)
        {
            // Define the path to the scene file using the provided scene identifier
            string filePath = $"../../../scenes/scene{scene}.txt";

            try
            {
                // Read all text from the scene file and trim any extra spaces
                string content = File.ReadAllText(filePath).Trim();

                // Split the content of the scene file into individual lines
                string[] lines = content.Split('\n');

                // The first line of the file is assumed to contain the hint for the scene
                string hint = lines[0].Trim();

                // The last line indicates if the scene is the end of the game (End: yes/no)
                string endLine = lines[lines.Length - 1].Trim();
                bool isEnd = endLine.Equals("End: yes", StringComparison.OrdinalIgnoreCase);

                // Determine the index where the choices begin (assumes the last 2 or 3 lines are choices)
                int choiceStartIndex = lines.Length - 4;  // Assuming a maximum of 3 choices

                // Collect the choices from the last lines of the file, excluding the "End" line
                List<string> choices = new List<string>();
                for (int i = choiceStartIndex; i < lines.Length - 1; i++)
                {
                    choices.Add(lines[i].Trim());
                }

                // The scene text is everything from the second line until the choice lines start
                string sceneText = string.Join("\n", lines, 1, choiceStartIndex - 1).Trim();

                // Return the constructed Scene object with text, hint, choices, and end status
                return new Scene(sceneText, hint, choices, isEnd);
            }
            catch (Exception ex)
            {
                // If there is an error loading the scene, show the game finish screen and return null
                Helpers.gameFinish();
                return null;
            }
        }

        // Function to display the scene in the game and return any hint for the player
        public static string DisplayScene(string Scene, Game game)
        {
            // Load the scene data from the file using the scene identifier
            SceneLoader.Scene scene = LoadScenes(Scene);

            // If the scene is null (e.g., due to loading error), stop the game
            if (scene == null)
            {
                game.IsRunning = false;
                return "";
            }

            // If this is the end scene, display the game finish screen and stop the game
            Console.WriteLine(scene.IsEnd);
            if (scene.IsEnd == true)
            {
                Helpers.gameFinish();
                game.IsRunning = false;
            }

            // Clear the console for the new scene display
            int i = 1;
            Console.Clear();

            // Display the scene's narrative text
            Console.WriteLine($"{scene.SceneText}");
            Console.WriteLine();

            // Loop through each choice in the scene and display it
            foreach (string choice in scene.Choices)
            {
                // If "NVT" is encountered, it means there are no valid choices, so return
                if (choice == "NVT")
                {
                    return "";
                }

                // Display the available choices with their corresponding numbers
                Console.WriteLine(i + ". " + choice);
                i++;
            }

            Console.WriteLine();

            // Return the hint if it's available, otherwise indicate that no hint is available
            if (scene.Hint != "NVT")
            {
                return scene.Hint;
            }
            else
            {
                return "Geen hint beschikbaar";  // Return "No hint available" if "NVT" is the hint
            }
        }
    }
}
