using _08_Ejercicio4Unidad11.Models;
using _08_Ejercicio4Unidad11.ViewModels.VMPersonas;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

// La plantilla de elemento Página en blanco está documentada en https://go.microsoft.com/fwlink/?LinkId=234238

namespace _08_Ejercicio4Unidad11.Views.Personas
{
    /// <summary>
    /// Una página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class DetallesPersona : Page
    {
        private VMVistaDetallesPersona VMVistaDetallesPersona;

        public DetallesPersona()
        {
            this.InitializeComponent();
            VMVistaDetallesPersona = new VMVistaDetallesPersona();
        }

        /// <summary>
        /// Metodo para obtener la ClsPersonaConDepartamento pasado desde otra vista y para obtener el frame actual.
        /// </summary>
        /// <param name="e"></param>

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            VMVistaDetallesPersona.PersonaSeleccionada = (ClsPersonaConDepartamento)e.Parameter;
        }

    }
}
