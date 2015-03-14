using JagHarAldrig.Utilities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkID=390556

namespace JagHarAldrig.Pages
{
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();            
        }

        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            this.Frame.BackStack.Clear();

            if (BackgroundIsWhite())
            {
                playImage.DataContext = "ms-appx:///Assets/Images/MainPage/Black/WineGlass.png";
                createImage.DataContext = "ms-appx:///Assets/Images/MainPage/Black/Quil.png";
                listImage.DataContext = "ms-appx:///Assets/Images/MainPage/Black/Search.png";
                aboutImage.DataContext = "ms-appx:///Assets/Images/MainPage/Black/Phone.png";
            }
            else
            {
                playImage.DataContext = "ms-appx:///Assets/Images/MainPage/White/WineGlass.png";
                createImage.DataContext = "ms-appx:///Assets/Images/MainPage/White/Quil.png";
                listImage.DataContext = "ms-appx:///Assets/Images/MainPage/White/Search.png";
                aboutImage.DataContext = "ms-appx:///Assets/Images/MainPage/White/Phone.png";
            }
            
            await DetermineOrientation();
        }

        private bool BackgroundIsWhite()
        {
            SolidColorBrush white = new SolidColorBrush(Colors.White);
            SolidColorBrush background = Application.Current.Resources["ApplicationPageBackgroundThemeBrush"] as SolidColorBrush;

            return background.Color == white.Color;
        }

        private async void Page_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            await DetermineOrientation();
        }

        private async Task DetermineOrientation()
        {
            await PhoneOrientationUtility.DetermineOrientation(this);           
        }

        private void PlayBtn_Tapped(object sender, TappedRoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(PlayPage));
        }

        private void CreateBtn_Tapped(object sender, TappedRoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(CreatePage));
        }

        private void ListBtn_Tapped(object sender, TappedRoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(ListPage));
        }

        private void AboutBtn_Tapped(object sender, TappedRoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(AboutPage));
        }
    }
}
