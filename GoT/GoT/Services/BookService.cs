using GoT.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Web.Http;

namespace GoT.Services
{
    class BookService
    {
        private readonly Uri serverUrl = new Uri("https://www.anapioficeandfire.com/");

        public async Task<List<Book>> GetBooksAsync()
        {
            return await GetAsync<List<Book>>(new Uri(serverUrl, "api/books?page=1&pageSize=50"));
        }

        public async Task<Book> GetBookAsync(string url)
        {
            return await GetAsync<Book>(new Uri(url));
        }

        private async Task<T> GetAsync<T>(Uri uri)
        {
            using (var client = new HttpClient())
            {
                var response = await client.GetAsync(uri);
                var json = await response.Content.ReadAsStringAsync();
                T result = JsonConvert.DeserializeObject<T>(json);
                return result;
            }
        }
    }
}
