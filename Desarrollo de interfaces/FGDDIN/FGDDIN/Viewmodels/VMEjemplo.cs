using FernandoGironDominguezDIN.ViewModels.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FernandoGironDominguezDIN.Viewmodels
{
    public class VMEjemplo : VMBase
    {
        private DelegateCommand ejemploCommand;
        public DelegateCommand EjemploCommand
        {
            get
            {
                ejemploCommand = new DelegateCommand(EjemploCommand_Execute,
                    EjemploCommand_CanExecute);
                return ejemploCommand;
            }
        }


        #region Commands

        #region ejemploCommand

        private void EjemploCommand_Execute()
        {
            //Código a ejecutar
        }

        private bool EjemploCommand_CanExecute()
        {
            //Para que se notifique el cambio de estado del CanExecute (algo ha hecho que ahora
            //se pueda/no se pueda ejecutar el command), hay que usar:
            //ejemploCommand.RaiseCanExecuteChanged();
            return true;
        }

        #endregion

        #endregion

    }
}
