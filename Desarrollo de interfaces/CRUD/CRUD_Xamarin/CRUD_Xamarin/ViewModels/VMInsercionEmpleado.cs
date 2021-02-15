using CRUD_Xamarin.Models;
using CRUD_Xamarin.ViewModels.Utils;
using CRUD_Xamarin_BL.Handlers;
using CRUD_Xamarin_DAL.Handlers;
using CRUD_Xamarin_Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CRUD_Xamarin.ViewModels
{
    public class VMInsercionEmpleado : VMBase
    {
        private PersonDepartmentName inputPerson = new PersonDepartmentName();
        public PersonDepartmentName InputPerson
        {
            get { return inputPerson; }
            set
            {
                inputPerson = value;
                NotifyPropertyChanged("InputPerson");
            }
        }

        private Department chosenDepartment;
        public Department ChosenDepartment
        {
            get { return chosenDepartment; }
            //Cada vez que se actualice el valor de chosenDepartment, a su vez se actualizará
            //el DepartmentID de inputPerson
            set
            {
                ChosenDepartment = value;
                inputPerson.DepartmentID = chosenDepartment.ID;
                //Creo que no es necesario
                NotifyPropertyChanged("ChosenDepartment");
            }
        }
        public List<Department> DepartmentList { get; set; }

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
            //Leer TODO.txt el apartado NOTAS

            await PersonHandlerBL.insertPersonBL(new Person(

                inputPerson.id,
                inputPerson.FirstName,
                inputPerson.LastName,
                inputPerson.PhoneNumber,
                inputPerson.Email,
                inputPerson.Birthdate,
                inputPerson.DepartmentID)); ;
        }
        private bool InsertarCommand_CanExecute()
        {
            bool sePuede = true;

            //Si todos los campos están rellenos

            return sePuede;

        }

        #endregion

        #endregion

        public VMInsercionEmpleado()
        {
            //Se carga el listado de departamentos del control Picker
            cargarListaDpto();
            
        }

        private async void cargarListaDpto()
        {
            DepartmentList = await DepartmentHandlerBL.getDepartmentList();
        }

    }
}
