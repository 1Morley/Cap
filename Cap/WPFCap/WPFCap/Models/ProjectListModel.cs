using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFCap.Controllers;

namespace WPFCap.Models
{
    public class ProjectListModel : PageListController<ProjectModel>
    {
        public ProjectListModel() : base(new ObservableCollection<ProjectModel>(), 4)
        {}
    }
}
