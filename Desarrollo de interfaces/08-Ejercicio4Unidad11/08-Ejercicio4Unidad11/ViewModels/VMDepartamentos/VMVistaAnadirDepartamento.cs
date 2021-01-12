using _08_Ejercicio4Unidad11.Models;
using _08_Ejercicio4Unidad11_BL.Gestora;
using _08_Ejercicio4Unidad11_Entity;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace _08_Ejercicio4Unidad11.ViewModels.VMDepartamentos
{
    class VMVistaAnadirDepartamento
    {

        #region atributos

        private ClsDepartamento departamentoParaAnadir;
        private DelegateCommand comandoGuardarDepartamento;

        #endregion atributos


        #region constructores

        /// <summary>
        /// Inicia las propiedades a los valores necesarios para que funcione.
        /// </summary>

        public VMVistaAnadirDepartamento()
        {
            departamentoParaAnadir = new ClsDepartamento();
            comandoGuardarDepartamento = new DelegateCommand(comandoGuardarExecute);
        }

        #endregion constructores


        #region propiedades

        /// <summary>
        /// Devuelve el departamento a añadir.
        /// </summary>

        public ClsDepartamento DepartamentoParaAnadir
        {
            get
            {
                return departamentoParaAnadir;
            }
        }

        #endregion propiedades


        #region commands

        /// <summary>
        /// Devuelve el comando de guardar el departamento.
        /// </summary>

        public DelegateCommand ComandoGuardarDepartamento
        {
            get { return comandoGuardarDepartamento; }
        }

        /// <summary>
        /// Guarda el departamento en la base de datos y navega hacia la pagina de departamentos.
        /// </summary>

        private void comandoGuardarExecute()
        {
            GestoraDepartamentoBL gestora = new GestoraDepartamentoBL();
            

            try
            {
                gestora.anadirDepartamento(departamentoParaAnadir);
                Frame frame = Window.Current.Content as Frame;
                frame.Navigate(typeof(Views.Departamentos.Departamentos));
            }
            catch (SqlException)
            {
                lanzarDialogErrorConexion();
            }

        }

        #endregion commands


        #region dialogs

        /// <summary>
        /// Lanza el ContentDialog de error de conexion.
        /// </summary>

        public async void lanzarDialogErrorConexion()
        {

            ContentDialog noWifiDialog = new ContentDialog
            {
                Title = "Error",
                Content = "No se ha podido obtener los departamentos. Intentelo más tarde",
                CloseButtonText = "Ok"
            };

            await noWifiDialog.ShowAsync();

        }
        #endregion

    }
}
