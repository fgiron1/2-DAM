using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace EJ2_UD11_bueno
{
    //El modelo implementa INotifyPropertyChanged, en lugar del VM, dado que la ObservableCollection que maneja el VM ya avisa de cambios entre los
    //objetos que la componen. No obstante, no existe ningun mecanismo que nos notifique sobre las modificaciones en las propiedades de esos objetos
    //de la coleccion
    public class Persona : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

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

        public void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
