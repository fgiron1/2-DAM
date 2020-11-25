
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EJ2_UD11_bueno
{
    public class MainPageVM : clsVMBase
    {
        private DelegateCommand _eliminarCommand;
        public ObservableCollection<Persona> listado { get; set; } = new ObservableCollection<Persona>();
        public Persona personaSeleccionada
        {
            get
            {
                return personaSeleccionada;
            }

            set
            {
                personaSeleccionada = value;
                EliminarCommand.RaiseCanExecuteChanged();
                NotifyPropertyChanged("personaSeleccionada");
            }
        }
        public string textoBusqueda { get; set; }
        
        public DelegateCommand EliminarCommand
        {
            get
            {
                //Se le provee de la funcionalidad al command
                _eliminarCommand = new DelegateCommand(eliminarCommand_execute, eliminarCommand_canExecute);
                return EliminarCommand;
            }

        }

        public MainPageVM()
        {


            Persona p1 = new Persona("Fernando", "Giron");
            this.listado.Add(p1);
            Persona p2 = new Persona("José", "Luis");
            this.listado.Add(p2);
            Persona p3 = new Persona("Alberto", "Martín");
            this.listado.Add(p3);
            Persona p4 = new Persona("Inmaculada", "García");
            this.listado.Add(p4);
            Persona p5 = new Persona("Lucas", "De la torre");
            this.listado.Add(p5);
            Persona p6 = new Persona("David", "Parejo");
            this.listado.Add(p6);
            Persona p7 = new Persona("Yeray", "Hernández");
            this.listado.Add(p7);
            Persona p8 = new Persona("Luis", "Gil");
            this.listado.Add(p8);


        }

        private void eliminarCommand_execute()
        {
            listado.Remove(personaSeleccionada);
        }

        private bool eliminarCommand_canExecute()
        {
            bool sePuede;

            if(personaSeleccionada == null)
            {
                sePuede = true;
            } else
            {
                sePuede = false;
            }

            return sePuede;
            
        }
    }
}
