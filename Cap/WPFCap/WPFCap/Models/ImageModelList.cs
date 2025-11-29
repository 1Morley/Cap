using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFCap.Controllers;

namespace WPFCap.Models
{
    class ImageModelList: PageListController<ImageModel>
    {
        public ImageModelList() : base(new ObservableCollection<ImageModel>(), 4)
        {
            FullList = (FileController.GetCoverImageList());
        }
    }
}
