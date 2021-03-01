using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;

namespace FernandoGironDominguezDIN.Converters
{
    //En el XAML solo hay que poner una referencia a este espacio de nombres y declararlo
    //como un recurso de página o bien de un diccionario de recursos.
    public class converterEjemplo : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            var strValue = value as string;

            if (!string.IsNullOrEmpty(strValue))
            {
                strValue = strValue.ToUpper();
            }
            return strValue;
        }

        //En el convertBack devolvemos lo mismo, no hacemos nada. Pero podríamos escribir cualquier código que nos interese

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            return value;
        }
    }
}
