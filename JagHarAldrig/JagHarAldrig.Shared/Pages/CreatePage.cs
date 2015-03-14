using JagHarAldrig.Utilities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Navigation;
using JagHarAldrig.Extensions;

namespace JagHarAldrig.Pages
{
    public sealed partial class CreatePage : Page
    {
        List<string> userStatements;
        TextBox inputField;

        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            userStatements = await FileUtility.ReadUserStatementsAsync();
            inputField = (TextBox)this.FindName("inputBox");
        }

        private async void inputBox_KeyDown(object sender, KeyRoutedEventArgs e)
        {
            if (e.Key == Windows.System.VirtualKey.Enter)
            {
                e.Handled = true;
                string input = inputField.Text;
                inputField.Text = "";
                if (input.IsValid())
                {
                    userStatements.Add(input.Format());
                    await FileUtility.SaveUserStatementsAsync(userStatements);
                }
            }
        }
    }
}
