using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// La plantilla de elemento Página en blanco está documentada en https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0xc0a

namespace BackwardsNavigation
{
    /// <summary>
    /// 
    /// </summary>
    public sealed partial class MainPage : Page
    {
        #region Constructors
        public MainPage()
        {
            this.InitializeComponent();

        }
        #endregion
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            BackButton.IsEnabled = this.Frame.CanGoBack;
        }

        public void BackClick1(object sender, RoutedEventArgs e)
        {
            On_BackRequested();
        }

        //This method checks whether the frame can go back and does it (also returns true) or not, returning false
        private bool On_BackRequested()
        {
            Boolean canGoBack;

            if (this.Frame.CanGoBack)
            {
                this.Frame.GoBack();
                canGoBack = true;
            } else
            {
                canGoBack = false;
            }

            return canGoBack;
        }

        //TODO No entiendo la necesidad de este método


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(BlankPage1));
        }
    }
}
