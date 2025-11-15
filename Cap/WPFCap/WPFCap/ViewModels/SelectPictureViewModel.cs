using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Printing;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Media3D;
using WPFCap.Controllers;
using WPFCap.Models;

namespace WPFCap.ViewModels
{
    public class SelectPictureViewModel: PageSelectViewModel<ImageSource>
    {
        public ObservableCollection<ImageSource> ShownList { get; private set; }

        public const int AmountOfItemsPerPage = 4;
        public SelectPictureViewModel() : 
            base(ImageFileController.GetImageList("CoverImages"), new ObservableCollection<ImageSource>(), AmountOfItemsPerPage)
        {
            ShownList = GetShownList();
        }

    }
}
