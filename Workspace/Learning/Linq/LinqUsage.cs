using System;
using System.Collections.Generic;
using System.Linq;

namespace Workspace.Learning.Linq
{
    public static class LinqUsage
    {
        public static void TestQueryOverStrings()
        {
            string[] currentVideoGames = { "Morrowind", "Uncharted 2", "Fallout 3", "Daxter", "System Shock 2" };

            // LINQ query expression syntax
            IEnumerable<string> videoGamesWithSpace =
                from g in currentVideoGames
                where g.Contains(" ")
                orderby g
                select g;

            // extension method syntax
            IEnumerable<string> videoGamesWithSpaceByExtensions = 
                currentVideoGames.Where(g => g.Contains(" ")).OrderBy(g => g).Select(g => g);

            foreach (var game in videoGamesWithSpace)
            {
                Console.WriteLine(game);
            }
            ReflectOverQueryResults(videoGamesWithSpace);
            Console.WriteLine();

            foreach (var g in videoGamesWithSpaceByExtensions)
            {
                Console.WriteLine(g);
            }
            ReflectOverQueryResults(videoGamesWithSpaceByExtensions);
            Console.WriteLine();

            var videoGamesAlphabeticOrdered = currentVideoGames.OrderBy(g => g.First());
            foreach (var g in videoGamesAlphabeticOrdered)
            {
                Console.WriteLine(g);
            }
            ReflectOverQueryResults(videoGamesAlphabeticOrdered);
        }

        public static void ReflectOverQueryResults(object resultSet)
        {
            // Вывести тип результирующего набора.
            Console.WriteLine("resultSet is of type: {0}", resultSet.GetType().Name);

            // Вывести местоположение результирующего набора.
            Console.WriteLine("resultSet location: {0}", resultSet.GetType().Assembly.GetName().Name);
        }
    }
}
