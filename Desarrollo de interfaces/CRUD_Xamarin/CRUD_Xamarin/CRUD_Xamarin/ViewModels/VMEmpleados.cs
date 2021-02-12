using CRUD_Xamarin.ViewModels.Utils;
using CRUD_Xamarin.Views;
using CRUD_Xamarin_BL.Handlers;
using CRUD_Xamarin_Entities.DTO;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace CRUD_Xamarin.ViewModels
{
    public class VMEmpleados : VMBase
    {
        //Este ViewModel es usado por las vistas de detalle y de la lista
        //con la lista de personas y la persona seleccionada
        public ObservableCollection<PersonDepartmentName> listaPersonasDpto;

        private PersonDepartmentName personaSeleccionada = null;
        public PersonDepartmentName PersonaSeleccionada
        {
            get { return personaSeleccionada; }

            set
            {
                personaSeleccionada = value;
                eliminarCommand
                NotifyPropertyChanged("PersonaSeleccionada");
            }
        }

        //Commands
        #region

        //COMMAND: ENLAZADO A UN BOTÓN QUE TRAE LA PÁGINA DE
        //ACTUALIZAR 

        private DelegateCommand cargarActualizarCommand;
        public DelegateCommand CargarActualizarCommand
        {
            get
            {
                cargarActualizarCommand = new DelegateCommand(CargarActualizarCommand_Execute,
                    CargarActualizarCommand_CanExecute);
                return cargarActualizarCommand;
            }
        }


        //COMMAND: Envia la person

        private DelegateCommand eliminarCommand;
        public DelegateCommand EliminarCommand
        {
            get
            {
                eliminarCommand = new DelegateCommand(EliminarCommand_ExecuteAsync,
                    EliminarCommand_CanExecute);
                return eliminarCommand;
            }

        }

        private async void EliminarCommand_ExecuteAsync()
        {
            await PersonHandlerBL.deletePerson(personaSeleccionada.id);
        }

        private bool EliminarCommand_CanExecute()
        {
            bool sePuede = true;

            if(personaSeleccionada == null)
            {
                sePuede = false;
            }

            return sePuede;

        }

        private void CargarActualizarCommand_Execute()
        {
            //Navegamos a la página de actualización
            Xamarin.Forms.Application.Current.MainPage.Navigation.PushAsync(new ActualizacionEmpleado());
        }

        //Si no hay ninguna persona seleccionada, no se puede utilizar el command
        private bool CargarActualizarCommand_CanExecute()
        {
            bool sePuede = true;

            if (personaSeleccionada == null)
            {
                sePuede = false;
            }

            return sePuede;

        }
        

        #endregion


        public VMEmpleados()
        {

        }

    }
}
