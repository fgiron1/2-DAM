using _08_Ejercicio4Unidad11.Models;
using _08_Ejercicio4Unidad11_BL.Gestora;
using _08_Ejercicio4Unidad11_BL.Listado;
using _08_Ejercicio4Unidad11_Entity;
using System;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace _08_Ejercicio4Unidad11.ViewModels.VMDepartamentos
{
    class VMVistaDepartamentos : clsVMBase
    {

        #region atributos
        private ObservableCollection<ClsDepartamento> departamentos;
        private ClsDepartamento departamentoSeleccionado;
        private DelegateCommand comandoEliminarDepartamento, comandoActualizarDepartamento, comandoAnadirDepartamento, comandoBuscarDepartamento;
        private string buscador;
        private ObservableCollection<ClsDepartamento> listadoFiltrado;
        #endregion


        #region constructores

        /// <summary>
        /// Inicializa los atributos necesarios para funcionar.
        /// </summary>

        public VMVistaDepartamentos()
        {
            try
            {
                ListadosDepartamentosBL listadosDepartamentosBL = new ListadosDepartamentosBL();
                departamentos = new ObservableCollection<ClsDepartamento>(listadosDepartamentosBL.listadoDepartamentos());
            }
            catch (SqlException)
            {
                lanzarDialogAsync();
            }

            comandoEliminarDepartamento = new DelegateCommand(comandoEliminarExecute, comandoEliminarCanExecute);
            comandoActualizarDepartamento = new DelegateCommand(comandoActualizarExecute);
            comandoAnadirDepartamento = new DelegateCommand(comandoAnadirExecute);
            comandoBuscarDepartamento = new DelegateCommand(comandoBuscarExecute, comandoBuscarCanExecute);
            departamentoSeleccionado = null;
            this.listadoFiltrado = new ObservableCollection<ClsDepartamento>(departamentos);

        }

        #endregion


        #region propiedades

        /// <summary>
        /// Devuelve los departamentos existentes.
        /// </summary>

        public ObservableCollection<ClsDepartamento> Departamentos
        {
            get { return departamentos; }
        }

        /// <summary>
        /// Devuelve/modifica el departamento seleccionado. 
        /// </summary>

        public ClsDepartamento DepartamentoSeleccionado
        {
            get { return departamentoSeleccionado; }

            set
            {
                departamentoSeleccionado = value;
                comandoEliminarDepartamento.RaiseCanExecuteChanged();
            }
        }

        /// <summary>
        /// Devuelve el listado filtrado.
        /// </summary>

        public ObservableCollection<ClsDepartamento> ListadoFiltrado
        {

            get
            {
                return listadoFiltrado;
            }

        }

        /// <summary>
        /// Devuelve/Modifica el valor de la propiedad buscador.
        /// </summary>

        public string Buscador
        {

            get
            {
                return buscador;
            }

            set
            {
                buscador = value;
                comandoBuscarDepartamento.RaiseCanExecuteChanged();
                if (String.IsNullOrEmpty(buscador))
                {
                    if (listadoFiltrado.Count < departamentos.Count)
                    {
                        this.listadoFiltrado = new ObservableCollection<ClsDepartamento>(departamentos);
                        NotifyPropertyChanged("ListadoFiltrado");

                    }
                }
            }

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
                    comandoActualizarExecute();
                }
                catch (SqlException)
                {
                    if (resultado == -1)
                    {
                        lanzarDialogoNoBorrado();
                    }
                    else
                    {
                        lanzarDialogAsync();
                    }

                }

            }
        }

        /// <summary>
        /// Devuelve el comando de actualizar departamentos.
        /// </summary>

        public DelegateCommand ComandoActualizarDepartamento
        {

            get
            {
                return comandoActualizarDepartamento;
            }

        }


        /// <summary>
        /// Ejecuta el comando y actualiza los departamentos.
        /// </summary>

        private void comandoActualizarExecute()
        {

            ListadosDepartamentosBL listados = new ListadosDepartamentosBL();

            try
            {
                departamentos = new ObservableCollection<ClsDepartamento>(listados.listadoDepartamentos());
                listadoFiltrado = new ObservableCollection<ClsDepartamento>(listados.listadoDepartamentos());
            }
            catch (SqlException)
            {
                lanzarDialogAsync();
            }

            NotifyPropertyChanged("ListadoFiltrado");

        }



        /// <summary>
        /// Devuelve el comando de actualizar departamentos.
        /// </summary>

        public DelegateCommand ComandoAnadirDepartamento
        {

            get
            {
                return comandoAnadirDepartamento;
            }

        }



        /// <summary>
        /// Ejecuta el comando abrirendo la nueva vista para añadir a un nuevo departamento.
        /// </summary>

        private void comandoAnadirExecute()
        {
            Frame frame = Window.Current.Content as Frame;
            frame.Navigate(typeof(Views.Departamentos.AnadirDepartamento));
        }

        /// <summary>
        /// Devuelve el comando BuscarPersona.
        /// </summary>

        public DelegateCommand ComandoBuscarDepartamento
        {

            get
            {
                return comandoBuscarDepartamento;
            }

        }

        /// <summary>
        /// Comprueba si se puede ejecutar la busqueda.
        /// </summary>
        /// <returns></returns>

        private bool comandoBuscarCanExecute()
        {
            bool canExecute = false;

            if (!String.IsNullOrEmpty(buscador))
            {
                canExecute = true;
            }

            return canExecute;
        }

        /// <summary>
        /// Ejecuta el comando buscar.
        /// </summary>

        private void comandoBuscarExecute()
        {

            listadoFiltrado.Clear();

            string nombre, caracteresPasados;

            foreach (ClsDepartamento departamento in departamentos)
            {

                nombre = departamento.Nombre.ToUpper();
                caracteresPasados = buscador.ToUpper();

                if (nombre.Contains(caracteresPasados))
                {
                    listadoFiltrado.Add(departamento);
                }

            }

        }

        #endregion


        #region dialogs

        /// <summary>
        /// Lanza el ContentDialog de error de conexion.
        /// </summary>

        public async void lanzarDialogAsync()
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
