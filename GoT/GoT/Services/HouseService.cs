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
    class HouseService
    {
        private readonly Uri serverUrl = new Uri("https://www.anapioficeandfire.com/");

        public async Task<List<House>> GetHousesAsync(int pageNumber)
        {
            return await GetAsync<List<House>>(new Uri(serverUrl, "api/houses?page=" + pageNumber + "&pageSize=50"));
        }

        public async Task<House> GetHouseAsync(string url)
        {
            return await GetAsync<House>(new Uri(url));
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
