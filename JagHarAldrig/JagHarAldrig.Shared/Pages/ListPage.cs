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
    public sealed partial class ListPage : Page
    {
        List<ListboxObject> items;
        bool foundNoStatements;
        ListView statements;

        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            statements = (ListView)this.FindName("statementList");

            List<string> userStatements = await FileUtility.ReadUserStatementsAsync();
            if (userStatements.Count > 0)
            {
                items = new List<ListboxObject>();
                foreach (var statement in userStatements)
                {
                    items.Add(new ListboxObject(statement));
                }
                statements.DataContext = items;
            }
            else
            {
                foundNoStatements = true;
                statements.Items.Add(new ListboxObject("Du har inte spara några påståenden!"));

            }
        }

        private void ListViewItem_Tapped(object sender, TappedRoutedEventArgs e)
        {
            if (foundNoStatements) this.Frame.Navigate(typeof(MainPage));
            else
            {
                TextBlock block = e.OriginalSource as TextBlock;
                this.Frame.Navigate(typeof(EditPage), block.Text);
            }
        }
    }
}
