﻿#pragma checksum "C:\Users\ferna\Desktop\DAM\2-DAM\Desarrollo de interfaces\Parejas\Parejas\View\Tablero.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "89489B29790231EE74F83EF543D30E11"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Parejas.View
{
    partial class Tablero : 
        global::Windows.UI.Xaml.Controls.Page, 
        global::Windows.UI.Xaml.Markup.IComponentConnector,
        global::Windows.UI.Xaml.Markup.IComponentConnector2
    {
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 10.0.18362.1")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        private static class XamlBindingSetters
        {
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
        private class Tablero_obj1_Bindings :
            global::Windows.UI.Xaml.Markup.IDataTemplateComponent,
            global::Windows.UI.Xaml.Markup.IXamlBindScopeDiagnostics,
            global::Windows.UI.Xaml.Markup.IComponentConnector,
            ITablero_Bindings
        {
            private global::Parejas.View.Tablero dataRoot;
            private bool initialized = false;
            private const int NOT_PHASED = (1 << 31);
            private const int DATA_CHANGED = (1 << 30);

            // Fields for each control that has bindings.
            private global::Windows.UI.Xaml.Controls.GridView obj2;

            // Static fields for each binding's enabled/disabled state
            private static bool isobj2ItemsSourceDisabled = false;
            private static bool isobj2SelectedItemDisabled = false;

            private Tablero_obj1_BindingsTracking bindingsTracking;

            public Tablero_obj1_Bindings()
            {
                this.bindingsTracking = new Tablero_obj1_BindingsTracking(this);
            }

            public void Disable(int lineNumber, int columnNumber)
            {
                if (lineNumber == 33 && columnNumber == 20)
                {
                    isobj2ItemsSourceDisabled = true;
                }
                else if (lineNumber == 34 && columnNumber == 20)
                {
                    isobj2SelectedItemDisabled = true;
                }
            }

            // IComponentConnector

            public void Connect(int connectionId, global::System.Object target)
            {
                switch(connectionId)
                {
                    case 2: // View\Tablero.xaml line 32
                        this.obj2 = (global::Windows.UI.Xaml.Controls.GridView)target;
                        this.bindingsTracking.RegisterTwoWayListener_2(this.obj2);
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

            // ITablero_Bindings

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
                    this.dataRoot = (global::Parejas.View.Tablero)newDataRoot;
                    return true;
                }
                return false;
            }

            public void Loading(global::Windows.UI.Xaml.FrameworkElement src, object data)
            {
                this.Initialize();
            }

            // Update methods for each path node used in binding steps.
            private void Update_(global::Parejas.View.Tablero obj, int phase)
            {
                if (obj != null)
                {
                    if ((phase & (NOT_PHASED | DATA_CHANGED | (1 << 0))) != 0)
                    {
                        this.Update_VM(obj.VM, phase);
                    }
                }
            }
            private void Update_VM(global::Parejas.Viewmodel.TableroVM obj, int phase)
            {
                this.bindingsTracking.UpdateChildListeners_VM(obj);
                if (obj != null)
                {
                    if ((phase & (NOT_PHASED | DATA_CHANGED | (1 << 0))) != 0)
                    {
                        this.Update_VM_CartasTablero(obj.CartasTablero, phase);
                        this.Update_VM_Seleccion(obj.Seleccion, phase);
                    }
                }
            }
            private void Update_VM_CartasTablero(global::System.Collections.ObjectModel.ObservableCollection<global::Parejas.Model.Carta> obj, int phase)
            {
                this.bindingsTracking.UpdateChildListeners_VM_CartasTablero(obj);
                if ((phase & ((1 << 0) | NOT_PHASED | DATA_CHANGED)) != 0)
                {
                    // View\Tablero.xaml line 32
                    if (!isobj2ItemsSourceDisabled)
                    {
                        XamlBindingSetters.Set_Windows_UI_Xaml_Controls_ItemsControl_ItemsSource(this.obj2, obj, null);
                    }
                }
            }
            private void Update_VM_Seleccion(global::Parejas.Model.Carta obj, int phase)
            {
                if ((phase & ((1 << 0) | NOT_PHASED | DATA_CHANGED)) != 0)
                {
                    // View\Tablero.xaml line 32
                    if (!isobj2SelectedItemDisabled)
                    {
                        XamlBindingSetters.Set_Windows_UI_Xaml_Controls_Primitives_Selector_SelectedItem(this.obj2, obj, null);
                    }
                }
            }
            private void UpdateTwoWay_2_ItemsSource()
            {
                if (this.initialized)
                {
                    if (this.dataRoot != null)
                    {
                        if (this.dataRoot.VM != null)
                        {
                            this.dataRoot.VM.CartasTablero = (global::System.Collections.ObjectModel.ObservableCollection<global::Parejas.Model.Carta>)this.obj2.ItemsSource;
                        }
                    }
                }
            }

            [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 10.0.18362.1")]
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            private class Tablero_obj1_BindingsTracking
            {
                private global::System.WeakReference<Tablero_obj1_Bindings> weakRefToBindingObj; 

                public Tablero_obj1_BindingsTracking(Tablero_obj1_Bindings obj)
                {
                    weakRefToBindingObj = new global::System.WeakReference<Tablero_obj1_Bindings>(obj);
                }

                public Tablero_obj1_Bindings TryGetBindingObject()
                {
                    Tablero_obj1_Bindings bindingObject = null;
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
                    UpdateChildListeners_VM(null);
                    UpdateChildListeners_VM_CartasTablero(null);
                }

                public void PropertyChanged_VM(object sender, global::System.ComponentModel.PropertyChangedEventArgs e)
                {
                    Tablero_obj1_Bindings bindings = TryGetBindingObject();
                    if (bindings != null)
                    {
                        string propName = e.PropertyName;
                        global::Parejas.Viewmodel.TableroVM obj = sender as global::Parejas.Viewmodel.TableroVM;
                        if (global::System.String.IsNullOrEmpty(propName))
                        {
                            if (obj != null)
                            {
                                bindings.Update_VM_CartasTablero(obj.CartasTablero, DATA_CHANGED);
                                bindings.Update_VM_Seleccion(obj.Seleccion, DATA_CHANGED);
                            }
                        }
                        else
                        {
                            switch (propName)
                            {
                                case "CartasTablero":
                                {
                                    if (obj != null)
                                    {
                                        bindings.Update_VM_CartasTablero(obj.CartasTablero, DATA_CHANGED);
                                    }
                                    break;
                                }
                                case "Seleccion":
                                {
                                    if (obj != null)
                                    {
                                        bindings.Update_VM_Seleccion(obj.Seleccion, DATA_CHANGED);
                                    }
                                    break;
                                }
                                default:
                                    break;
                            }
                        }
                    }
                }
                private global::Parejas.Viewmodel.TableroVM cache_VM = null;
                public void UpdateChildListeners_VM(global::Parejas.Viewmodel.TableroVM obj)
                {
                    if (obj != cache_VM)
                    {
                        if (cache_VM != null)
                        {
                            ((global::System.ComponentModel.INotifyPropertyChanged)cache_VM).PropertyChanged -= PropertyChanged_VM;
                            cache_VM = null;
                        }
                        if (obj != null)
                        {
                            cache_VM = obj;
                            ((global::System.ComponentModel.INotifyPropertyChanged)obj).PropertyChanged += PropertyChanged_VM;
                        }
                    }
                }
                public void PropertyChanged_VM_CartasTablero(object sender, global::System.ComponentModel.PropertyChangedEventArgs e)
                {
                    Tablero_obj1_Bindings bindings = TryGetBindingObject();
                    if (bindings != null)
                    {
                        string propName = e.PropertyName;
                        global::System.Collections.ObjectModel.ObservableCollection<global::Parejas.Model.Carta> obj = sender as global::System.Collections.ObjectModel.ObservableCollection<global::Parejas.Model.Carta>;
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
                public void CollectionChanged_VM_CartasTablero(object sender, global::System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
                {
                    Tablero_obj1_Bindings bindings = TryGetBindingObject();
                    if (bindings != null)
                    {
                        global::System.Collections.ObjectModel.ObservableCollection<global::Parejas.Model.Carta> obj = sender as global::System.Collections.ObjectModel.ObservableCollection<global::Parejas.Model.Carta>;
                    }
                }
                private global::System.Collections.ObjectModel.ObservableCollection<global::Parejas.Model.Carta> cache_VM_CartasTablero = null;
                public void UpdateChildListeners_VM_CartasTablero(global::System.Collections.ObjectModel.ObservableCollection<global::Parejas.Model.Carta> obj)
                {
                    if (obj != cache_VM_CartasTablero)
                    {
                        if (cache_VM_CartasTablero != null)
                        {
                            ((global::System.ComponentModel.INotifyPropertyChanged)cache_VM_CartasTablero).PropertyChanged -= PropertyChanged_VM_CartasTablero;
                            ((global::System.Collections.Specialized.INotifyCollectionChanged)cache_VM_CartasTablero).CollectionChanged -= CollectionChanged_VM_CartasTablero;
                            cache_VM_CartasTablero = null;
                        }
                        if (obj != null)
                        {
                            cache_VM_CartasTablero = obj;
                            ((global::System.ComponentModel.INotifyPropertyChanged)obj).PropertyChanged += PropertyChanged_VM_CartasTablero;
                            ((global::System.Collections.Specialized.INotifyCollectionChanged)obj).CollectionChanged += CollectionChanged_VM_CartasTablero;
                        }
                    }
                }
                public void RegisterTwoWayListener_2(global::Windows.UI.Xaml.Controls.GridView sourceObject)
                {
                    sourceObject.RegisterPropertyChangedCallback(global::Windows.UI.Xaml.Controls.ItemsControl.ItemsSourceProperty, (sender, prop) =>
                    {
                        var bindingObj = this.TryGetBindingObject();
                        if (bindingObj != null)
                        {
                            bindingObj.UpdateTwoWay_2_ItemsSource();
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
            case 4: // View\Tablero.xaml line 39
                {
                    global::Windows.UI.Xaml.Controls.Image element4 = (global::Windows.UI.Xaml.Controls.Image)(target);
                    ((global::Windows.UI.Xaml.Controls.Image)element4).Tapped += this.carta_Tapped;
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
            case 1: // View\Tablero.xaml line 1
                {                    
                    global::Windows.UI.Xaml.Controls.Page element1 = (global::Windows.UI.Xaml.Controls.Page)target;
                    Tablero_obj1_Bindings bindings = new Tablero_obj1_Bindings();
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

