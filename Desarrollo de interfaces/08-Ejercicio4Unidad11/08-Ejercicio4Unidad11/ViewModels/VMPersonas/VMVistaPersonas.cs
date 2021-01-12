using _08_Ejercicio4Unidad11.Models;
using _08_Ejercicio4Unidad11_BL.Gestora;
using System;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace _08_Ejercicio4Unidad11.ViewModels
{
    class VMVistaPersonas : clsVMBase
    {

        #region atributos
        private ObservableCollection<ClsPersonaConDepartamento> personas;
        private ClsPersonaConDepartamento personaSeleccionada;
        private DelegateCommand comandoEliminarPersona, comandoActualizarPersonas, comandoAnadirPersona, comandoBuscarPersona;
        private string buscador;
        private ObservableCollection<ClsPersonaConDepartamento> listadoFiltrado;
        #endregion


        #region constructores

        /// <summary>
        /// Inicializa los atributos necesarios para funcionar.
        /// </summary>

        public VMVistaPersonas()
        {

            try
            {
                ClsListadoPersonasConDepartamento listadoPersonasConDepartamento = new ClsListadoPersonasConDepartamento();
                personas = listadoPersonasConDepartamento.PersonasConDepartamentos;

            }
            catch (SqlException)
            {
                lanzarDialogErrorConexion();
            }

            comandoEliminarPersona = new DelegateCommand(comandoEliminarExecute, comandoEliminarCanExecute);
            comandoActualizarPersonas = new DelegateCommand(comandoActualizarExecute);
            comandoAnadirPersona = new DelegateCommand(comandoAnadirExecute);
            comandoBuscarPersona = new DelegateCommand(comandoBuscarExecute, comandoBuscarCanExecute);
            personaSeleccionada = null;
            this.listadoFiltrado = new ObservableCollection<ClsPersonaConDepartamento>(personas);
        }

        #endregion


        #region propiedades

        /// <summary>
        /// Devuelve las personas obtenidas.
        /// </summary>

        public ObservableCollection<ClsPersonaConDepartamento> Personas
        {
            get { return personas; }
        }

        /// <summary>
        /// Devuelve/Modifica la persona seleccionada.
        /// </summary>

        public ClsPersonaConDepartamento PersonaSeleccionada
        {
            get
            {
                return personaSeleccionada;
            }

            set
            {
                personaSeleccionada = value;
                comandoEliminarPersona.RaiseCanExecuteChanged();
            }
        }


        /// <summary>
        /// Devuelve el listado filtrado.
        /// </summary>

        public ObservableCollection<ClsPersonaConDepartamento> ListadoFiltrado
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
                comandoBuscarPersona.RaiseCanExecuteChanged();
                if (String.IsNullOrEmpty(buscador))
                {
                    if (listadoFiltrado.Count < personas.Count)
                    {
                        this.listadoFiltrado = new ObservableCollection<ClsPersonaConDepartamento>(personas);
                        NotifyPropertyChanged("ListadoFiltrado");

                    }
                }
            }

        }

        #endregion


        #region commands

        /// <summary>
        /// Devuelve el comando de eliminar persona.
        /// </summary>

        public DelegateCommand ComandoEliminarPersona
        {

            get
            {
                return comandoEliminarPersona;
            }

        }

        /// <summary>
        /// Comprueba si se puede ejecutar el commando
        /// </summary>
        /// <returns></returns>

        private bool comandoEliminarCanExecute()
        {
            bool canExecute = false;

            if (personaSeleccionada != null)
            {
                canExecute = true;
            }

            return canExecute;
        }

        /// <summary>
        /// Ejecuta el comando y comprobando si realmente se quiere borrar la persona.
        /// </summary>

        private async void comandoEliminarExecute()
        {

            ContentDialogResult result = await lanzarDialogEliminarPersona();

            if (result == ContentDialogResult.Primary)
            {
                GestoraPersonaBL gestora = new GestoraPersonaBL();

                try
                {
                    gestora.eliminarPersona(personaSeleccionada.Id);
                    comandoActualizarExecute();
                }
                catch (SqlException)
                {
                    lanzarDialogErrorConexion();
                }

            }
        }

        /// <summary>
        /// Devuelve el comando de actualizar personas.
        /// </summary>

        public DelegateCommand ComandoActualizarPersonas
        {

            get
            {
                return comandoActualizarPersonas;
            }

        }


        /// <summary>
        /// Ejecuta el comando y actualiza las personas.
        /// </summary>

        private void comandoActualizarExecute()
        {

            ClsListadoPersonasConDepartamento listadoPersonasConDepartamento = new ClsListadoPersonasConDepartamento();

            try
            {
                personas = listadoPersonasConDepartamento.PersonasConDepartamentos;
                listadoFiltrado = listadoPersonasConDepartamento.PersonasConDepartamentos;
                NotifyPropertyChanged("ListadoFiltrado");
            }
            catch (SqlException)
            {
                lanzarDialogErrorConexion();
            }

        }



        /// <summary>
        /// Devuelve el comando de actualizar personas.
        /// </summary>

        public DelegateCommand ComandoAnadirPersonas
        {

            get
            {
                return comandoAnadirPersona;
            }

        }



        /// <summary>
        /// Ejecuta el comando abirendo la nueva vista para añadir a una nueva persona.
        /// </summary>

        private void comandoAnadirExecute()
        {
            Frame frame = Window.Current.Content as Frame;
            frame.Navigate(typeof(Views.Personas.AnadirPersona));
        }

        /// <summary>
        /// Devuelve el comando BuscarPersona.
        /// </summary>

        public DelegateCommand ComandoBuscarPersona
        {

            get
            {
                return comandoBuscarPersona;
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

            string nombre, apellido, caracteresPasados;

            foreach (ClsPersonaConDepartamento persona in personas)
            {

                nombre = persona.Nombre.ToUpper();
                apellido = persona.Apellidos.ToUpper();
                caracteresPasados = buscador.ToUpper();

                if (nombre.Contains(caracteresPasados) || apellido.Contains(caracteresPasados))
                {
                    listadoFiltrado.Add(persona);
                }

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
                Content = "No se ha podido obtener las personas. Intentelo más tarde",
                CloseButtonText = "Ok"
            };

            await noWifiDialog.ShowAsync();

        }



        /// <summary>
        /// Lanza el ContentDialog de eliminar persona. Devuelve la respuesta del usuario.
        /// </summary>

        public async Task<ContentDialogResult> lanzarDialogEliminarPersona()
        {

            ContentDialog deleteFileDialog = new ContentDialog
            {
                Title = "¿Desea borrar a la persona?",
                Content = "Se eliminara la persona permanentemente",
                PrimaryButtonText = "Borrar",
                CloseButtonText = "Cancelar"
            };

            ContentDialogResult result = await deleteFileDialog.ShowAsync();

            return result;

        }
 
        #endregion

    }
}