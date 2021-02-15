using Xamarin_CRUD.Models;
using Xamarin_CRUD.ViewModels.Utils;
using Xamarin_CRUD.Views;
using Xamarin_CRUD_BL.Handlers;
using Xamarin_CRUD_DAL.Handlers;
using Xamarin_CRUD_Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Xamarin_CRUD.ViewModels
{
    public class VMEmpleados : VMBase
    {

        public ObservableCollection<PersonDepartmentName> listaPersonasDpto { get; set; }

        #region personaSeleccionada

        private PersonDepartmentName personaSeleccionada = null;
        public PersonDepartmentName PersonaSeleccionada
        {
            get { return personaSeleccionada; }

            set
            {
                personaSeleccionada = value;
                NotifyPropertyChanged("PersonaSeleccionada");
            }
        }

        #endregion

        #region Commands

        #region cargarInsertarCommand

        private DelegateCommand cargarInsertarCommand;
        public DelegateCommand CargarInsertarCommand
        {
            get
            {
                cargarInsertarCommand = new DelegateCommand(CargarInsertarCommand_Execute,
                    CargarInsertarCommand_CanExecute);
                return cargarInsertarCommand;
            }
        }

        private bool CargarInsertarCommand_CanExecute()
        {
            return true;
        }
        private void CargarInsertarCommand_Execute()
        {
            Xamarin.Forms.Application.Current.MainPage.Navigation.PushModalAsync(new InsercionEmpleado());
        }
        #endregion

        #region cargarActualizarCommand

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

        private void CargarActualizarCommand_Execute()
        {
            //Navegamos a la página de actualización y le enviamos la persona seleccionada
            //para que la cargue por defecto en los inputs
            Xamarin.Forms.Application.Current.MainPage.Navigation.PushModalAsync(new ActualizacionEmpleado(personaSeleccionada));
        }
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

        #region eliminarCommand
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
        #endregion

        #endregion

        public VMEmpleados()
        {
            //Se cargan la lista de personas con nombre de departamento

            cargarListaPersonasDpto();
        }

        private async void cargarListaPersonasDpto()
        {

            List<Department> listaDepartamentos;
            List<Person> listaPersonas;

            List<PersonDepartmentName> listaPersonasNombreDepartamento = new List<PersonDepartmentName>();

            //Creamos un diccionario para almacenar la id de cada departamento asociada
            //con su nombre

            IDictionary<int, string> dict = new Dictionary<int, string>();

            listaDepartamentos = await DepartmentHandlerBL.getDepartmentList();

            foreach(Department item in listaDepartamentos)
            {
                dict[item.ID] = item.Name;
            }

            //Usando el objeto Persona traido de la api , junto con el diccionario
            //para realizar la asignación idDepartamento => nombreDepartamento, construimos
            //una lista de objetos PersonasNombreDepartamento

            listaPersonas = await PersonHandlerBL.getPersonListBL();

            foreach (Person item in listaPersonas)
            {
                listaPersonasNombreDepartamento.Add(new PersonDepartmentName(item, dict[item.DepartmentID]));
            }

            //Asignamos a la variable de la clase la lista recien construida
            listaPersonasDpto = new ObservableCollection<PersonDepartmentName>(listaPersonasNombreDepartamento);

        }



    }
}
