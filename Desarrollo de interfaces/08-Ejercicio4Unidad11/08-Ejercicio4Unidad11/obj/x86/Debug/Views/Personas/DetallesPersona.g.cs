﻿#pragma checksum "C:\Users\Francisco Javier\Desktop\GitHub\DEINT\08-Ejercicio4Unidad11\08-Ejercicio4Unidad11\Views\Personas\DetallesPersona.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "BDE3BBBE2C3DDFF240F86E294A8B1EC0"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace _08_Ejercicio4Unidad11.Views.Personas
{
    partial class DetallesPersona : 
        global::Windows.UI.Xaml.Controls.Page, 
        global::Windows.UI.Xaml.Markup.IComponentConnector,
        global::Windows.UI.Xaml.Markup.IComponentConnector2
    {
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 10.0.18362.1")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        private static class XamlBindingSetters
        {
            public static void Set_Windows_UI_Xaml_Controls_Primitives_ButtonBase_Command(global::Windows.UI.Xaml.Controls.Primitives.ButtonBase obj, global::System.Windows.Input.ICommand value, string targetNullValue)
            {
                if (value == null && targetNullValue != null)
                {
                    value = (global::System.Windows.Input.ICommand) global::Windows.UI.Xaml.Markup.XamlBindingHelper.ConvertValue(typeof(global::System.Windows.Input.ICommand), targetNullValue);
                }
                obj.Command = value;
            }
            public static void Set_Windows_UI_Xaml_Controls_TextBox_Text(global::Windows.UI.Xaml.Controls.TextBox obj, global::System.String value, string targetNullValue)
            {
                if (value == null && targetNullValue != null)
                {
                    value = targetNullValue;
                }
                obj.Text = value ?? global::System.String.Empty;
            }
            public static void Set_Windows_UI_Xaml_Controls_ItemsControl_ItemsSource(global::Windows.UI.Xaml.Controls.ItemsControl obj, global::System.Object value, string targetNullValue)
            {
                if (value == null && targetNullValue != null)
                {
                    value = (global::System.Object) global::Windows.UI.Xaml.Markup.XamlBindingHelper.ConvertValue(typeof(global::System.Object), targetNullValue);
                }
                obj.ItemsSource = value;
            }
            public static void Set_Windows_UI_Xaml_Controls_Primitives_Selector_SelectedItem(global::Windows.UI.Xaml.Controls.Primitives.Selector obj, global::System.Object value, string targetNullValue)
            {
                if (value == null && targetNullValue != null)
                {
                    value = (global::System.Object) global::Windows.UI.Xaml.Markup.XamlBindingHelper.ConvertValue(typeof(global::System.Object), targetNullValue);
                }
                obj.SelectedItem = value;
            }
        };

        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 10.0.18362.1")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        private class DetallesPersona_obj1_Bindings :
            global::Windows.UI.Xaml.Markup.IDataTemplateComponent,
            global::Windows.UI.Xaml.Markup.IXamlBindScopeDiagnostics,
            global::Windows.UI.Xaml.Markup.IComponentConnector,
            IDetallesPersona_Bindings
        {
            private global::_08_Ejercicio4Unidad11.Views.Personas.DetallesPersona dataRoot;
            private bool initialized = false;
            private const int NOT_PHASED = (1 << 31);
            private const int DATA_CHANGED = (1 << 30);

            // Fields for each control that has bindings.
            private global::Windows.UI.Xaml.Controls.Button obj3;
            private global::Windows.UI.Xaml.Controls.Button obj4;
            private global::Windows.UI.Xaml.Controls.TextBox obj6;
            private global::Windows.UI.Xaml.Controls.TextBox obj7;
            private global::Windows.UI.Xaml.Controls.TextBox obj8;
            private global::Windows.UI.Xaml.Controls.TextBox obj9;
            private global::Windows.UI.Xaml.Controls.TextBox obj10;
            private global::Windows.UI.Xaml.Controls.ComboBox obj11;

            // Static fields for each binding's enabled/disabled state
            private static bool isobj3CommandDisabled = false;
            private static bool isobj4CommandDisabled = false;
            private static bool isobj6TextDisabled = false;
            private static bool isobj7TextDisabled = false;
            private static bool isobj8TextDisabled = false;
            private static bool isobj9TextDisabled = false;
            private static bool isobj10TextDisabled = false;
            private static bool isobj11ItemsSourceDisabled = false;
            private static bool isobj11SelectedItemDisabled = false;

            private DetallesPersona_obj1_BindingsTracking bindingsTracking;

            public DetallesPersona_obj1_Bindings()
            {
                this.bindingsTracking = new DetallesPersona_obj1_BindingsTracking(this);
            }

            public void Disable(int lineNumber, int columnNumber)
            {
                if (lineNumber == 73 && columnNumber == 87)
                {
                    isobj3CommandDisabled = true;
                }
                else if (lineNumber == 74 && columnNumber == 70)
                {
                    isobj4CommandDisabled = true;
                }
                else if (lineNumber == 34 && columnNumber == 51)
                {
                    isobj6TextDisabled = true;
                }
                else if (lineNumber == 38 && columnNumber == 51)
                {
                    isobj7TextDisabled = true;
                }
                else if (lineNumber == 42 && columnNumber == 51)
                {
                    isobj8TextDisabled = true;
                }
                else if (lineNumber == 46 && columnNumber == 51)
                {
                    isobj9TextDisabled = true;
                }
                else if (lineNumber == 50 && columnNumber == 51)
                {
                    isobj10TextDisabled = true;
                }
                else if (lineNumber == 54 && columnNumber == 52)
                {
                    isobj11ItemsSourceDisabled = true;
                }
                else if (lineNumber == 55 && columnNumber == 23)
                {
                    isobj11SelectedItemDisabled = true;
                }
            }

            // IComponentConnector

            public void Connect(int connectionId, global::System.Object target)
            {
                switch(connectionId)
                {
                    case 3: // Views\Personas\DetallesPersona.xaml line 73
                        this.obj3 = (global::Windows.UI.Xaml.Controls.Button)target;
                        break;
                    case 4: // Views\Personas\DetallesPersona.xaml line 74
                        this.obj4 = (global::Windows.UI.Xaml.Controls.Button)target;
                        break;
                    case 6: // Views\Personas\DetallesPersona.xaml line 34
                        this.obj6 = (global::Windows.UI.Xaml.Controls.TextBox)target;
                        this.bindingsTracking.RegisterTwoWayListener_6(this.obj6);
                        break;
                    case 7: // Views\Personas\DetallesPersona.xaml line 38
                        this.obj7 = (global::Windows.UI.Xaml.Controls.TextBox)target;
                        this.bindingsTracking.RegisterTwoWayListener_7(this.obj7);
                        break;
                    case 8: // Views\Personas\DetallesPersona.xaml line 42
                        this.obj8 = (global::Windows.UI.Xaml.Controls.TextBox)target;
                        this.bindingsTracking.RegisterTwoWayListener_8(this.obj8);
                        break;
                    case 9: // Views\Personas\DetallesPersona.xaml line 46
                        this.obj9 = (global::Windows.UI.Xaml.Controls.TextBox)target;
                        this.bindingsTracking.RegisterTwoWayListener_9(this.obj9);
                        break;
                    case 10: // Views\Personas\DetallesPersona.xaml line 50
                        this.obj10 = (global::Windows.UI.Xaml.Controls.TextBox)target;
                        this.bindingsTracking.RegisterTwoWayListener_10(this.obj10);
                        break;
                    case 11: // Views\Personas\DetallesPersona.xaml line 54
                        this.obj11 = (global::Windows.UI.Xaml.Controls.ComboBox)target;
                        this.bindingsTracking.RegisterTwoWayListener_11(this.obj11);
                        break;
                    default:
                        break;
                }
            }

            // IDataTemplateComponent

            public void ProcessBindings(global::System.Object item, int itemIndex, int phase, out int nextPhase)
            {
                nextPhase = -1;
            }

            public void Recycle()
            {
                return;
            }

            // IDetallesPersona_Bindings

            public void Initialize()
            {
                if (!this.initialized)
                {
                    this.Update();
                }
            }
            
            public void Update()
            {
                this.Update_(this.dataRoot, NOT_PHASED);
                this.initialized = true;
            }

            public void StopTracking()
            {
                this.bindingsTracking.ReleaseAllListeners();
                this.initialized = false;
            }

            public void DisconnectUnloadedObject(int connectionId)
            {
                throw new global::System.ArgumentException("No unloadable elements to disconnect.");
            }

            public bool SetDataRoot(global::System.Object newDataRoot)
            {
                this.bindingsTracking.ReleaseAllListeners();
                if (newDataRoot != null)
                {
                    this.dataRoot = (global::_08_Ejercicio4Unidad11.Views.Personas.DetallesPersona)newDataRoot;
                    return true;
                }
                return false;
            }

            public void Loading(global::Windows.UI.Xaml.FrameworkElement src, object data)
            {
                this.Initialize();
            }

            // Update methods for each path node used in binding steps.
            private void Update_(global::_08_Ejercicio4Unidad11.Views.Personas.DetallesPersona obj, int phase)
            {
                if (obj != null)
                {
                    if ((phase & (NOT_PHASED | DATA_CHANGED | (1 << 0))) != 0)
                    {
                        this.Update_VMVistaDetallesPersona(obj.VMVistaDetallesPersona, phase);
                    }
                }
            }
            private void Update_VMVistaDetallesPersona(global::_08_Ejercicio4Unidad11.ViewModels.VMPersonas.VMVistaDetallesPersona obj, int phase)
            {
                if (obj != null)
                {
                    if ((phase & (NOT_PHASED | (1 << 0))) != 0)
                    {
                        this.Update_VMVistaDetallesPersona_ComandoGuardarPersona(obj.ComandoGuardarPersona, phase);
                        this.Update_VMVistaDetallesPersona_ComandoEliminarPersona(obj.ComandoEliminarPersona, phase);
                    }
                    if ((phase & (NOT_PHASED | DATA_CHANGED | (1 << 0))) != 0)
                    {
                        this.Update_VMVistaDetallesPersona_PersonaSeleccionada(obj.PersonaSeleccionada, phase);
                    }
                    if ((phase & (NOT_PHASED | (1 << 0))) != 0)
                    {
                        this.Update_VMVistaDetallesPersona_Departamentos(obj.Departamentos, phase);
                    }
                    if ((phase & (NOT_PHASED | DATA_CHANGED | (1 << 0))) != 0)
                    {
                        this.Update_VMVistaDetallesPersona_DepartamentoPersonaSeleccionada(obj.DepartamentoPersonaSeleccionada, phase);
                    }
                }
            }
            private void Update_VMVistaDetallesPersona_ComandoGuardarPersona(global::_08_Ejercicio4Unidad11.Models.DelegateCommand obj, int phase)
            {
                if ((phase & ((1 << 0) | NOT_PHASED )) != 0)
                {
                    // Views\Personas\DetallesPersona.xaml line 73
                    if (!isobj3CommandDisabled)
                    {
                        XamlBindingSetters.Set_Windows_UI_Xaml_Controls_Primitives_ButtonBase_Command(this.obj3, obj, null);
                    }
                }
            }
            private void Update_VMVistaDetallesPersona_ComandoEliminarPersona(global::_08_Ejercicio4Unidad11.Models.DelegateCommand obj, int phase)
            {
                if ((phase & ((1 << 0) | NOT_PHASED )) != 0)
                {
                    // Views\Personas\DetallesPersona.xaml line 74
                    if (!isobj4CommandDisabled)
                    {
                        XamlBindingSetters.Set_Windows_UI_Xaml_Controls_Primitives_ButtonBase_Command(this.obj4, obj, null);
                    }
                }
            }
            private void Update_VMVistaDetallesPersona_PersonaSeleccionada(global::_08_Ejercicio4Unidad11.Models.ClsPersonaConDepartamento obj, int phase)
            {
                if (obj != null)
                {
                    if ((phase & (NOT_PHASED | DATA_CHANGED | (1 << 0))) != 0)
                    {
                        this.Update_VMVistaDetallesPersona_PersonaSeleccionada_Nombre(obj.Nombre, phase);
                        this.Update_VMVistaDetallesPersona_PersonaSeleccionada_Apellidos(obj.Apellidos, phase);
                        this.Update_VMVistaDetallesPersona_PersonaSeleccionada_FechaNacimiento(obj.FechaNacimiento, phase);
                        this.Update_VMVistaDetallesPersona_PersonaSeleccionada_Direccion(obj.Direccion, phase);
                        this.Update_VMVistaDetallesPersona_PersonaSeleccionada_Telefono(obj.Telefono, phase);
                    }
                }
            }
            private void Update_VMVistaDetallesPersona_PersonaSeleccionada_Nombre(global::System.String obj, int phase)
            {
                if ((phase & ((1 << 0) | NOT_PHASED | DATA_CHANGED)) != 0)
                {
                    // Views\Personas\DetallesPersona.xaml line 34
                    if (!isobj6TextDisabled)
                    {
                        XamlBindingSetters.Set_Windows_UI_Xaml_Controls_TextBox_Text(this.obj6, obj, null);
                    }
                }
            }
            private void Update_VMVistaDetallesPersona_PersonaSeleccionada_Apellidos(global::System.String obj, int phase)
            {
                if ((phase & ((1 << 0) | NOT_PHASED | DATA_CHANGED)) != 0)
                {
                    // Views\Personas\DetallesPersona.xaml line 38
                    if (!isobj7TextDisabled)
                    {
                        XamlBindingSetters.Set_Windows_UI_Xaml_Controls_TextBox_Text(this.obj7, obj, null);
                    }
                }
            }
            private void Update_VMVistaDetallesPersona_PersonaSeleccionada_FechaNacimiento(global::System.DateTime obj, int phase)
            {
                if ((phase & ((1 << 0) | NOT_PHASED | DATA_CHANGED)) != 0)
                {
                    // Views\Personas\DetallesPersona.xaml line 42
                    if (!isobj8TextDisabled)
                    {
                        XamlBindingSetters.Set_Windows_UI_Xaml_Controls_TextBox_Text(this.obj8, obj.ToString(), null);
                    }
                }
            }
            private void Update_VMVistaDetallesPersona_PersonaSeleccionada_Direccion(global::System.String obj, int phase)
            {
                if ((phase & ((1 << 0) | NOT_PHASED | DATA_CHANGED)) != 0)
                {
                    // Views\Personas\DetallesPersona.xaml line 46
                    if (!isobj9TextDisabled)
                    {
                        XamlBindingSetters.Set_Windows_UI_Xaml_Controls_TextBox_Text(this.obj9, obj, null);
                    }
                }
            }
            private void Update_VMVistaDetallesPersona_PersonaSeleccionada_Telefono(global::System.String obj, int phase)
            {
                if ((phase & ((1 << 0) | NOT_PHASED | DATA_CHANGED)) != 0)
                {
                    // Views\Personas\DetallesPersona.xaml line 50
                    if (!isobj10TextDisabled)
                    {
                        XamlBindingSetters.Set_Windows_UI_Xaml_Controls_TextBox_Text(this.obj10, obj, null);
                    }
                }
            }
            private void Update_VMVistaDetallesPersona_Departamentos(global::System.Collections.ObjectModel.ObservableCollection<global::_08_Ejercicio4Unidad11_Entity.ClsDepartamento> obj, int phase)
            {
                if ((phase & ((1 << 0) | NOT_PHASED )) != 0)
                {
                    // Views\Personas\DetallesPersona.xaml line 54
                    if (!isobj11ItemsSourceDisabled)
                    {
                        XamlBindingSetters.Set_Windows_UI_Xaml_Controls_ItemsControl_ItemsSource(this.obj11, obj, null);
                    }
                }
            }
            private void Update_VMVistaDetallesPersona_DepartamentoPersonaSeleccionada(global::_08_Ejercicio4Unidad11_Entity.ClsDepartamento obj, int phase)
            {
                if ((phase & ((1 << 0) | NOT_PHASED | DATA_CHANGED)) != 0)
                {
                    // Views\Personas\DetallesPersona.xaml line 54
                    if (!isobj11SelectedItemDisabled)
                    {
                        XamlBindingSetters.Set_Windows_UI_Xaml_Controls_Primitives_Selector_SelectedItem(this.obj11, obj, null);
                    }
                }
            }
            private void UpdateTwoWay_6_Text()
            {
                if (this.initialized)
                {
                    if (this.dataRoot != null)
                    {
                        if (this.dataRoot.VMVistaDetallesPersona != null)
                        {
                            if (this.dataRoot.VMVistaDetallesPersona.PersonaSeleccionada != null)
                            {
                                this.dataRoot.VMVistaDetallesPersona.PersonaSeleccionada.Nombre = this.obj6.Text;
                            }
                        }
                    }
                }
            }
            private void UpdateTwoWay_7_Text()
            {
                if (this.initialized)
                {
                    if (this.dataRoot != null)
                    {
                        if (this.dataRoot.VMVistaDetallesPersona != null)
                        {
                            if (this.dataRoot.VMVistaDetallesPersona.PersonaSeleccionada != null)
                            {
                                this.dataRoot.VMVistaDetallesPersona.PersonaSeleccionada.Apellidos = this.obj7.Text;
                            }
                        }
                    }
                }
            }
            private void UpdateTwoWay_8_Text()
            {
                if (this.initialized)
                {
                    if (this.dataRoot != null)
                    {
                        if (this.dataRoot.VMVistaDetallesPersona != null)
                        {
                            if (this.dataRoot.VMVistaDetallesPersona.PersonaSeleccionada != null)
                            {
                                this.dataRoot.VMVistaDetallesPersona.PersonaSeleccionada.FechaNacimiento = (global::System.DateTime) global::Windows.UI.Xaml.Markup.XamlBindingHelper.ConvertValue(typeof(global::System.DateTime), this.obj8.Text);
                            }
                        }
                    }
                }
            }
            private void UpdateTwoWay_9_Text()
            {
                if (this.initialized)
                {
                    if (this.dataRoot != null)
                    {
                        if (this.dataRoot.VMVistaDetallesPersona != null)
                        {
                            if (this.dataRoot.VMVistaDetallesPersona.PersonaSeleccionada != null)
                            {
                                this.dataRoot.VMVistaDetallesPersona.PersonaSeleccionada.Direccion = this.obj9.Text;
                            }
                        }
                    }
                }
            }
            private void UpdateTwoWay_10_Text()
            {
                if (this.initialized)
                {
                    if (this.dataRoot != null)
                    {
                        if (this.dataRoot.VMVistaDetallesPersona != null)
                        {
                            if (this.dataRoot.VMVistaDetallesPersona.PersonaSeleccionada != null)
                            {
                                this.dataRoot.VMVistaDetallesPersona.PersonaSeleccionada.Telefono = this.obj10.Text;
                            }
                        }
                    }
                }
            }
            private void UpdateTwoWay_11_SelectedItem()
            {
                if (this.initialized)
                {
                    if (this.dataRoot != null)
                    {
                        if (this.dataRoot.VMVistaDetallesPersona != null)
                        {
                            this.dataRoot.VMVistaDetallesPersona.DepartamentoPersonaSeleccionada = (global::_08_Ejercicio4Unidad11_Entity.ClsDepartamento)this.obj11.SelectedItem;
                        }
                    }
                }
            }

            [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 10.0.18362.1")]
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            private class DetallesPersona_obj1_BindingsTracking
            {
                private global::System.WeakReference<DetallesPersona_obj1_Bindings> weakRefToBindingObj; 

                public DetallesPersona_obj1_BindingsTracking(DetallesPersona_obj1_Bindings obj)
                {
                    weakRefToBindingObj = new global::System.WeakReference<DetallesPersona_obj1_Bindings>(obj);
                }

                public DetallesPersona_obj1_Bindings TryGetBindingObject()
                {
                    DetallesPersona_obj1_Bindings bindingObject = null;
                    if (weakRefToBindingObj != null)
                    {
                        weakRefToBindingObj.TryGetTarget(out bindingObject);
                        if (bindingObject == null)
                        {
                            weakRefToBindingObj = null;
                            ReleaseAllListeners();
                        }
                    }
                    return bindingObject;
                }

                public void ReleaseAllListeners()
                {
                }

                public void RegisterTwoWayListener_6(global::Windows.UI.Xaml.Controls.TextBox sourceObject)
                {
                    sourceObject.RegisterPropertyChangedCallback(global::Windows.UI.Xaml.Controls.TextBox.TextProperty, (sender, prop) =>
                    {
                        var bindingObj = this.TryGetBindingObject();
                        if (bindingObj != null)
                        {
                            bindingObj.UpdateTwoWay_6_Text();
                        }
                    });
                }
                public void RegisterTwoWayListener_7(global::Windows.UI.Xaml.Controls.TextBox sourceObject)
                {
                    sourceObject.RegisterPropertyChangedCallback(global::Windows.UI.Xaml.Controls.TextBox.TextProperty, (sender, prop) =>
                    {
                        var bindingObj = this.TryGetBindingObject();
                        if (bindingObj != null)
                        {
                            bindingObj.UpdateTwoWay_7_Text();
                        }
                    });
                }
                public void RegisterTwoWayListener_8(global::Windows.UI.Xaml.Controls.TextBox sourceObject)
                {
                    sourceObject.RegisterPropertyChangedCallback(global::Windows.UI.Xaml.Controls.TextBox.TextProperty, (sender, prop) =>
                    {
                        var bindingObj = this.TryGetBindingObject();
                        if (bindingObj != null)
                        {
                            bindingObj.UpdateTwoWay_8_Text();
                        }
                    });
                }
                public void RegisterTwoWayListener_9(global::Windows.UI.Xaml.Controls.TextBox sourceObject)
                {
                    sourceObject.RegisterPropertyChangedCallback(global::Windows.UI.Xaml.Controls.TextBox.TextProperty, (sender, prop) =>
                    {
                        var bindingObj = this.TryGetBindingObject();
                        if (bindingObj != null)
                        {
                            bindingObj.UpdateTwoWay_9_Text();
                        }
                    });
                }
                public void RegisterTwoWayListener_10(global::Windows.UI.Xaml.Controls.TextBox sourceObject)
                {
                    sourceObject.RegisterPropertyChangedCallback(global::Windows.UI.Xaml.Controls.TextBox.TextProperty, (sender, prop) =>
                    {
                        var bindingObj = this.TryGetBindingObject();
                        if (bindingObj != null)
                        {
                            bindingObj.UpdateTwoWay_10_Text();
                        }
                    });
                }
                public void RegisterTwoWayListener_11(global::Windows.UI.Xaml.Controls.ComboBox sourceObject)
                {
                    sourceObject.RegisterPropertyChangedCallback(global::Windows.UI.Xaml.Controls.Primitives.Selector.SelectedItemProperty, (sender, prop) =>
                    {
                        var bindingObj = this.TryGetBindingObject();
                        if (bindingObj != null)
                        {
                            bindingObj.UpdateTwoWay_11_SelectedItem();
                        }
                    });
                }
            }
        }
        /// <summary>
        /// Connect()
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 10.0.18362.1")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void Connect(int connectionId, object target)
        {
            switch(connectionId)
            {
            case 2: // Views\Personas\DetallesPersona.xaml line 15
                {
                    this.gridPropiedades = (global::Windows.UI.Xaml.Controls.Grid)(target);
                }
                break;
            case 5: // Views\Personas\DetallesPersona.xaml line 30
                {
                    this.imagen = (global::Windows.UI.Xaml.Controls.Image)(target);
                }
                break;
            default:
                break;
            }
            this._contentLoaded = true;
        }

        /// <summary>
        /// GetBindingConnector(int connectionId, object target)
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 10.0.18362.1")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public global::Windows.UI.Xaml.Markup.IComponentConnector GetBindingConnector(int connectionId, object target)
        {
            global::Windows.UI.Xaml.Markup.IComponentConnector returnValue = null;
            switch(connectionId)
            {
            case 1: // Views\Personas\DetallesPersona.xaml line 1
                {                    
                    global::Windows.UI.Xaml.Controls.Page element1 = (global::Windows.UI.Xaml.Controls.Page)target;
                    DetallesPersona_obj1_Bindings bindings = new DetallesPersona_obj1_Bindings();
                    returnValue = bindings;
                    bindings.SetDataRoot(this);
                    this.Bindings = bindings;
                    element1.Loading += bindings.Loading;
                    global::Windows.UI.Xaml.Markup.XamlBindingHelper.SetDataTemplateComponent(element1, bindings);
                }
                break;
            }
            return returnValue;
        }
    }
}
