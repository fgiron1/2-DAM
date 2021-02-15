using CRUD_Xamarin.ViewModels.Utils;
using CRUD_Xamarin.Views;
using System;
using System.Collections.Generic;
using System.Text;

namespace CRUD_Xamarin.ViewModels
{
    public class VMMaestroDetalleMaster : VMBase
    {
        #region Commands

        #region paginaEmpleadosCommand

        private DelegateCommand paginaEmpleadosCommand;
        public DelegateCommand PaginaEmpleadosCommand
        {
            get
            {
                paginaEmpleadosCommand = new DelegateCommand(
                    PaginaEmpleadosCommand_Execute, PaginaEmpleadosCommand_CanExecute);
                return paginaEmpleadosCommand;
            }
        }

        private bool PaginaEmpleadosCommand_CanExecute() { return true; }
        private void PaginaEmpleadosCommand_Execute()
        {
            Xamarin.Forms.Application.Current.MainPage.Navigation.PushModalAsync(new Empleados());
        }

        #endregion

        #region paginaDepartamentosCommand

        private DelegateCommand paginaDepartamentosCommand;
        public DelegateCommand PaginaDepartamentosCommand
        {
            get
            {
                paginaDepartamentosCommand = new DelegateCommand(
                    PaginaDepartamentosCommand_Execute, PaginaDepartamentosCommand_CanExecute);
                return paginaDepartamentosCommand;
            }
        }

        private bool PaginaDepartamentosCommand_CanExecute() { return true; }
        private void PaginaDepartamentosCommand_Execute()
        {
            Xamarin.Forms.Application.Current.MainPage.Navigation.PushModalAsync(new Departamentos());
        }

        #endregion

        #endregion
    }
}
