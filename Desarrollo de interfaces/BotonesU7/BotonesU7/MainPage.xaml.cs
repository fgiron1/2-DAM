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

namespace BotonesU7
{
    /// <summary>
    /// Página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button btn = new Button();

            //This can be generalized using styles, check https://docs.microsoft.com/es-es/windows/uwp/design/controls-and-patterns/xaml-styles
            btn.Name = "Boton3";
            btn.Background = boton1.Background;
            btn.HorizontalContentAlignment = boton1.HorizontalContentAlignment;
            btn.VerticalContentAlignment = boton1.VerticalContentAlignment;
            btn.Content = "Boton3";
            btn.Width = boton1.Width;
            btn.Height = boton1.Height;
            btn.FontFamily = boton1.FontFamily;
            btn.FontSize = boton1.FontSize;
            btn.FontWeight = boton1.FontWeight;
            btn.BorderBrush = boton1.BorderBrush;
            btn.Margin = boton1.Margin;

            //Assigning an event handler to the newly created button
            btn.Click += Boton3_Click;
           
            
            panel.Children.Add(btn);

            

        }

        public void Boton3_Click(object sender, RoutedEventArgs e)
        {
            panel.Children.Remove(boton1);
        }
    
    
    }


}
