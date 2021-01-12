using _08_Ejercicio4Unidad11.Models;
using _08_Ejercicio4Unidad11.ViewModels;
using _08_Ejercicio4Unidad11.ViewModels.VMPersonas;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Navigation;

// La plantilla de elemento Página en blanco está documentada en https://go.microsoft.com/fwlink/?LinkId=234238

namespace _08_Ejercicio4Unidad11.Views.Personas
{
    /// <summary>
    /// Una página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class Personas : Page
    {
        private VMVistaPersonas VMVistaPersonas;
        private Frame contenido;

        public Personas()
        {
            this.InitializeComponent();
            VMVistaPersonas = new VMVistaPersonas();
        }


        /// <summary>
        /// Metodo para obtener el frame actual.
        /// </summary>
        /// <param name="e"></param>

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            contenido = (Frame)e.Parameter;
        }

        /// <summary>
        /// Navegar hacia la vista DetallesPersona pasandole la persona seleccionada.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void entrarOpcionesPersona(object sender, DoubleTappedRoutedEventArgs e)
        {
            this.contenido.Navigate(typeof(DetallesPersona),VMVistaPersonas.PersonaSeleccionada);
        }


        /// <summary>
        /// Guarda la persona seleccionada en el ViewModel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void GridView_RightTapped(object sender, RightTappedRoutedEventArgs e)
        {
            VMVistaPersonas.PersonaSeleccionada = (ClsPersonaConDepartamento)((FrameworkElement)e.OriginalSource).DataContext;
        }

    }
}
