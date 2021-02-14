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
        //Task 4 - Randomise bots reaction time (skipped)

        /*
         * GameFlow:
         * Player specify number of decks and match rule
         * Game engine shuffle number of requested deck
         * Game engine determine player A or B wins at random
         * Winner takes the card drawn
         * Game resume
         * Player with most cards win, draw is possible
         */

        /*Time Taken 2 hours
         * AfterThought:
         * The game class feel a bit bloated, I would like to refactor that if there are more time.
         * I skipped user input from Console.ReadLines 
         * I skipped the usage of Ioc and factory delegate Fuc<T> for Matching Rules due to time
         * I would implement intergration tests
         * I would thinking about what to make `internal and restrict access to some of the variables e.g. IReadOnlyCollection
         * I would like to review some of the loopings and optmised where possible 
         * I would like to refactor some of the code espically naming
         * I would like to extract the logic from selecting the winners in Game.cs
         * 
         * Thank you
         * 
         * Tai
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
