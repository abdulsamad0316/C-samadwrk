using System;
using System.Collections.Generic;
using System.Threading;

namespace CarGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            int playfieldWidth = 30;
            int score = 0;
            int speed = 150;
            bool gameOver = false;

            // representation
            int carPosition = playfieldWidth / 2;
             char carSymbol = 'A';

            // Obstacles
            List<(int X, int Y)> obstacles = new List<(int X, int Y)>();
            Random random = new Random();

            // Draw borders
            for (int i = 0; i < Console.WindowHeight; i++)
            {
                Console.SetCursorPosition(0, i);
                Console.Write("|");
                Console.SetCursorPosition(playfieldWidth, i);
                Console.Write("|");
            }

            while (!gameOver)
            {
                // Input handling
                if (Console.KeyAvailable)
                {
                    var key = Console.ReadKey(true).Key;
                    if (key == ConsoleKey.LeftArrow && carPosition > 1)
                        carPosition--;
                    else if (key == ConsoleKey.RightArrow && carPosition < playfieldWidth - 1)
                        carPosition++;
                }

                // Generate obstacles
                if (random.Next(0, 10) < 2)
                {
                    obstacles.Add((random.Next(1, playfieldWidth - 1), 0));
                }

                // Clear previous frame
                Console.Clear();

                // Draw borders
                for (int i = 0; i < Console.WindowHeight; i++)
                {
                    Console.SetCursorPosition(0, i);
                    Console.Write("|");
                    Console.SetCursorPosition(playfieldWidth, i);
                    Console.Write("|");
                }

                // Draw car
                Console.SetCursorPosition(carPosition, Console.WindowHeight - 2);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write(carSymbol);

                // Move and draw obstacles
                List<(int X, int Y)> newObstacles = new List<(int X, int Y)>();
                foreach (var obstacle in obstacles)
                {
                    var newY = obstacle.Y + 1;

                    // Check for collision
                    if (newY == Console.WindowHeight - 2 && obstacle.X == carPosition)
                    {
                        gameOver = true;
                        break;
                    }

                    if (newY < Console.WindowHeight)
                    {
                        newObstacles.Add((obstacle.X, newY));
                        Console.SetCursorPosition(obstacle.X, newY);
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("*");
                    }
                }
                obstacles = newObstacles;

                // Update score
                score++;
                Console.SetCursorPosition(playfieldWidth + 2, 0);
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine($"Score: {score}");

                // Speed control
                Thread.Sleep(speed);

                // Increase difficulty
                if (score % 100 == 0 && speed > 50)
                {
                    speed -= 10;
                }
            }

            // Game over message
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Game Over!");
            Console.WriteLine($"Your final score: {score}");
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
