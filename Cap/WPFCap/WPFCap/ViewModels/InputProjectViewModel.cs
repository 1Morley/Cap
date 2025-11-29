using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFCap.Models.InputModels;

namespace WPFCap.ViewModels
{
    public class InputProjectViewModel
    {
        public InputProjectModel InputModel { get; set; }

        public ImageListViewModel ImageListVM { get; set; }
        public InputProjectViewModel() 
        {
            InputModel = new InputProjectModel();
            ImageListVM = new ImageListViewModel();
        }

        public bool ValidInputModel(out InputProjectModel project)
        {
            project = InputModel;
            project.CoverImage = ImageListVM.SelectedItem;
            return true;
        }
    }
}
