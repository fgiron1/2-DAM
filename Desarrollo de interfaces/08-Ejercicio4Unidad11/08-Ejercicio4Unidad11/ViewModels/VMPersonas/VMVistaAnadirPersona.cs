using _08_Ejercicio4Unidad11.Models;
using _08_Ejercicio4Unidad11_BL.Gestora;
using _08_Ejercicio4Unidad11_BL.Listado;
using _08_Ejercicio4Unidad11_Entity;
using System;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Linq;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace _08_Ejercicio4Unidad11.ViewModels.VMPersonas
{
    class VMVistaAnadirPersona
    {

        #region atributos

        private ClsPersonaConDepartamento personaSeleccionada;
        private ObservableCollection<ClsDepartamento> departamentos;
        private DelegateCommand comandoGuardarPersona;

        #endregion atributos


        #region constructores

        /// <summary>
        /// Inicializa los atributos necesarios para funcionar.
        /// </summary>

        public VMVistaAnadirPersona()
        {
            ListadosDepartamentosBL listadosDepartamentosBL = new ListadosDepartamentosBL();
            departamentos = new ObservableCollection<ClsDepartamento>(listadosDepartamentosBL.listadoDepartamentos());
            personaSeleccionada = new ClsPersonaConDepartamento();
            comandoGuardarPersona = new DelegateCommand(comandoGuardarExecute);
        }

        #endregion constructores


        #region propiedades

        /// <summary>
        /// Devuelve los departamentos.
        /// </summary>

        public ObservableCollection<ClsDepartamento> Departamentos
        {
            get { return departamentos; }
        }

        /// <summary>
        /// Devuelve la persona seleccionada.
        /// </summary>

        public ClsPersonaConDepartamento PersonaSeleccionada
        {
            get
            {
                return personaSeleccionada;
            }
        }

        #endregion propiedades


        #region commands

        /// <summary>
        /// Devuelve el comando de guardar la persona.
        /// </summary>

        public DelegateCommand ComandoGuardarPersona
        {
            get { return comandoGuardarPersona; }
        }

        /// <summary>
        /// Añade a la persona que se a introducido.
        /// </summary>

        private void comandoGuardarExecute()
        {
            GestoraPersonaBL gestora = new GestoraPersonaBL();
            ClsPersona persona = new ClsPersona(personaSeleccionada.Id, personaSeleccionada.Nombre, personaSeleccionada.Apellidos, personaSeleccionada.FechaNacimiento, personaSeleccionada.Foto, personaSeleccionada.Direccion, personaSeleccionada.Telefono, personaSeleccionada.Departamento.Id);

            try
            {
                gestora.anadirPersona(persona);
                Frame frame = Window.Current.Content as Frame;
                frame.Navigate(typeof(Views.Personas.Personas));
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
                Content = "No se ha podido obtener las personas. Intentelo más tarde",
                CloseButtonText = "Ok"
            };

            await noWifiDialog.ShowAsync();

        }
        #endregion

    }
}
