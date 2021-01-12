using _08_Ejercicio4Unidad11.ViewModels.VMDepartamentos;
using _08_Ejercicio4Unidad11_Entity;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Navigation;

namespace _08_Ejercicio4Unidad11.Views.Departamentos
{
    /// <summary>
    /// Una página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class Departamentos : Page
    {
        private VMVistaDepartamentos VMVistaDepartamentos;
        Frame contenido;

        public Departamentos()
        {
            this.InitializeComponent();
            VMVistaDepartamentos = new VMVistaDepartamentos();
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

        private void entrarOpcionesDepartamento(object sender, DoubleTappedRoutedEventArgs e)
        {
            this.contenido.Navigate(typeof(DetallesDepartamento), VMVistaDepartamentos.DepartamentoSeleccionado);
        }


        /// <summary>
        /// Guarda la persona seleccionada en el ViewModel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void GridView_RightTapped(object sender, RightTappedRoutedEventArgs e)
        {
            VMVistaDepartamentos.DepartamentoSeleccionado = (ClsDepartamento)((FrameworkElement)e.OriginalSource).DataContext;
        }
    }
}
