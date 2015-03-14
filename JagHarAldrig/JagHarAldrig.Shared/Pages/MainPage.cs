using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Navigation;

namespace JagHarAldrig.Pages
{
    public sealed partial class MainPage : Page
    {
        Image play;
        Image create;
        Image list;
        Image about;

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            this.Frame.BackStack.Clear();

            play = (Image)this.FindName("playImage");
            create = (Image)this.FindName("createImage");
            list = (Image)this.FindName("listImage");
            about = (Image)this.FindName("aboutImage");

            play.DataContext = "ms-appx:///Assets/Images/MainPage/White/WineGlass.png";
            create.DataContext = "ms-appx:///Assets/Images/MainPage/White/Quil.png";
            list.DataContext = "ms-appx:///Assets/Images/MainPage/White/Search.png";
            about.DataContext = "ms-appx:///Assets/Images/MainPage/White/Phone.png";
        }


        private void Play_Tapped(object sender, TappedRoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(PlayPage));
        }

        private void Create_Tapped(object sender, TappedRoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(CreatePage));
        }

        private void List_Tapped(object sender, TappedRoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(ListPage));
        }

        private void About_Tapped(object sender, TappedRoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(AboutPage));
        }
    }
}
