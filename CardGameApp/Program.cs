using CardGame;
using System;

namespace CardGameApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game(2, 20);
            while (!game.IsEndOfGame())
            {
                game.Play();
            }
            Console.WriteLine($"{game.FindWinnerGame()} wins the game!");
            Console.ReadLine();
        }
    }
}
