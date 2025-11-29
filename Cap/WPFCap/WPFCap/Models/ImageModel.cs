using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using WPFCap.Controllers;
using WPFCap.Models.Interfaces;

namespace WPFCap.Models
{
    public class ImageModel:ICollectionModel
    {
        public string _filePath { get; set; }
        public string FilePath
        {
            get
            {
                return _filePath;
            }
            set
            {
                _filePath = value;
                Image = FileController.GetImageSource(FilePath);
            }
        }
        public int Id { get; }

        public string Title { get; set; }
        public ImageSource Image { get; private set; }



        public ImageModel(string filePath)
        {
            Id = 0;
            Title = "New Image";
            FilePath = filePath;
        }
    }
}
