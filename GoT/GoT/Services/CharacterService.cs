﻿using GoT.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Web.Http;

namespace GoT.Services
{
    class CharacterService
    {
        private readonly Uri serverUrl = new Uri("https://www.anapioficeandfire.com/");

        public async Task<List<Character>> GetCharactersAsync(int pageNumber)
        {
          
                return await GetAsync<List<Character>>(new Uri(serverUrl, "api/characters?page="+ pageNumber +"&pageSize=50"));
            
           
        }

        public async Task<Character> GetCharacterAsync(string url)
        {
            return await GetAsync<Character>(new Uri(url));
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
