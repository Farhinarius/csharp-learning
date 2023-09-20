using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Workspace.Learning.ThreadsAndTasks.Resources
{
    public class EBookReader
    {
        private string _bookDownloadPath = "./downloaded_book.txt";

        private readonly HttpClient _httpClient;

        public EBookReader()
        {
            _httpClient = new HttpClient();
        }

        public async Task GetBookAsync()
        {
            var httpResponseMessage = await _httpClient.GetAsync(
                new Uri("https://www.gutenberg.org/files/98/98-0.txt"));

            var bookText = await httpResponseMessage.Content.ReadAsStringAsync();

            File.WriteAllText(_bookDownloadPath, bookText);
        }

        public async Task GetStatsAsync()
        {
            var bookText = File.ReadAllText(_bookDownloadPath);

            string[] words = bookText.Split(new char[]
                { ' ', '\u000A', ',', '.', ';', ':', '-', '?', '/'},
                StringSplitOptions.RemoveEmptyEntries);

            var taskFindTenMostCommonWords = FindTenMostCommon(words);              // run in parallel (in different thread)
            var taskFindLongestWord = FindLongestWord(words);                       // run in parallel (in different thread)

            string[] tenMostCommonWords = await taskFindTenMostCommonWords;         // parallel wait task completion
            string longestWord = await taskFindLongestWord;                         // parallel wait task completion

            var bookStats = new StringBuilder("Ten Most Common Words are: \n");
            foreach (string word in tenMostCommonWords)
            {
                bookStats.AppendLine(word);
            }

            bookStats.AppendFormat("Longest word is: {0}", longestWord);
            bookStats.AppendLine();

            Console.WriteLine(bookStats.ToString(), "Book info");
        }

        private async Task<string[]> FindTenMostCommon(string[] words)
        {
            var frequencyOrder = words.AsParallel()
                .Where(w => w.Length > 6)
                .GroupBy(w => w)
                .OrderByDescending(g => g.Count())
                .Select(g => g.Key);

            var commonWords = frequencyOrder.Take(10).ToArray();

            return await Task.FromResult(commonWords);
        }

        private async Task<string> FindLongestWord(string[] words) =>
            await Task.FromResult(words.AsParallel().OrderByDescending(w => w.Length).FirstOrDefault());
    }
}
