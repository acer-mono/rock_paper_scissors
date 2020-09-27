using System;

namespace rock_paper_scissors
{
    class Program
    {
        static void Main(string[] args)
        {
            var game = new Game(10);
            
            while (game.Next())
            {
                Console.WriteLine("__________________________________________________");
            }

            foreach (var result in game.Result())
            {
                Console.WriteLine(result);
            }
        }
    }
}