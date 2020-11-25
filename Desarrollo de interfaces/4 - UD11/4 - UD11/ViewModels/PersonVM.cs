using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _4___UD11___Entities;

namespace _4___UD11.ViewModels
{
    //Esta clase debe ser public pero da un error extraño
      public class PersonVM : clsVMBase
    {
        public ObservableCollection<Person> PersonList { get; set; }
        public ObservableCollection<Person> PersonListBy { get; set; }
        public Person PersonFocus { get; set; }
        public string SearchTextPerson { get; set; }

        #region Commands
        private DelegateCommand _commandUpdate;
        public DelegateCommand CommandUpdate
        {
            get
            {

            }

            set
            {
               
            }
        }

        private DelegateCommand _commandDelete;
        public DelegateCommand CommandDelete
        {
            get
            {

            }

            set
            {

            }
        }
        private DelegateCommand _commandInsert;
        public DelegateCommand CommandInsert
        {
            get
            {

            }

            set
            {

            }
        }
        #endregion
    }
}
