using MatchGameEngine;
using MatchGameEngine.MatchRules;
using MatchGameEngine.Models;
using System;

namespace MatchGameUI
{
    class Program
    {
        //Task 1 - Build Basic Game Engine with a simple match rule
        //Task 2 - Shuffle decks and ability to use multiple decks
        //Task 3 - Introduce more game modes
        //Task 4 - Randomise bots reaction time

        /*
         * GameFlow:
         * Player specify number of decks and match rule
         * Game engine shuffle number of requested deck
         * Game engine determine player A or B wins at random
         * Winner takes the card drawn
         * Game resume
         * Player with most cards win, draw is possible
         */

        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var Bob = new Player("Bob");
            var Alice = new Player("Alice");

            var game = new Game(new ShuffledDeckProvider(), new GameConfiguration(
                Bob,
                Alice,
                1,
                new ValueAndSuitMatchRule()));

            var result = game.Play();

            Console.WriteLine($"Status {result.Status} " +
                $": {result.Winner.Name}:{result.Winner.Cards.Count}");

            Console.ReadKey();
        }
    }
}
