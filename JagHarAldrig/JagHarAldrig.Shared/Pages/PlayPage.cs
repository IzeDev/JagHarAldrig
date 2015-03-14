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
    public sealed partial class PlayPage : Page
    {
        List<string> gameStatements;
        int currentIndex;
        TextBlock content;

        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            gameStatements = await FileUtility.ReadBothDefaultAndUserStatementsAsync();
            RandomizeStatementOrder();
            content = (TextBlock)this.FindName("contentField");
        } 

        private void RandomizeStatementOrder()
        {
            gameStatements.Reverse();

            int finalIndexForZeroIndex = RandomUtility.GenerateNumber(4,
                gameStatements.Count / 2);
            gameStatements.Reverse(0, finalIndexForZeroIndex);

            for (int i = 0; i < 100; i++)
            {
                int initialReverseIndex = RandomUtility.GenerateNumber(0,
                    gameStatements.Count / 2);
                int finalReverseIndex = RandomUtility.GenerateNumber(0,
                    gameStatements.Count / 2);

                if (initialReverseIndex < finalReverseIndex)
                {
                    gameStatements.Reverse(initialReverseIndex, finalReverseIndex);              
                }
                else
                {
                    gameStatements.Reverse(finalReverseIndex, initialReverseIndex);             
                }
            }
        }

        private void contentGrid_Tapped(object sender, TappedRoutedEventArgs e)
        {
            if (currentIndex > gameStatements.Count - 1)
            {
                currentIndex = 0;
                RandomizeStatementOrder();
                content.Text = "Påståendena tog slut. Alla dricker!";
            }
            else
            {
                content.Text = gameStatements[currentIndex];
                currentIndex++;
            }
        }
    }
}
