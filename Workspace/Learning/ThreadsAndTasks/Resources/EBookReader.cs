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

        private HttpClient _httpClient;

        public EBookReader()
        {
            _httpClient = new HttpClient();
        }

        public async Task GetBook()
        {
            var httpResponseMessage = await _httpClient.GetAsync(
                new Uri("https://www.gutenberg.org/files/98/98-0.txt"));

            var bookText = await httpResponseMessage.Content.ReadAsStringAsync();

            File.WriteAllText("./downloaded_book.txt", bookText);
        }

        public async Task GetStats()
        {
            var bookText = File.ReadAllText("./downloaded_book.txt");

            string[] words = bookText.Split(new char[]
                { ' ', '\u000A', ',', '.', ';', ':', '-', '?', '/'},
                StringSplitOptions.RemoveEmptyEntries);

            string[] tenMostCommonWords = await FindTenMostCommon(words);

            string longestWord = await FindLongestWord(words);

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
            var frequencyOrder = words.Where(w => w.Length > 6)
                .GroupBy(w => w)
                .OrderByDescending(g => g.Count())
                .Select(g => g.Key);

            var commonWords = frequencyOrder.Take(10).ToArray();

            return await Task.FromResult(commonWords);
        }

        private async Task<string> FindLongestWord(string[] words) =>
            await Task.FromResult(words.OrderByDescending(w => w.Length).FirstOrDefault());
    }
}
