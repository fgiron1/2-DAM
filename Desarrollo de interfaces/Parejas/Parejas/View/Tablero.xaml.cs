using Parejas.Converter;
using Parejas.Model;
using Parejas.Viewmodel;
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
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Navigation;

// La plantilla de elemento Página en blanco está documentada en https://go.microsoft.com/fwlink/?LinkId=234238

namespace Parejas.View
{
    /// <summary>
    /// Una página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class Tablero : Page
    {
        private TableroVM VM;
        private ColorAValor Converter;

        public Tablero()
        {
            this.InitializeComponent();
            VM = new TableroVM();
            Converter = new ColorAValor();
        }

        private void carta_Tapped(object sender, TappedRoutedEventArgs e)
        {
            //Instanciamos los objetos necesarios
 
            Image cartaClicada = (Image)sender;
            PlaneProjection proyeccion = new PlaneProjection { RotationY = 90 };
            cartaClicada.Projection = proyeccion;

            DoubleAnimation darVuelta = new DoubleAnimation();
            darVuelta.From = 0;
            darVuelta.To = 180;
            darVuelta.Duration = new Duration(TimeSpan.FromMilliseconds(1000));

            Storyboard storyboard = new Storyboard();
            Storyboard.SetTarget(darVuelta, cartaClicada);

            Storyboard.SetTargetProperty(darVuelta, "(UIElement.Projection).(PlaneProjection.RotationY)");

            storyboard.Children.Add(darVuelta);

            storyboard.Begin();
            //LO SIGUIENTE A IMPLEMENTAR
            //cartaClicada.Source = anverso
            //

        }
    }
}
