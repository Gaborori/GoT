using GoT.Models;
using GoT.Services;
using GoT.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template10.Mvvm;
using Windows.UI.Xaml.Navigation;

namespace GoT.ViewModels
{
    class HousePageViewModel : ViewModelBase
    {
        private House house;

        public ObservableCollection<Character> SwornMembers { get; set; } = new ObservableCollection<Character>();

        public House House
        {
            get { return house; }
            set { Set(ref house, value); }
        }

        public override async Task OnNavigatedToAsync(object parameter, NavigationMode mode, IDictionary<string, object> state)
        {
            var houseUrl = (string)parameter;
            var service = new HouseService();
            var characterService = new CharacterService();
            House = await service.GetHouseAsync(houseUrl);

            foreach (var item in house.swornMembers)
            {
                var character = await characterService.GetCharacterAsync(item);
                SwornMembers.Add(character);
            }

            
            await base.OnNavigatedToAsync(parameter, mode, state);
        }

        public void NavigateToCharacter(string characterUrl)
        {
            NavigationService.Navigate(typeof(CharacterPage), characterUrl);
        }
    }
}
