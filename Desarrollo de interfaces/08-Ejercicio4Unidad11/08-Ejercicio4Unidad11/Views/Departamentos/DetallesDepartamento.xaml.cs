using _08_Ejercicio4Unidad11.ViewModels.VMDepartamentos;
using _08_Ejercicio4Unidad11_Entity;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

// La plantilla de elemento Página en blanco está documentada en https://go.microsoft.com/fwlink/?LinkId=234238

namespace _08_Ejercicio4Unidad11.Views.Departamentos
{
    /// <summary>
    /// Una página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class DetallesDepartamento : Page
    {
        private VMVistaDetallesDepartamento VMVistaDetallesDepartamento;
        public DetallesDepartamento()
        {
            this.InitializeComponent();
            VMVistaDetallesDepartamento = new VMVistaDetallesDepartamento();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            VMVistaDetallesDepartamento.DepartamentoSeleccionado = (ClsDepartamento)e.Parameter;
        }
    }
}
