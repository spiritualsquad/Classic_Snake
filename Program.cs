using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        //initialize variables
        List<(int, int)> snake = new List<(int, int)> { (0, 0) }; // Snake starting position
        Random random = new Random();// initialize random value
        (int, int) food = (random.Next(0, 5), random.Next(0, 5)); // Initial food position
        int score = 0;

        // Main game loop
        while (score < 100)
        {
            // Display the game board
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    if (snake.Contains((i, j)))
                    {
                        if ((i, j) == snake[0]) // Snake head
                            Console.Write("S ");
                        else if ((i, j) == food) // Snake body or head on food
                            Console.Write("# ");
                        else // Snake body
                            Console.Write("o ");
                    }
                    else if ((i, j) == food)
                        Console.Write("F "); // Food
                    else
                        Console.Write(". "); // Empty space
                }
                Console.WriteLine();
            }

            // Get user input for snake direction
            Console.Write("Enter direction (up/down/right/left): ");
            string user_input = Console.ReadLine().ToLower();

            // Update snake position based on user input
            var head = snake[0];
            (int, int) newHead;
            if (user_input == "up")
                newHead = (head.Item1 - 1, head.Item2);
            else if (user_input == "down")
                newHead = (head.Item1 + 1, head.Item2);
            else if (user_input == "right")
                newHead = (head.Item1, head.Item2 + 1);
            else if (user_input == "left")
                newHead = (head.Item1, head.Item2 - 1);
            else
                continue;

            // Check if snake eats the food
            if (newHead == food)
            {
                snake.Insert(0, newHead);
                food = (random.Next(0, 5), random.Next(0, 5));// get new food
                score += 10;
            }
            else
            {
                // Move the snake
                snake.Insert(0, newHead);
                snake.RemoveAt(snake.Count - 1);
            }

            // Check if the snake hits the wall and reset the game
            if (newHead.Item1 < 0 || newHead.Item1 >= 5 || newHead.Item2 < 0 || newHead.Item2 >= 5)
            {
                Console.WriteLine($"Game Over! Your score: {score}");
                break;
            }
        }

        // End of the game
        if (score >= 100)
            Console.WriteLine("Congratulations! You reached 100 points and won the game!");
    }
}
