using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _4___UD11___Entities;

namespace _4___UD11.ViewModels
{
      public class PersonVM : clsVMBase
    {
        public ObservableCollection<Person> PersonList { get; set; }
        public ObservableCollection<Person> PersonListBy { get; set; }
        public Person PersonFocus
        {
            get
            {
                return PersonFocus;
            }

            set
            {
                PersonFocus = value;
                CommandDelete.RaiseCanExecuteChanged();
                NotifyPropertyChanged("PersonFocus");
            }
        }
        public string SearchTextPerson { get; set; }

        #region Commands

        #region CommandUpdate
        private DelegateCommand _commandUpdate;
        public DelegateCommand CommandUpdate
        {
            get
            {
                _commandUpdate = new DelegateCommand(CommandUpdate_execute, CommandUpdate_canExecute);
                return CommandUpdate;
            }

        }

        public void CommandUpdate_execute()
        {

        }

        public bool CommandUpdate_canExecute(){ return true; }

        #endregion

        #region CommandDelete
        private DelegateCommand _commandDelete;
        public DelegateCommand CommandDelete
        {
            get
            {
                _commandDelete = new DelegateCommand(CommandDelete_execute, CommandDelete_canExecute);
                return CommandDelete;
            }

        }
        private void CommandDelete_execute()
        {
            PersonList.Remove(PersonFocus);
        }

        private bool CommandDelete_canExecute()
        {
            bool canDelete;

            if (PersonFocus == null)
            {
                canDelete = true;
            }
            else
            {
                canDelete = false;
            }

            return canDelete;

        }
        #endregion

        #region CommandInsert
        private DelegateCommand _commandInsert;
        public DelegateCommand CommandInsert
        {
            get
            {
                _commandInsert = new DelegateCommand(CommandInsert_execute, CommandInsert_canExecute);
                return CommandInsert;
            }

        }
        private void CommandInsert_execute()
        {
            //Adds a new empty row to the table for the user to update with actual information
            PersonList.Add(new Person());
        }

        private bool CommandInsert_canExecute()
        {
            //As of now, I think you can always access this option
            return true;
        }
        #endregion
        
        #endregion

        public PersonVM()
        {
            PersonList = new ObservableCollection<Person>();
            this.PersonList.Add(new Person("Fernando", "Nando", new DateTime(), "654000000", "yuju@email.com"));
            this.PersonList.Add(new Person("EEEE", "Nando", new DateTime(), "654000000", "yuju@email.com"));
            this.PersonList.Add(new Person("OOOOOO", "Nando", new DateTime(), "654000000", "yuju@email.com"));

        }

    }
}
