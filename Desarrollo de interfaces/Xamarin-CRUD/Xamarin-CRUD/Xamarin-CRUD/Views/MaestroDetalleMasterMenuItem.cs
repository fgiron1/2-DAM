using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xamarin-CRUD.Views
{
    public class MaestroDetalleMasterMenuItem
{
    public MaestroDetalleMasterMenuItem()
    {
        TargetType = typeof(MaestroDetalleMasterMenuItem);
    }
    public int Id { get; set; }
    public string Title { get; set; }

    public Type TargetType { get; set; }
}
}