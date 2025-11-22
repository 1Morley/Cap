using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using WPFCap.Controllers;

namespace WPFCap.Models
{
    public class ImageModel
    {
        public string _filePath {  get; set; }
        public string FilePath
        {
            get
            {
                return _filePath;
            }
            set
            {
                _filePath = value;
                Image = FileController.GetImage(FilePath);
            }
        }
        public ImageSource Image { get;private set; }

        public ImageModel(string filePath)
        {
            FilePath = filePath;
        }
    }
}
