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

namespace _08_Ejercicio4Unidad11.ViewModels.VMPersonas
{
    class VMVistaDetallesPersona
    {
        #region atributos
        private ClsPersonaConDepartamento personaSeleccionada;
        private ObservableCollection<ClsDepartamento> departamentos;
        private DelegateCommand comandoEliminarPersona;
        private DelegateCommand comandoGuardarPersona;
        #endregion

        #region constructores

        /// <summary>
        /// Inicializa los atributos necesarios para funcionar.
        /// </summary>

        public VMVistaDetallesPersona()
        {
            ListadosDepartamentosBL listadosDepartamentosBL = new ListadosDepartamentosBL();
            try
            {
                departamentos = new ObservableCollection<ClsDepartamento>(listadosDepartamentosBL.listadoDepartamentos());
            }
            catch (SqlException)
            {
                lanzarDialogErrorConexion();
            }
            
            personaSeleccionada = null;
            comandoEliminarPersona = new DelegateCommand(comandoEliminarExecute, comandoEliminarCanExecute);
            comandoGuardarPersona = new DelegateCommand(comandoGuardarExecute);
        }

        #endregion


        #region propiedades

        /// <summary>
        /// Devuelve/Modifica la persona seleccionada.
        /// </summary>

        public ClsPersonaConDepartamento PersonaSeleccionada
        {
            get { return personaSeleccionada; }
            set { personaSeleccionada = value; }
        }

        /// <summary>
        /// Devuelve los departamenos.
        /// </summary>

        public ObservableCollection<ClsDepartamento> Departamentos
        {
            get { return departamentos; }
        }

        /// <summary>
        /// Devuelve/Modifica el departamento de la persona seleccionada.
        /// </summary>

        public ClsDepartamento DepartamentoPersonaSeleccionada
        {
            get
            {

                ClsDepartamento departamento = null;
                int IDDepartamento;

                IDDepartamento = personaSeleccionada.Departamento.Id;

                for (int i = 0; i < departamentos.Count; i++)
                {
                    if (departamentos[i].Id == IDDepartamento)
                    {
                        departamento = departamentos[i];
                    }

                }

                return departamento;

            }

            set { personaSeleccionada.Departamento = value; }
        }


        #endregion


        #region commands

        /// <summary>
        /// Devuelve el comando de guardar persona.
        /// </summary>

        public DelegateCommand ComandoGuardarPersona
        {
            get { return comandoGuardarPersona; }
        }

        /// <summary>
        /// Ejecuta el guardado de la persona.
        /// </summary>

        private void comandoGuardarExecute()
        {
            GestoraPersonaBL gestora = new GestoraPersonaBL();
            ClsPersona persona = new ClsPersona(personaSeleccionada.Id, personaSeleccionada.Nombre, personaSeleccionada.Apellidos, personaSeleccionada.FechaNacimiento, personaSeleccionada.Foto, personaSeleccionada.Direccion, personaSeleccionada.Telefono, personaSeleccionada.Departamento.Id);

            try
            {
                gestora.modificarPersona(persona);
                Frame frame = Window.Current.Content as Frame;
                frame.Navigate(typeof(Views.Personas.Personas));
            }
            catch (SqlException)
            {
                lanzarDialogErrorConexion();
            }

        }



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
        /// Comprueba si se puede ejecutar el comando
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
        /// Ejecuta el comando y comprobando si realmente se quiere borrar la persona y devuelve a la lista de personas.
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
                    Frame frame = Window.Current.Content as Frame;
                    frame.Navigate(typeof(Views.Personas.Personas));
                }
                catch (SqlException)
                {
                    lanzarDialogErrorConexion();
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
