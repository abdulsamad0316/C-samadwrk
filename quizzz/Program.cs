using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("University Test");

        int testnum = 5;
        int score = 0;

        for (int i = 1; i <= 4; i++)
        {
            Console.WriteLine("\n1. Aptitude");
            Console.WriteLine("2. English");
            Console.WriteLine("3. Math");
            Console.WriteLine("4. GK");
            Console.WriteLine("5. Exit");

            Console.Write("Choose a number: ");
            var input = Console.ReadLine();

            if (string.IsNullOrEmpty(input) || !int.TryParse(input, out testnum))
            {
                Console.WriteLine("Invalid input. Please enter a number between 1 and 5.");
                continue;
            }

            switch (testnum)
            {
                case 1:
                    Console.WriteLine("This is an aptitude question.");
                    Console.Write("Your answer (a, b, c, d): ");
                    string ans1 = Console.ReadLine()?.ToLower();
                    if (ans1 == "a")
                    {
                        Console.WriteLine("Correct!");
                        score += 10;
                    }
                    else
                    {
                        Console.WriteLine("Wrong answer.");
                    }
                    break;

                case 2:
                    Console.WriteLine("This is an English question.");
                    Console.Write("Your answer (a, b, c, d): ");
                    string ans2 = Console.ReadLine()?.ToLower();
                    if (ans2 == "b")
                    {
                        Console.WriteLine("Correct!");
                        score += 10;
                    }
                    else
                    {
                        Console.WriteLine("Wrong answer.");
                    }
                    break;

                case 3:
                    Console.WriteLine("This is a math question.");
                    Console.Write("Your answer (a, b, c, d): ");
                    string ans3 = Console.ReadLine()?.ToLower();
                    if (ans3 == "c")
                    {
                        Console.WriteLine("Correct!");
                        score += 10;
                    }
                    else
                    {
                        Console.WriteLine("Wrong answer.");
                    }
                    break;

                case 4:
                    Console.WriteLine("This is a GK question.");
                    Console.Write("Your answer (a, b, c, d): ");
                    string ans4 = Console.ReadLine()?.ToLower();
                    if (ans4 == "d")
                    {
                        Console.WriteLine("Correct!");
                        score += 10;
                    }
                    else
                    {
                        Console.WriteLine("Wrong answer.");
                    }
                    break;

                case 5:
                    Console.WriteLine("Exiting the test...");
                    Console.WriteLine($"Your total score is: {score}");
                    return; 

                default:
                    Console.WriteLine("Please enter a valid number (1-5).");
                    break;
            }
        }

        Console.WriteLine($"Your total score is: {score}");
    }
}


