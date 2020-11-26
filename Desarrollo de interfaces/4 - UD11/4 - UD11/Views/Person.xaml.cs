using _4___UD11.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// La plantilla de elemento Página en blanco está documentada en https://go.microsoft.com/fwlink/?LinkId=234238

namespace _4___UD11.Views
{
    /// <summary>
    /// Una página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>

    public sealed partial class Person : Page
    {

        public PersonVM ViewModel {get; set;}

        public Person()
        {
            this.InitializeComponent();
            ViewModel = new PersonVM();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            topMenu.IsBackEnabled = this.Frame.CanGoBack;
        }


        //This method checks whether the frame can go back and does it (also returns true). If it can't, returns false
        private void On_BackRequested(NavigationView sender, NavigationViewBackRequestedEventArgs e)
        {

            if (this.Frame.CanGoBack)
            {
                this.Frame.GoBack();
            }

            //True if backwards navigation was successful


        }
    }
}
