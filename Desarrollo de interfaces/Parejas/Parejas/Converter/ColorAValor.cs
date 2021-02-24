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
            {1, "/Assets/Azul.png" },
            {2, "/Assets/Rojo.png" },
            {3, "/Assets/Verde.png" },
            {4, "/Assets/Amarillo.png" },
            {5, "/Assets/Púrpura.png" },
            {6, "/Assets/Naranja.png" },
            {7, "/Assets/Marrón.png" },
            {8, "/Assets/Rosa.png" },
            {9, "/Assets/Negro.png" }
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
