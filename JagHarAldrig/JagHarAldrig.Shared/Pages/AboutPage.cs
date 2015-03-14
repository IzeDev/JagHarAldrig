using JagHarAldrig.Models;
using JagHarAldrig.Utilities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Navigation;

namespace JagHarAldrig.Pages
{
    public sealed partial class AboutPage : Page
    {
        List<ListboxObject> artistList;
        ListView creditOutputField;

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            artistList = new List<ListboxObject>
            {
                new ListboxObject("Pham Thi Dieu Linh"),
                new ListboxObject("Gianni"),
                new ListboxObject("Joa Ang"),
                new ListboxObject("Dillon Arloff"),
                new ListboxObject("Claire Jones")
            };

            creditOutputField = (ListView)this.FindName("nameList");
            creditOutputField.DataContext = artistList;
        }
    }
}
