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

// La plantilla de elemento Página en blanco está documentada en https://go.microsoft.com/fwlink/?LinkId=234238

namespace BasicNavigation
{
    /// <summary>
    /// Una página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class BlankPage1 : Page
    {
        public BlankPage1() {
            this.InitializeComponent();
        }

        private void HyperlinkButton_Click(object sender, RoutedEventArgs e)
        {
            //Se le pasa el tipo de la página porque MainPage en sí mismo no es un tipo.
            //No hay ambiguedad porque cada página tiene su propia clase, por lo que no hay duda al pasarle un tipo
            //MainPage para referirse a la página MainPage
            this.Frame.Navigate(typeof(MainPage));
        }
         
        //Este método es llamado cuando se navega hacia esta página
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            //Comprobamos que el parametro pasado a través del método Navigation, en MainPage.xaml.cs, sea una string válida
        if (e.Parameter is string && !string.IsNullOrWhiteSpace(e.Parameter as string))
        {
                greeting.Text = $"Hola, {e.Parameter.ToString()}";
        }
        else
        {
                greeting.Text = "¿Quién eres?";
        }

            base.OnNavigatedTo(e);
        }
    }
}
