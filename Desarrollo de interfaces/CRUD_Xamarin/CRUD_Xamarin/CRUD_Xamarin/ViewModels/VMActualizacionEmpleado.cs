using CRUD_Xamarin.Models;
using CRUD_Xamarin.ViewModels.Utils;
using CRUD_Xamarin_BL.Handlers;
using CRUD_Xamarin_Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CRUD_Xamarin.ViewModels
{
    public class VMActualizacionEmpleado : VMBase
    {

        //Se bindean two-way los campos con cada uno de los atributos de esta persona,
        //de tal forma que todo lo que el usuario escriba en los inputs, automáticamente
        //se verá reflejada en los campos de este objeto

        private PersonDepartmentName inputPerson;
        public PersonDepartmentName InputPerson
        {
            get { return inputPerson; }

            set
            {
                inputPerson = value;
                NotifyPropertyChanged("InputPerson");
            }
        }

        #region Commands

        #region actualizarCommand
        private DelegateCommand actualizarCommand;
        public DelegateCommand ActualizarCommand
        {
            get
            {
                actualizarCommand = new DelegateCommand(ActualizarCommand_Execute,
                    ActualizarCommand_CanExecute);
                return actualizarCommand;
            }

        }

        private async void ActualizarCommand_Execute()
        {
            await PersonHandlerBL.updatePersonBL(new Person(inputPerson.id,
                inputPerson.FirstName,
                inputPerson.LastName,
                inputPerson.PhoneNumber,
                inputPerson.Email,
                inputPerson.Birthdate,
                inputPerson.DepartmentID));
        }
        private bool ActualizarCommand_CanExecute()
        {
            bool sePuede = true;

            //Se puede si todos los campos están llenos


            return sePuede;
        }

        #endregion

        

        #endregion
        public VMActualizacionEmpleado() { }
        public VMActualizacionEmpleado(PersonDepartmentName persona)
        {
            //Sencillamente se encarga de poner los valores por defecto en los inputs de la vista
            cargarPersona(persona);
        }

        private void cargarPersona(PersonDepartmentName persona)
        {


        }
    }
}
