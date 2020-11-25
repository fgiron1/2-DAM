using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace EJ2_UD11_bueno
{
    //No implementa INotifyPropertyChanged dado que este modelo es usado como entidad de persistencia;
    //nos interesa en tanto que nos permite comunicarnos con la base de datos.
    public class Persona
    {

        #region Nombre
        private string _nombre;
        public string Nombre
        {
            get
            {
                return this._nombre;
            }

            set
            {
                if(value != _nombre)
                {
                    this._nombre = value;
                    OnPropertyChanged();
                }
            }
        }
        #endregion
        #region Apellidos
        private string _apellidos;
        public string Apellidos
        {
            get
            {
                return this._apellidos;
            }

            set
            {
                if (value != _apellidos)
                {
                    this._apellidos = value;
                    OnPropertyChanged();
                }
            }
        }
        #endregion

        public Persona(string nombre, string apellidos)
        {
            this.Nombre = nombre;
            this.Apellidos = apellidos;
        }
    }
}
