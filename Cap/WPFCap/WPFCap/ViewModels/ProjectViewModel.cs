using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFCap.Controllers;
using WPFCap.Models;

namespace WPFCap.ViewModels
{
    public class ProjectViewModel
    {
        public ProjectModel Project { get; private set; }

        public EntryListViewModel EntryListVM { get; private set; }


        public ProjectViewModel (ProjectModel project)
        {
            Project = project;
            EntryListVM = new EntryListViewModel(Project.Id);
        }


    }
}
