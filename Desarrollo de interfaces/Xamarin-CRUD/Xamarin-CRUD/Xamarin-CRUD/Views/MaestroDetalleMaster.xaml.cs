using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Xamarin-CRUD.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
public partial class MaestroDetalleMaster : ContentPage
{
    public ListView ListView;

    public MaestroDetalleMaster()
    {
        InitializeComponent();

        BindingContext = new MaestroDetalleMasterViewModel();
        ListView = MenuItemsListView;
    }

    class MaestroDetalleMasterViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<MaestroDetalleMasterMenuItem> MenuItems { get; set; }

        public MaestroDetalleMasterViewModel()
        {
            MenuItems = new ObservableCollection<MaestroDetalleMasterMenuItem>(new[]
            {
                    new MaestroDetalleMasterMenuItem { Id = 0, Title = "Page 1" },
                    new MaestroDetalleMasterMenuItem { Id = 1, Title = "Page 2" },
                    new MaestroDetalleMasterMenuItem { Id = 2, Title = "Page 3" },
                    new MaestroDetalleMasterMenuItem { Id = 3, Title = "Page 4" },
                    new MaestroDetalleMasterMenuItem { Id = 4, Title = "Page 5" },
                });
        }

        #region INotifyPropertyChanged Implementation
        public event PropertyChangedEventHandler PropertyChanged;
        void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            if (PropertyChanged == null)
                return;

            PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
}