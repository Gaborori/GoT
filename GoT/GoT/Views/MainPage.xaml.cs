using GoT.Models;
using System;
using Windows.UI.Xaml.Controls;

namespace GoT.Views
{
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void Book_ItemClick(object sender, ItemClickEventArgs e)
        {
            var book = (Book)e.ClickedItem;
            ViewModel.NavigateToBook(book.url);
        }

        private void Character_ItemClick(object sender, ItemClickEventArgs e)
        {
            var character = (Character)e.ClickedItem;
            ViewModel.NavigateToCharacter(character.url);
        }

        private void House_ItemClick(object sender, ItemClickEventArgs e)
        {
            var house = (House)e.ClickedItem;
            ViewModel.NavigateToHouse(house.url);
        }
    }
}
