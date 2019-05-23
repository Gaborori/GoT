using System.Collections.Generic;
using System;
using System.Linq;
using System.Threading.Tasks;
using Template10.Mvvm;
using Template10.Services.NavigationService;
using Windows.UI.Xaml.Navigation;
using System.Collections.ObjectModel;
using GoT.Models;
using GoT.Services;
using GoT.Views;

namespace GoT.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        public ObservableCollection<Book> Books { get; set; } = new ObservableCollection<Book>();
        public ObservableCollection<Character> Characters { get; set; } = new ObservableCollection<Character>();
        public ObservableCollection<House> Houses { get; set; } = new ObservableCollection<House>();

        public override async Task OnNavigatedToAsync(object parameter, NavigationMode mode, IDictionary<string, object> state)
        {
            await base.OnNavigatedToAsync(parameter, mode, state);
            await getBooks();                  
            await getCharacters(parameter, mode, state);
            await getHouses(parameter, mode, state);
        }

        private async Task getHouses(object parameter, NavigationMode mode, IDictionary<string, object> state)
        {
            var houseService = new HouseService();
            var hasHouses = true;
            var houseIndex = 1;
            while (hasHouses)
            {
                var houses = await houseService.GetHousesAsync(houseIndex);
                if (houses.Count > 0)
                {
                    foreach (var item in houses)
                    {
                        Houses.Add(item);
                    }
                    await base.OnNavigatedToAsync(parameter, mode, state);
                    houseIndex++;
                }
                else
                {
                    hasHouses = false;
                }
            }
        }

        private async Task getCharacters(object parameter, NavigationMode mode, IDictionary<string, object> state)
        {
            var characterService = new CharacterService();
            var hasCharacters = true;
            var index = 1;
            while (hasCharacters)
            {
                var characters = await characterService.GetCharactersAsync(index);
                if (characters.Count > 0)
                {
                    foreach (var item in characters)
                    {
                        if (item.name != "") { 
                        Characters.Add(item);
                    }
                    }
                    await base.OnNavigatedToAsync(parameter, mode, state);
                    index++;
                }
                else
                {
                    hasCharacters = false;
                }
            }
        }

        private async Task getBooks()
        {
            var bookService = new BookService();
            var books = await bookService.GetBooksAsync();
            foreach (var item in books)
            {
                Books.Add(item);
            }
        }

        public void NavigateToBook(string bookUrl)
        {
            NavigationService.Navigate(typeof(DetailsPage2), bookUrl);
        }

        public void NavigateToCharacter(string characterUrl)
        {
            NavigationService.Navigate(typeof(CharacterPage), characterUrl);
        }

        public void NavigateToHouse(string houseUrl)
        {
            NavigationService.Navigate(typeof(HousePage), houseUrl);
        }

    }
}

