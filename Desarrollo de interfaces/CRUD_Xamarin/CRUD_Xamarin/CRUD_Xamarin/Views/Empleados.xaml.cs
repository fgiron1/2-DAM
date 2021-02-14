﻿using CRUD_Xamarin.ViewModels;
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
    public partial class Empleados : ContentPage
    {
        public VMEmpleados VM { get; }

        public Empleados()
        {
            InitializeComponent();
            VM = new VMEmpleados();
        }
    }
}