using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Learning.ThreadsAndTasks.Resources
{
    public static class EBookReader
    {
        private static readonly HttpClient s_httpClient = new HttpClient();

        #region Task Parallel implementaiton

        public static string GetBook(string uri = "https://www.gutenberg.org/files/98/98-0.txt",
            string downloadedBookPath = "./downloaded_book.txt")
        {
            var httpResponseMessage = s_httpClient.GetAsync(new Uri(uri))
                .GetAwaiter().GetResult();

            var bookText = httpResponseMessage.Content.ReadAsStringAsync()
                .GetAwaiter().GetResult();

            File.WriteAllText(downloadedBookPath, bookText);

            return downloadedBookPath;
        }

        public static void GetBookStats(string downloadedBookPath)
        {
            var bookText = File.ReadAllText(downloadedBookPath);

            string[] words = bookText.Split(
                new char[] { ' ', '\u000A', ',', '.', ';', ':', '-', '?', '/' },
                StringSplitOptions.RemoveEmptyEntries);

            string[] tenMostCommonWords = Array.Empty<string>();
            string longestWord = string.Empty;

            Parallel.Invoke(
                () =>
                {
                    tenMostCommonWords = FindTenMostCommonWords(words);
                },
                () =>
                {
                    longestWord = FindLongestWord(words);
                });

            StringBuilder bookStats = new StringBuilder("Ten Most Common Words are:\n");
            foreach (string commonWord in tenMostCommonWords)
            {
                bookStats.AppendLine(commonWord);
            }

            bookStats.AppendFormat("Longest word is: {0}", longestWord);
            bookStats.AppendLine();

            Console.WriteLine(bookStats.ToString(), "Book info");
        }

        private static string[] FindTenMostCommonWords(string[] words)
        {
            var frequencyOrder = words.AsParallel()
                .Where(w => w.Length > 6)
                .GroupBy(w => w)
                .OrderByDescending(g => g.Count())
                .Select(g => g.Key);

            var commonWords = frequencyOrder.Take(10).ToArray();
            return commonWords;
        }

        private static string FindLongestWord(string[] words)
        {
            return words.AsParallel().OrderByDescending(w => w.Length).FirstOrDefault();
        }

        #endregion

        #region Task-based async implementation

        public static async Task<string> GetBookAsync(string uri = "https://www.gutenberg.org/files/98/98-0.txt",
            string downloadedBookPath = "./downloaded_book.txt")
        {
            var httpResponseMessage = await s_httpClient.GetAsync(
                new Uri(uri));

            var bookText = await httpResponseMessage.Content.ReadAsStringAsync();

            File.WriteAllText(downloadedBookPath, bookText);

            return downloadedBookPath;
        }

        public static async Task GetBookStatsAsync(string downloadedBookPath)
        {
            var bookText = File.ReadAllText(downloadedBookPath);

            string[] words = bookText.Split(new char[]
                { ' ', '\u000A', ',', '.', ';', ':', '-', '?', '/'},
                StringSplitOptions.RemoveEmptyEntries);

            var findTenMostCommonWordsTask = FindTenMostCommonWordsAsync(words);                // run in parallel 
            var findLongestWordTask = FindLongestWordAsync(words);                              // run in parallel

            var statsTasks = new List<Task> { findLongestWordTask, findTenMostCommonWordsTask };
            var bookStats = new StringBuilder();

            while (statsTasks.Count > 0)
            {
                Task finishedTask = await Task.WhenAny(statsTasks);
                if (finishedTask == findTenMostCommonWordsTask)
                {
                    var tenMostCommonWords = await findTenMostCommonWordsTask;
                    bookStats.AppendLine("Ten most common words are: \n");
                    foreach (string word in tenMostCommonWords)
                    {
                        bookStats.AppendLine(word);
                    }
                }
                if (finishedTask == findLongestWordTask)
                {
                    var longestWord = await findLongestWordTask;

                    bookStats.AppendFormat("Longest word is: {0}", longestWord);
                }

                statsTasks.Remove(finishedTask);
            }

            Console.WriteLine(bookStats.ToString(), "Book info");
        }

        private static async Task<string[]> FindTenMostCommonWordsAsync(string[] words)
        {
            var frequencyOrder = words.AsParallel()
                .Where(w => w.Length > 6)
                .GroupBy(w => w)
                .OrderByDescending(g => g.Count())
                .Select(g => g.Key);

            var commonWords = frequencyOrder.Take(10).ToArray();

            return await Task.FromResult(commonWords);
        }

        private static async Task<string> FindLongestWordAsync(string[] words) =>
            await Task.FromResult(words.AsParallel().OrderByDescending(w => w.Length).FirstOrDefault());

        #endregion
    }
}
