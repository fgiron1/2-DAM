using _08_Ejercicio4Unidad11_BL.Listado;
using _08_Ejercicio4Unidad11_Entity;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

namespace _08_Ejercicio4Unidad11.Models
{
    class ClsListadoPersonasConDepartamento
    {

        private ObservableCollection<ClsPersona> listadoPersonas;
        private ObservableCollection<ClsDepartamento> listadoDepartamentos;

        /// <summary>
        /// Obtener las personas relaccionadas con los departamentos.
        /// </summary>

        public ObservableCollection<ClsPersonaConDepartamento> PersonasConDepartamentos
        {
            get
            {

                try
                {
                    ListadosPersonasBL listadoPersonasBL = new ListadosPersonasBL();
                    listadoPersonas = new ObservableCollection<ClsPersona>(listadoPersonasBL.listadoPersonas());

                    ListadosDepartamentosBL listadoDepartamentosBL = new ListadosDepartamentosBL();
                    listadoDepartamentos = new ObservableCollection<ClsDepartamento>(listadoDepartamentosBL.listadoDepartamentos());
                }
                catch (SqlException e)
                {
                    throw e;
                }

                return relaccionarPersonasConDepartamentos();

            }
        }

        /// <summary>
        /// Devuelve un ObservableCollection de las personas relaccionadas con sus departamentos.
        /// </summary>
        /// <returns></returns>

        private ObservableCollection<ClsPersonaConDepartamento> relaccionarPersonasConDepartamentos()
        {

            ObservableCollection<ClsPersonaConDepartamento> listadoPersonasConDepartamento = new ObservableCollection<ClsPersonaConDepartamento>();
            ClsPersonaConDepartamento personaConDepartamento;
            ClsDepartamento departamento;
            int IdDepartamento;

            if (listadoPersonas != null)
            {
                for (int i = 0; i < listadoPersonas.Count; i++)
                {

                    IdDepartamento = listadoPersonas[i].IdDepartamento;
                    departamento = new ClsDepartamento();

                    departamento = new ObservableCollection<ClsDepartamento>(from depar in listadoDepartamentos where (depar.Id) == IdDepartamento select depar)[0];

                    personaConDepartamento = new ClsPersonaConDepartamento(listadoPersonas[i].Id, listadoPersonas[i].Nombre, listadoPersonas[i].Apellidos, listadoPersonas[i].FechaNacimiento, listadoPersonas[i].Foto, listadoPersonas[i].Direccion, listadoPersonas[i].Telefono, departamento);
                    listadoPersonasConDepartamento.Add(personaConDepartamento);
                }
            }

            return listadoPersonasConDepartamento;

        }


        /// <summary>
        /// Lanza el ContentDialog de error de conexion.
        /// </summary>

        public async void lanzarDialogAsync()
        {

            ContentDialog noWifiDialog = new ContentDialog
            {
                Title = "Error",
                Content = "No se ha podido obtener las personas. Intentelo más tarde",
                CloseButtonText = "Ok"
            };

            await noWifiDialog.ShowAsync();

        }

    }
}
