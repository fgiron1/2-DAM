using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01___Saludar
{
    public class clsPersona
    {
        //Instance variables
        private String name;

        #region Propiedades
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        #endregion

        #region Constructores
        //Default constructor
        public clsPersona()
        {
            this.name = "Foo";
        }

        //Parameterized constructor
        public clsPersona(String name)
        {
            this.name = name;
        }
        #endregion



        //Campo nombre, constructor por defecto y constructor con parámetros
    }
}
