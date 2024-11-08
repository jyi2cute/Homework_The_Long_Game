using System;
using System.IO;

namespace HW_TheLongGame_Code
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Collected the username from the user and stored it in a variable
            Console.WriteLine("Enter your name: ");
            string username = Console.ReadLine();

            //Check for existing score file, Read from a file and store the username and score data into local variables
            string scoreFile = username + " .txt";
            int initialScore = 0;
            if (File.Exists(scoreFile))
            {
                try
                {
                    string scoreText = File.ReadAllText(scoreFile);
                    initialScore = int.Parse(scoreText);
                    Console.WriteLine($"Welcome back, {username}! Your previous score was {initialScore}.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error reading score file: {ex.Message}");
                }
            }

            int score = initialScore;
            Console.WriteLine("Press any key to start. Press Enter to end.");

            while (true)
            {
                ConsoleKeyInfo keyInfo = Console.ReadKey(true);

                //When the player presses enter end the game
                if (keyInfo.Key == ConsoleKey.Enter)
                {
                    break;
                }

                //Increase points when a keypress is made
                score++;
                //Display the updated score after each keypress
                Console.WriteLine("\nYour score: " + score);
            }

            //Save the final score, Save the username and score variable data out to a file
            File.WriteAllText(scoreFile, score.ToString());
            Console.WriteLine("\nGame over. Your final score is: " + score);
            Console.WriteLine("Your score has been saved to " + scoreFile);
        }
    }
}
