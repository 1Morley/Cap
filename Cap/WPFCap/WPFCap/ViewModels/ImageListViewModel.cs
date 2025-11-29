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
 public class ImageListViewModel
: PageSelectViewModel<ImageModel>
    {
        public ObservableCollection<ImageModel> ShownList
        {
            get
            {
                return GetModelList();
            }
        }

        

        public RelayCommand AddImageToList { get; private set; }

        public ImageListViewModel() :
            base(new ImageModelList())
        {
            AddImageToList = new RelayCommand(x =>
            {
                ImageModel added = FileController.AddCoverImageToList();
                AddBasicModel(added);        
            });
        }
    }
}
