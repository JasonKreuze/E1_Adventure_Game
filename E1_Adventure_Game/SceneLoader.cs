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
            public bool IsEnd { get; set; }

            public Scene(string sceneText, string hint, List<string> choices, bool isEnd)
            {
                SceneText = sceneText;
                Hint = hint;
                Choices = choices;
                IsEnd = isEnd;
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

                // Check the "End: yes/no" line (assuming it's the last line)
                string endLine = lines[lines.Length - 1].Trim();
                bool isEnd = endLine.Equals("End: yes", StringComparison.OrdinalIgnoreCase);

                // The scene text is everything until the last 2 or 3 lines, which are choices
                int choiceStartIndex = lines.Length - 4;  // Assuming a maximum of 3 choices

                // Collect choices from the last 2 or 3 lines
                List<string> choices = new List<string>();
                for (int i = choiceStartIndex; i < lines.Length - 1; i++)
                {
                    choices.Add(lines[i].Trim());
                }

                // The rest are the scene text lines
                string sceneText = string.Join("\n", lines, 1, choiceStartIndex - 1).Trim();

                return new Scene(sceneText, hint, choices, isEnd);
            }
            catch (Exception ex)
            {
                Helpers.gameFinish();
                return null;
                //Console.WriteLine($"Error loading scenes: {ex.Message}");
            }
        }

        public static string DisplayScene(string Scene, Game game)
        {
            SceneLoader.Scene scene = LoadScenes(Scene);
            if (scene == null)
            {
                game.IsRunning = false;
                return "";
            }
            Console.WriteLine(scene.IsEnd);
            if (scene.IsEnd == true)
            {
                Helpers.gameFinish();
                game.IsRunning = false;
            }
            int i = 1;
            Console.Clear();

            Console.WriteLine($"{scene.SceneText}");
            Console.WriteLine();
            foreach (string choice in scene.Choices)
            {
                if (choice == "NVT")
                {
                    return "";
                }

                Console.WriteLine(i + ". " + choice);
                i++;
            }
            Console.WriteLine();
            if (scene.Hint != "NVT")
            {
                return scene.Hint;
            } else
            {
                return "Geen hint beschikbaar";
            }
        }
    }
}

