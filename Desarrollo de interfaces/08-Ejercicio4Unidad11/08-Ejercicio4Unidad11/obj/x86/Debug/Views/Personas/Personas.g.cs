﻿#pragma checksum "C:\Users\Francisco Javier\Desktop\GitHub\DEINT\08-Ejercicio4Unidad11\08-Ejercicio4Unidad11\Views\Personas\Personas.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "EAD98976B53516FB6300F34C3C7574F5"
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
    partial class Personas : 
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
            public static void Set_Windows_UI_Xaml_Controls_MenuFlyoutItem_Command(global::Windows.UI.Xaml.Controls.MenuFlyoutItem obj, global::System.Windows.Input.ICommand value, string targetNullValue)
            {
                if (value == null && targetNullValue != null)
                {
                    value = (global::System.Windows.Input.ICommand) global::Windows.UI.Xaml.Markup.XamlBindingHelper.ConvertValue(typeof(global::System.Windows.Input.ICommand), targetNullValue);
                }
                obj.Command = value;
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
            public static void Set_Windows_UI_Xaml_Controls_TextBox_Text(global::Windows.UI.Xaml.Controls.TextBox obj, global::System.String value, string targetNullValue)
            {
                if (value == null && targetNullValue != null)
                {
                    value = targetNullValue;
                }
                obj.Text = value ?? global::System.String.Empty;
            }
        };

        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 10.0.18362.1")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        private class Personas_obj1_Bindings :
            global::Windows.UI.Xaml.Markup.IDataTemplateComponent,
            global::Windows.UI.Xaml.Markup.IXamlBindScopeDiagnostics,
            global::Windows.UI.Xaml.Markup.IComponentConnector,
            IPersonas_Bindings
        {
            private global::_08_Ejercicio4Unidad11.Views.Personas.Personas dataRoot;
            private bool initialized = false;
            private const int NOT_PHASED = (1 << 31);
            private const int DATA_CHANGED = (1 << 30);

            // Fields for each control that has bindings.
            private global::Windows.UI.Xaml.Controls.AppBarButton obj6;
            private global::Windows.UI.Xaml.Controls.AppBarButton obj7;
            private global::Windows.UI.Xaml.Controls.AppBarButton obj8;
            private global::Windows.UI.Xaml.Controls.GridView obj10;
            private global::Windows.UI.Xaml.Controls.MenuFlyoutItem obj12;
            private global::Windows.UI.Xaml.Controls.TextBox obj18;
            private global::Windows.UI.Xaml.Controls.Button obj19;

            // Static fields for each binding's enabled/disabled state
            private static bool isobj6CommandDisabled = false;
            private static bool isobj7CommandDisabled = false;
            private static bool isobj8CommandDisabled = false;
            private static bool isobj10ItemsSourceDisabled = false;
            private static bool isobj10SelectedItemDisabled = false;
            private static bool isobj12CommandDisabled = false;
            private static bool isobj18TextDisabled = false;
            private static bool isobj19CommandDisabled = false;

            private Personas_obj1_BindingsTracking bindingsTracking;

            public Personas_obj1_Bindings()
            {
                this.bindingsTracking = new Personas_obj1_BindingsTracking(this);
            }

            public void Disable(int lineNumber, int columnNumber)
            {
                if (lineNumber == 37 && columnNumber == 72)
                {
                    isobj6CommandDisabled = true;
                }
                else if (lineNumber == 44 && columnNumber == 76)
                {
                    isobj7CommandDisabled = true;
                }
                else if (lineNumber == 51 && columnNumber == 80)
                {
                    isobj8CommandDisabled = true;
                }
                else if (lineNumber == 71 && columnNumber == 100)
                {
                    isobj10ItemsSourceDisabled = true;
                }
                else if (lineNumber == 72 && columnNumber == 19)
                {
                    isobj10SelectedItemDisabled = true;
                }
                else if (lineNumber == 82 && columnNumber == 53)
                {
                    isobj12CommandDisabled = true;
                }
                else if (lineNumber == 62 && columnNumber == 25)
                {
                    isobj18TextDisabled = true;
                }
                else if (lineNumber == 64 && columnNumber == 37)
                {
                    isobj19CommandDisabled = true;
                }
            }

            // IComponentConnector

            public void Connect(int connectionId, global::System.Object target)
            {
                switch(connectionId)
                {
                    case 6: // Views\Personas\Personas.xaml line 37
                        this.obj6 = (global::Windows.UI.Xaml.Controls.AppBarButton)target;
                        break;
                    case 7: // Views\Personas\Personas.xaml line 44
                        this.obj7 = (global::Windows.UI.Xaml.Controls.AppBarButton)target;
                        break;
                    case 8: // Views\Personas\Personas.xaml line 51
                        this.obj8 = (global::Windows.UI.Xaml.Controls.AppBarButton)target;
                        break;
                    case 10: // Views\Personas\Personas.xaml line 70
                        this.obj10 = (global::Windows.UI.Xaml.Controls.GridView)target;
                        this.bindingsTracking.RegisterTwoWayListener_10(this.obj10);
                        break;
                    case 12: // Views\Personas\Personas.xaml line 82
                        this.obj12 = (global::Windows.UI.Xaml.Controls.MenuFlyoutItem)target;
                        break;
                    case 18: // Views\Personas\Personas.xaml line 61
                        this.obj18 = (global::Windows.UI.Xaml.Controls.TextBox)target;
                        this.bindingsTracking.RegisterTwoWayListener_18(this.obj18);
                        break;
                    case 19: // Views\Personas\Personas.xaml line 64
                        this.obj19 = (global::Windows.UI.Xaml.Controls.Button)target;
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

            // IPersonas_Bindings

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
                    this.dataRoot = (global::_08_Ejercicio4Unidad11.Views.Personas.Personas)newDataRoot;
                    return true;
                }
                return false;
            }

            public void Loading(global::Windows.UI.Xaml.FrameworkElement src, object data)
            {
                this.Initialize();
            }

            // Update methods for each path node used in binding steps.
            private void Update_(global::_08_Ejercicio4Unidad11.Views.Personas.Personas obj, int phase)
            {
                if (obj != null)
                {
                    if ((phase & (NOT_PHASED | DATA_CHANGED | (1 << 0))) != 0)
                    {
                        this.Update_VMVistaPersonas(obj.VMVistaPersonas, phase);
                    }
                }
            }
            private void Update_VMVistaPersonas(global::_08_Ejercicio4Unidad11.ViewModels.VMVistaPersonas obj, int phase)
            {
                this.bindingsTracking.UpdateChildListeners_VMVistaPersonas(obj);
                if (obj != null)
                {
                    if ((phase & (NOT_PHASED | (1 << 0))) != 0)
                    {
                        this.Update_VMVistaPersonas_ComandoAnadirPersonas(obj.ComandoAnadirPersonas, phase);
                        this.Update_VMVistaPersonas_ComandoEliminarPersona(obj.ComandoEliminarPersona, phase);
                        this.Update_VMVistaPersonas_ComandoActualizarPersonas(obj.ComandoActualizarPersonas, phase);
                    }
                    if ((phase & (NOT_PHASED | DATA_CHANGED | (1 << 0))) != 0)
                    {
                        this.Update_VMVistaPersonas_ListadoFiltrado(obj.ListadoFiltrado, phase);
                        this.Update_VMVistaPersonas_PersonaSeleccionada(obj.PersonaSeleccionada, phase);
                        this.Update_VMVistaPersonas_Buscador(obj.Buscador, phase);
                    }
                    if ((phase & (NOT_PHASED | (1 << 0))) != 0)
                    {
                        this.Update_VMVistaPersonas_ComandoBuscarPersona(obj.ComandoBuscarPersona, phase);
                    }
                }
            }
            private void Update_VMVistaPersonas_ComandoAnadirPersonas(global::_08_Ejercicio4Unidad11.Models.DelegateCommand obj, int phase)
            {
                if ((phase & ((1 << 0) | NOT_PHASED )) != 0)
                {
                    // Views\Personas\Personas.xaml line 37
                    if (!isobj6CommandDisabled)
                    {
                        XamlBindingSetters.Set_Windows_UI_Xaml_Controls_Primitives_ButtonBase_Command(this.obj6, obj, null);
                    }
                }
            }
            private void Update_VMVistaPersonas_ComandoEliminarPersona(global::_08_Ejercicio4Unidad11.Models.DelegateCommand obj, int phase)
            {
                if ((phase & ((1 << 0) | NOT_PHASED )) != 0)
                {
                    // Views\Personas\Personas.xaml line 44
                    if (!isobj7CommandDisabled)
                    {
                        XamlBindingSetters.Set_Windows_UI_Xaml_Controls_Primitives_ButtonBase_Command(this.obj7, obj, null);
                    }
                    // Views\Personas\Personas.xaml line 82
                    if (!isobj12CommandDisabled)
                    {
                        XamlBindingSetters.Set_Windows_UI_Xaml_Controls_MenuFlyoutItem_Command(this.obj12, obj, null);
                    }
                }
            }
            private void Update_VMVistaPersonas_ComandoActualizarPersonas(global::_08_Ejercicio4Unidad11.Models.DelegateCommand obj, int phase)
            {
                if ((phase & ((1 << 0) | NOT_PHASED )) != 0)
                {
                    // Views\Personas\Personas.xaml line 51
                    if (!isobj8CommandDisabled)
                    {
                        XamlBindingSetters.Set_Windows_UI_Xaml_Controls_Primitives_ButtonBase_Command(this.obj8, obj, null);
                    }
                }
            }
            private void Update_VMVistaPersonas_ListadoFiltrado(global::System.Collections.ObjectModel.ObservableCollection<global::_08_Ejercicio4Unidad11.Models.ClsPersonaConDepartamento> obj, int phase)
            {
                this.bindingsTracking.UpdateChildListeners_VMVistaPersonas_ListadoFiltrado(obj);
                if ((phase & ((1 << 0) | NOT_PHASED | DATA_CHANGED)) != 0)
                {
                    // Views\Personas\Personas.xaml line 70
                    if (!isobj10ItemsSourceDisabled)
                    {
                        XamlBindingSetters.Set_Windows_UI_Xaml_Controls_ItemsControl_ItemsSource(this.obj10, obj, null);
                    }
                }
            }
            private void Update_VMVistaPersonas_PersonaSeleccionada(global::_08_Ejercicio4Unidad11.Models.ClsPersonaConDepartamento obj, int phase)
            {
                if ((phase & ((1 << 0) | NOT_PHASED | DATA_CHANGED)) != 0)
                {
                    // Views\Personas\Personas.xaml line 70
                    if (!isobj10SelectedItemDisabled)
                    {
                        XamlBindingSetters.Set_Windows_UI_Xaml_Controls_Primitives_Selector_SelectedItem(this.obj10, obj, null);
                    }
                }
            }
            private void Update_VMVistaPersonas_Buscador(global::System.String obj, int phase)
            {
                if ((phase & ((1 << 0) | NOT_PHASED | DATA_CHANGED)) != 0)
                {
                    // Views\Personas\Personas.xaml line 61
                    if (!isobj18TextDisabled)
                    {
                        XamlBindingSetters.Set_Windows_UI_Xaml_Controls_TextBox_Text(this.obj18, obj, null);
                    }
                }
            }
            private void Update_VMVistaPersonas_ComandoBuscarPersona(global::_08_Ejercicio4Unidad11.Models.DelegateCommand obj, int phase)
            {
                if ((phase & ((1 << 0) | NOT_PHASED )) != 0)
                {
                    // Views\Personas\Personas.xaml line 64
                    if (!isobj19CommandDisabled)
                    {
                        XamlBindingSetters.Set_Windows_UI_Xaml_Controls_Primitives_ButtonBase_Command(this.obj19, obj, null);
                    }
                }
            }
            private void UpdateTwoWay_10_SelectedItem()
            {
                if (this.initialized)
                {
                    if (this.dataRoot != null)
                    {
                        if (this.dataRoot.VMVistaPersonas != null)
                        {
                            this.dataRoot.VMVistaPersonas.PersonaSeleccionada = (global::_08_Ejercicio4Unidad11.Models.ClsPersonaConDepartamento)this.obj10.SelectedItem;
                        }
                    }
                }
            }
            private void UpdateTwoWay_18_Text()
            {
                if (this.initialized)
                {
                    if (this.dataRoot != null)
                    {
                        if (this.dataRoot.VMVistaPersonas != null)
                        {
                            this.dataRoot.VMVistaPersonas.Buscador = this.obj18.Text;
                        }
                    }
                }
            }

            [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 10.0.18362.1")]
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            private class Personas_obj1_BindingsTracking
            {
                private global::System.WeakReference<Personas_obj1_Bindings> weakRefToBindingObj; 

                public Personas_obj1_BindingsTracking(Personas_obj1_Bindings obj)
                {
                    weakRefToBindingObj = new global::System.WeakReference<Personas_obj1_Bindings>(obj);
                }

                public Personas_obj1_Bindings TryGetBindingObject()
                {
                    Personas_obj1_Bindings bindingObject = null;
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
                    UpdateChildListeners_VMVistaPersonas(null);
                    UpdateChildListeners_VMVistaPersonas_ListadoFiltrado(null);
                }

                public void PropertyChanged_VMVistaPersonas(object sender, global::System.ComponentModel.PropertyChangedEventArgs e)
                {
                    Personas_obj1_Bindings bindings = TryGetBindingObject();
                    if (bindings != null)
                    {
                        string propName = e.PropertyName;
                        global::_08_Ejercicio4Unidad11.ViewModels.VMVistaPersonas obj = sender as global::_08_Ejercicio4Unidad11.ViewModels.VMVistaPersonas;
                        if (global::System.String.IsNullOrEmpty(propName))
                        {
                            if (obj != null)
                            {
                                bindings.Update_VMVistaPersonas_ListadoFiltrado(obj.ListadoFiltrado, DATA_CHANGED);
                                bindings.Update_VMVistaPersonas_PersonaSeleccionada(obj.PersonaSeleccionada, DATA_CHANGED);
                                bindings.Update_VMVistaPersonas_Buscador(obj.Buscador, DATA_CHANGED);
                            }
                        }
                        else
                        {
                            switch (propName)
                            {
                                case "ListadoFiltrado":
                                {
                                    if (obj != null)
                                    {
                                        bindings.Update_VMVistaPersonas_ListadoFiltrado(obj.ListadoFiltrado, DATA_CHANGED);
                                    }
                                    break;
                                }
                                case "PersonaSeleccionada":
                                {
                                    if (obj != null)
                                    {
                                        bindings.Update_VMVistaPersonas_PersonaSeleccionada(obj.PersonaSeleccionada, DATA_CHANGED);
                                    }
                                    break;
                                }
                                case "Buscador":
                                {
                                    if (obj != null)
                                    {
                                        bindings.Update_VMVistaPersonas_Buscador(obj.Buscador, DATA_CHANGED);
                                    }
                                    break;
                                }
                                default:
                                    break;
                            }
                        }
                    }
                }
                private global::_08_Ejercicio4Unidad11.ViewModels.VMVistaPersonas cache_VMVistaPersonas = null;
                public void UpdateChildListeners_VMVistaPersonas(global::_08_Ejercicio4Unidad11.ViewModels.VMVistaPersonas obj)
                {
                    if (obj != cache_VMVistaPersonas)
                    {
                        if (cache_VMVistaPersonas != null)
                        {
                            ((global::System.ComponentModel.INotifyPropertyChanged)cache_VMVistaPersonas).PropertyChanged -= PropertyChanged_VMVistaPersonas;
                            cache_VMVistaPersonas = null;
                        }
                        if (obj != null)
                        {
                            cache_VMVistaPersonas = obj;
                            ((global::System.ComponentModel.INotifyPropertyChanged)obj).PropertyChanged += PropertyChanged_VMVistaPersonas;
                        }
                    }
                }
                public void PropertyChanged_VMVistaPersonas_ListadoFiltrado(object sender, global::System.ComponentModel.PropertyChangedEventArgs e)
                {
                    Personas_obj1_Bindings bindings = TryGetBindingObject();
                    if (bindings != null)
                    {
                        string propName = e.PropertyName;
                        global::System.Collections.ObjectModel.ObservableCollection<global::_08_Ejercicio4Unidad11.Models.ClsPersonaConDepartamento> obj = sender as global::System.Collections.ObjectModel.ObservableCollection<global::_08_Ejercicio4Unidad11.Models.ClsPersonaConDepartamento>;
                        if (global::System.String.IsNullOrEmpty(propName))
                        {
                        }
                        else
                        {
                            switch (propName)
                            {
                                default:
                                    break;
                            }
                        }
                    }
                }
                public void CollectionChanged_VMVistaPersonas_ListadoFiltrado(object sender, global::System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
                {
                    Personas_obj1_Bindings bindings = TryGetBindingObject();
                    if (bindings != null)
                    {
                        global::System.Collections.ObjectModel.ObservableCollection<global::_08_Ejercicio4Unidad11.Models.ClsPersonaConDepartamento> obj = sender as global::System.Collections.ObjectModel.ObservableCollection<global::_08_Ejercicio4Unidad11.Models.ClsPersonaConDepartamento>;
                    }
                }
                private global::System.Collections.ObjectModel.ObservableCollection<global::_08_Ejercicio4Unidad11.Models.ClsPersonaConDepartamento> cache_VMVistaPersonas_ListadoFiltrado = null;
                public void UpdateChildListeners_VMVistaPersonas_ListadoFiltrado(global::System.Collections.ObjectModel.ObservableCollection<global::_08_Ejercicio4Unidad11.Models.ClsPersonaConDepartamento> obj)
                {
                    if (obj != cache_VMVistaPersonas_ListadoFiltrado)
                    {
                        if (cache_VMVistaPersonas_ListadoFiltrado != null)
                        {
                            ((global::System.ComponentModel.INotifyPropertyChanged)cache_VMVistaPersonas_ListadoFiltrado).PropertyChanged -= PropertyChanged_VMVistaPersonas_ListadoFiltrado;
                            ((global::System.Collections.Specialized.INotifyCollectionChanged)cache_VMVistaPersonas_ListadoFiltrado).CollectionChanged -= CollectionChanged_VMVistaPersonas_ListadoFiltrado;
                            cache_VMVistaPersonas_ListadoFiltrado = null;
                        }
                        if (obj != null)
                        {
                            cache_VMVistaPersonas_ListadoFiltrado = obj;
                            ((global::System.ComponentModel.INotifyPropertyChanged)obj).PropertyChanged += PropertyChanged_VMVistaPersonas_ListadoFiltrado;
                            ((global::System.Collections.Specialized.INotifyCollectionChanged)obj).CollectionChanged += CollectionChanged_VMVistaPersonas_ListadoFiltrado;
                        }
                    }
                }
                public void RegisterTwoWayListener_10(global::Windows.UI.Xaml.Controls.GridView sourceObject)
                {
                    sourceObject.RegisterPropertyChangedCallback(global::Windows.UI.Xaml.Controls.Primitives.Selector.SelectedItemProperty, (sender, prop) =>
                    {
                        var bindingObj = this.TryGetBindingObject();
                        if (bindingObj != null)
                        {
                            bindingObj.UpdateTwoWay_10_SelectedItem();
                        }
                    });
                }
                public void RegisterTwoWayListener_18(global::Windows.UI.Xaml.Controls.TextBox sourceObject)
                {
                    sourceObject.RegisterPropertyChangedCallback(global::Windows.UI.Xaml.Controls.TextBox.TextProperty, (sender, prop) =>
                    {
                        var bindingObj = this.TryGetBindingObject();
                        if (bindingObj != null)
                        {
                            bindingObj.UpdateTwoWay_18_Text();
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
            case 2: // Views\Personas\Personas.xaml line 14
                {
                    this.VisualStateGroup = (global::Windows.UI.Xaml.VisualStateGroup)(target);
                }
                break;
            case 3: // Views\Personas\Personas.xaml line 15
                {
                    this.VistaGrande = (global::Windows.UI.Xaml.VisualState)(target);
                }
                break;
            case 4: // Views\Personas\Personas.xaml line 20
                {
                    this.VistaPequena = (global::Windows.UI.Xaml.VisualState)(target);
                }
                break;
            case 5: // Views\Personas\Personas.xaml line 33
                {
                    this.titulo = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 6: // Views\Personas\Personas.xaml line 37
                {
                    this.btnAnadir = (global::Windows.UI.Xaml.Controls.AppBarButton)(target);
                }
                break;
            case 7: // Views\Personas\Personas.xaml line 44
                {
                    this.btnEliminar = (global::Windows.UI.Xaml.Controls.AppBarButton)(target);
                }
                break;
            case 8: // Views\Personas\Personas.xaml line 51
                {
                    this.btnActualizar = (global::Windows.UI.Xaml.Controls.AppBarButton)(target);
                }
                break;
            case 9: // Views\Personas\Personas.xaml line 59
                {
                    this.buscador = (global::Windows.UI.Xaml.Controls.StackPanel)(target);
                }
                break;
            case 10: // Views\Personas\Personas.xaml line 70
                {
                    global::Windows.UI.Xaml.Controls.GridView element10 = (global::Windows.UI.Xaml.Controls.GridView)(target);
                    ((global::Windows.UI.Xaml.Controls.GridView)element10).DoubleTapped += this.entrarOpcionesPersona;
                    ((global::Windows.UI.Xaml.Controls.GridView)element10).RightTapped += this.GridView_RightTapped;
                }
                break;
            case 11: // Views\Personas\Personas.xaml line 81
                {
                    this.menuFluout = (global::Windows.UI.Xaml.Controls.MenuFlyout)(target);
                }
                break;
            case 18: // Views\Personas\Personas.xaml line 61
                {
                    this.txtvBuscador = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            case 19: // Views\Personas\Personas.xaml line 64
                {
                    this.buscar = (global::Windows.UI.Xaml.Controls.Button)(target);
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
            case 1: // Views\Personas\Personas.xaml line 1
                {                    
                    global::Windows.UI.Xaml.Controls.Page element1 = (global::Windows.UI.Xaml.Controls.Page)target;
                    Personas_obj1_Bindings bindings = new Personas_obj1_Bindings();
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

