using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_HelloWorldUWP_Clases
{
    public class ClsPersona
    {
        #region Atributos
            private string nombre; 
        #endregion

        #region Constructores
            //Por defecto
            public clsPersona()
            {
                this.Nombre
            }

            //Con parametros
            public clsPersona(string nombre)
            {
                this.nombre = nombre; //Es igual a Nombre = nombre;
                //Nombre = nombre; significa que Nombre accede al set para cambiar la propiedad; no es necesario, se puede asignar la propiedad directamente
            }
        #endregion

        #region Propiedades
            public string Nombre
            {
                get { return this._nombre; }
                set { this._nombre = value; }
            }
            //Si los getters y setters no tienen lógica adicional, se pueden crear aquí mismo todo,
            //con una unica propiedad: public int MyProperty { get; set; }

        #endregion

    }
}
