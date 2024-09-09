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
        public class Scene
        {
            public string SceneText { get; set; }
            public string Hint { get; set; }
            public List<string> Choices { get; set; }

            public Scene(string sceneText, string hint, List<string> choices)
            {
                SceneText = sceneText;
                Hint = hint;
                Choices = choices;
            }
        }

        // Function to load scenes from a text file
        public static Scene LoadScenes(string scene)
        {
            string filePath = $"../../../scenes/scene{scene}.txt";

            try
            {
                // Get the specific scene content
                string content = File.ReadAllText(filePath).Trim();

                // Split scene content by lines
                string[] lines = content.Split('\n');

                // The first line is the hint
                string hint = lines[0].Trim();

                // The scene text is everything until the last 2 or 3 lines, which are choices
                int choiceStartIndex = lines.Length - 3;  // Assuming a maximum of 3 choices

                // Collect choices from the last 2 or 3 lines
                List<string> choices = new List<string>();
                for (int i = choiceStartIndex; i < lines.Length; i++)
                {
                    choices.Add(lines[i].Trim());
                }

                // The rest are the scene text lines
                string sceneText = string.Join("\n", lines, 1, choiceStartIndex - 1).Trim();

                return new Scene(sceneText, hint, choices);
            }
            catch (Exception ex)
            {
                Helpers.gameFinish();
                return null;
                //Console.WriteLine($"Error loading scenes: {ex.Message}");
            }
            return null;
        }
        
        public static void DisplayScene(string Scene, Game game)
        {
            SceneLoader.Scene scene = LoadScenes(Scene);
            if (scene == null)
            {
                game.IsRunning = false;
                return;
            }
            int i = 1;
            Console.Clear();

            Console.WriteLine($"{scene.SceneText}");
            if (scene.Hint != "NVT")
            {
                Console.WriteLine($"Hint: {scene.Hint}");
            } 
            Console.WriteLine();
            foreach (string choice in scene.Choices)
            {
                if (choice == "NVT")
                {
                    return;
                }

                Console.WriteLine(i + ". " + choice);
                i++;
            }
            Console.WriteLine();
        }
    }
}

