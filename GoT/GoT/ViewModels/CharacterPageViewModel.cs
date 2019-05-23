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
    public class CharacterPageViewModel : ViewModelBase
    {
        private Character character;


        public ObservableCollection<Book> Books { get; set; } = new ObservableCollection<Book>();



        public Character Character
        {
            get { return character; }
            set { Set(ref character, value); }
        }



        public override async Task OnNavigatedToAsync(object parameter, NavigationMode mode, IDictionary<string, object> state)
        {
            var characterUrl = (string)parameter;
            var service = new CharacterService();
            Character = await service.GetCharacterAsync(characterUrl);
           

            var bookService = new BookService();
            foreach (var item in character.books)
            {
                var book = await bookService.GetBookAsync(item);
                Books.Add(book);
            }

            foreach (var item in character.povBooks)
            {
                var povBook = await bookService.GetBookAsync(item);
                Books.Add(povBook);
            }
            await base.OnNavigatedToAsync(parameter, mode, state);
        }

        public void NavigateToBook(string bookUrl)
        {
            NavigationService.Navigate(typeof(DetailsPage2), bookUrl);
        }

    }
}
