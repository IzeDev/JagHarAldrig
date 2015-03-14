using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Core;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace JagHarAldrig.Utilities
{
    public static class PhoneOrientationUtility
    {
        public static async Task DetermineOrientation()
        {          
            StatusBar statusbar = Windows.UI.ViewManagement.StatusBar.GetForCurrentView();

            if (Window.Current.CoreWindow.Bounds.Height > Window.Current.CoreWindow.Bounds.Width)
            {
                await statusbar.ShowAsync();
            }
            else
            {
                await statusbar.HideAsync();
            }

        }

        public static async Task DetermineOrientation(Page page)
        {
            StatusBar statusbar = Windows.UI.ViewManagement.StatusBar.GetForCurrentView();

            if (Window.Current.CoreWindow.Bounds.Height > Window.Current.CoreWindow.Bounds.Width)
            {
                VisualStateManager.GoToState(page, "Portrait", true);
                await statusbar.ShowAsync();
            }
            else
            {
                VisualStateManager.GoToState(page, "Landscape", true);
                await statusbar.HideAsync();
            }

        }

    }
}
