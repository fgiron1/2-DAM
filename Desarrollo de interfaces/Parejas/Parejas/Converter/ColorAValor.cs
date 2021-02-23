using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;

namespace Parejas.Converter
{
    public class ColorAValor : IValueConverter
    {
        //Inicializamos el diccionario con el código de color que hemos establecido 
        private Dictionary<int, string> codigoColor = new Dictionary<int, string>()
        {
            {1, "Blue" },
            {2, "Red" },
            {3, "Green" },
            {4, "Yellow" },
            {5, "Purple" },
            {6, "Orange" },
            {7, "Brown" },
            {8, "Pink" },
            {9, "Black" }
        };

        //De valor a color
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            int valor = (int)value;
            return codigoColor[valor];
        
        }
        //De color a valor
        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            string color = (string)value;

            //Hacemos una búsqueda inversa en el diccionario (buscando la clave asignada a un valor)
            //Por la unicidad de los valores del diccionario, no hay que hacer comprobaciones adicionales
            //para escoger la clave 

            return codigoColor.FirstOrDefault(x => x.Value == color).Key;
        }
    }
}
