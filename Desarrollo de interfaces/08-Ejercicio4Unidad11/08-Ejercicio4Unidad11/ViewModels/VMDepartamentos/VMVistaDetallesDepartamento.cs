
using _08_Ejercicio4Unidad11.Models;
using _08_Ejercicio4Unidad11_BL.Gestora;
using _08_Ejercicio4Unidad11_Entity;
using System;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace _08_Ejercicio4Unidad11.ViewModels.VMDepartamentos
{
    class VMVistaDetallesDepartamento
    {

        #region atributos
        private ClsDepartamento departamentoSeleccionado;
        private DelegateCommand comandoGuardarDepartamento;
        private DelegateCommand comandoEliminarDepartamento;
        #endregion


        #region constructores

        /// <summary>
        /// Inicializa los atributos necesarios para funcionar.
        /// </summary>

        public VMVistaDetallesDepartamento()
        {
            departamentoSeleccionado = new ClsDepartamento();
            comandoGuardarDepartamento = new DelegateCommand(comandoGuardarExecute);
            comandoEliminarDepartamento = new DelegateCommand(comandoEliminarExecute, comandoEliminarCanExecute);
        }
        #endregion


        #region propiedades

        /// <summary>
        /// Devuelve/Modifica el departamento seleccionado.
        /// </summary>

        public ClsDepartamento DepartamentoSeleccionado
        {
            get { return departamentoSeleccionado; }
            set { departamentoSeleccionado = value; }
        }
        #endregion

        #region commands

        /// <summary>
        /// Devuelve el comando de eliminar departamento.
        /// </summary>

        public DelegateCommand ComandoEliminarDepartamento
        {

            get
            {
                return comandoEliminarDepartamento;
            }

        }


        /// <summary>
        /// Comprueba si se puede ejecutar el commando
        /// </summary>
        /// <returns></returns>

        private bool comandoEliminarCanExecute()
        {
            bool canExecute = false;

            if (departamentoSeleccionado != null)
            {
                canExecute = true;
            }

            return canExecute;
        }

        /// <summary>
        /// Ejecuta el comando y comprobando si realmente se quiere borrar el departamento.
        /// </summary>

        private async void comandoEliminarExecute()
        {

            ContentDialogResult result = await lanzarDialogEliminarDepartamento();

            if (result == ContentDialogResult.Primary)
            {
                GestoraDepartamentoBL gestora = new GestoraDepartamentoBL();
                int resultado = -1;
                try
                {
                    resultado = gestora.eliminarDepartamento(departamentoSeleccionado.Id);
                    Frame frame = Window.Current.Content as Frame;
                    frame.Navigate(typeof(Views.Departamentos.Departamentos));
                }
                catch (SqlException)
                {
                    if (resultado == -1)
                    {
                        lanzarDialogoNoBorrado();
                    }
                    else
                    {
                        lanzarDialogErrorConexion();
                    }

                }

            }
        }


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
                gestora.modificarDepartamento(departamentoSeleccionado);
                Frame frame = Window.Current.Content as Frame;
                frame.Navigate(typeof(Views.Departamentos.Departamentos));
            }
            catch (SqlException)
            {
                lanzarDialogErrorConexion();
            }

        }

        #endregion

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


        /// <summary>
        /// Lanza el ContentDialog de error de borrado.
        /// </summary>

        public async void lanzarDialogoNoBorrado()
        {

            ContentDialog noWifiDialog = new ContentDialog
            {
                Title = "No se pudo borrar el departamento",
                Content = "No se ha podido borrar el departamento. Asegurese de que no hay personas en ese departamento.",
                CloseButtonText = "Ok"
            };

            await noWifiDialog.ShowAsync();

        }



        /// <summary>
        /// Lanza el ContentDialog de eliminar departamento. Devuelve la respuesta del usuario.
        /// </summary>

        public async Task<ContentDialogResult> lanzarDialogEliminarDepartamento()
        {

            ContentDialog deleteFileDialog = new ContentDialog
            {
                Title = "¿Desea borrar a el departamento?",
                Content = "Se eliminara el departamento permanentemente",
                PrimaryButtonText = "Borrar",
                CloseButtonText = "Cancelar"
            };

            ContentDialogResult result = await deleteFileDialog.ShowAsync();

            return result;

        }

        #endregion

    }
}
