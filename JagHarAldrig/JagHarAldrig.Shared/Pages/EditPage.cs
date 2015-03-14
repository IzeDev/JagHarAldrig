using JagHarAldrig.Utilities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Windows.System;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

namespace JagHarAldrig.Pages
{
    public sealed partial class EditPage : Page
    {
        string importedStatement;
        List<string> userStatements;
        int selectedStatementIndex;

        TextBox inputField;
        Image trashCan;

        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            importedStatement = e.Parameter as string;
            userStatements = await FileUtility.ReadUserStatementsAsync();
            selectedStatementIndex = userStatements
            .IndexOf(importedStatement);       
            inputField = (TextBox)this.FindName("inputBox");
            inputField.Text = userStatements[selectedStatementIndex];

            trashCan = (Image)this.FindName("traschcanImage");
            trashCan.DataContext = "ms-appx:///assets/images/editstatement/whitetrashcan.png";
        }

        private async void inputBox_KeyDown(object sender, KeyRoutedEventArgs e)
        {
            if (e.Key == VirtualKey.Enter)
            {
                string input = inputField.Text;
                inputField.Text = "";
                if (!string.IsNullOrWhiteSpace(input))
                {
                    userStatements[selectedStatementIndex] = input;
                    await FileUtility.SaveUserStatementsAsync(userStatements);
                    Frame.GoBack();
                }
            }
        }

        private async void trashcanGrid_Tapped(object sender, TappedRoutedEventArgs e)
        {
            userStatements.RemoveAt(selectedStatementIndex);
            await FileUtility.SaveUserStatementsAsync(userStatements);
            Frame.GoBack();
        }
    }
}
