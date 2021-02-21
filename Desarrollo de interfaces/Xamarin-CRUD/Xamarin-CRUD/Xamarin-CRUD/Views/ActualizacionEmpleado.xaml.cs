using Xamarin_CRUD.Models;
using Xamarin_CRUD.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Xamarin_CRUD.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ActualizacionEmpleado : ContentPage
    {
        public VMActualizacionEmpleado VM { get; }
        public ActualizacionEmpleado(PersonDepartmentName person)
        {
            InitializeComponent();
            VM = new VMActualizacionEmpleado(person);
        }
    }
}