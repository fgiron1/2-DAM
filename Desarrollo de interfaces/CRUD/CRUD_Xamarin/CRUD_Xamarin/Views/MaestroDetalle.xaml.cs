using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CRUD_Xamarin.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MaestroDetalle : MasterDetailPage
    {
        public MaestroDetalle()
        {
            InitializeComponent();
            Detail = new NavigationPage(new Empleados());
            IsPresented = true;
        }

        //Estos event handlers no los necesitaremos porque 
        //la funcionalidad que incluyen nosotros la implementamos
        //a través de commands
        private void Button_Clicked(object sender, EventArgs e)
        {
            Detail = new NavigationPage(new Empleados());
            IsPresented = false;
        }
        private void Button_Clicked2(object sender, EventArgs e)
        {
            Detail = new NavigationPage(new Departamentos());
            IsPresented = false;
        }

    }
}