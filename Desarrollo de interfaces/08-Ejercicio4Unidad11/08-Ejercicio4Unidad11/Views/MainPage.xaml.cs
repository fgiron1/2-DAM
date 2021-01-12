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

namespace _08_Ejercicio4Unidad11.Views
{
    /// <summary>
    /// Una página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {

        Frame fContenido;
        public MainPage()
        {
            this.InitializeComponent();
            this.contenido.Navigate(typeof(Inicio.PaginaBienvenida));
            fContenido = contenido;
        }


        /// <summary>
        /// Controlar la navegacion
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        /// 

        private void cambiarSeleccion(NavigationView sender, NavigationViewSelectionChangedEventArgs args)
        {
            NavigationViewItem navigationViewItem = (NavigationViewItem)args.SelectedItem;
            if (navigationViewItem != null)
            {
                switch (navigationViewItem.Tag)
                {
                    case "Inicio":
                        this.contenido.Navigate(typeof(Inicio.PaginaBienvenida));
                        break;

                    case "Personas":
                        this.contenido.Navigate(typeof(Personas.Personas), fContenido);
                        break;

                    case "Departamentos":
                        this.contenido.Navigate(typeof(Departamentos.Departamentos), fContenido);
                        break;

                }

            }


        }
    }
}
