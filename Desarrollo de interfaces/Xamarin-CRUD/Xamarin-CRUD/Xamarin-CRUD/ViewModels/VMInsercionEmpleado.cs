using Xamarin_CRUD.Models;
using Xamarin_CRUD.ViewModels.Utils;
using Xamarin_CRUD_BL.Handlers;
using Xamarin_CRUD_Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Xamarin_CRUD.ViewModels
{
    public class VMInsercionEmpleado : VMBase
    {
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

        #region insertarCommand

        private DelegateCommand insertarCommand;
        public DelegateCommand InsertarCommand
        {
            get
            {
                insertarCommand = new DelegateCommand(InsertarCommand_Execute,
                    InsertarCommand_CanExecute);
                return insertarCommand;
            }

        }

        private async void InsertarCommand_Execute()
        {
            await PersonHandlerBL.updatePersonBL(new Person(inputPerson.id,
                inputPerson.FirstName,
                inputPerson.LastName,
                inputPerson.PhoneNumber,
                inputPerson.Email,
                inputPerson.Birthdate,
                inputPerson.DepartmentID));
        }
        private bool InsertarCommand_CanExecute()
        {
            bool sePuede = true;

            //Si todos los campos están rellenos

            return sePuede;

        }

        #endregion

        #endregion

    }
}
