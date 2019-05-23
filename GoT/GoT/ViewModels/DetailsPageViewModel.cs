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
    public class DetailsPageViewModel: ViewModelBase
    {
        private Book book;

       public ObservableCollection<Character> PovCharacters { get; set; } = new ObservableCollection<Character>();

        public Book Book
        {
            get { return book; }
            set { Set(ref book, value); }
        }

        public override async Task OnNavigatedToAsync(object parameter, NavigationMode mode, IDictionary<string, object> state)
        {
            var bookUrl = (string)parameter;
            var service = new BookService();
            Book = await service.GetBookAsync(bookUrl);


            var characterService = new CharacterService();
            foreach (var item in book.povCharacters)
            {   
                var character = await characterService.GetCharacterAsync(item);
                PovCharacters.Add(character);
            }

            await base.OnNavigatedToAsync(parameter, mode, state);
        }

        public void NavigateToCharacter(string characterUrl)
        {
            NavigationService.Navigate(typeof(CharacterPage), characterUrl);
        }



    }
}
