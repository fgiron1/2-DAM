using _08_Ejercicio4Unidad11.ViewModels.VMDepartamentos;
using Windows.UI.Xaml.Controls;

// La plantilla de elemento Página en blanco está documentada en https://go.microsoft.com/fwlink/?LinkId=234238

namespace _08_Ejercicio4Unidad11.Views.Departamentos
{
    /// <summary>
    /// Una página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class AnadirDepartamento : Page
    {
        private VMVistaAnadirDepartamento VMVistaAnadirDepartamento;
        public AnadirDepartamento()
        {
            this.InitializeComponent();
            VMVistaAnadirDepartamento = new VMVistaAnadirDepartamento();
        }
    }
}
