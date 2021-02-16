using CRUD_Xamarin.Models;
using CRUD_Xamarin.ViewModels;
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
    public partial class ActualizacionEmpleado : ContentPage
    {
        
        public ActualizacionEmpleado(PersonDepartmentName person)
        {
            InitializeComponent();
            VMActualizacionEmpleado VM =  (VMActualizacionEmpleado) BindingContext;
            VM.InputPerson = person;
        }
    }
}