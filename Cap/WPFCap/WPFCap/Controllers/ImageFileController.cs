using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace WPFCap.Controllers
{
    public static class ImageFileController
    {

        private static string GetImageFolderStr(string selectedFolder)
        {
            string ImageDirectory = Path.Combine(Directory.GetCurrentDirectory(), "DefaultImages");
            return  $"{ImageDirectory}\\{selectedFolder}";

        }

        public static Collection<ImageSource> GetImageList(string selectedFolder)
        {
            string filePath = GetImageFolderStr(selectedFolder);

            Collection<ImageSource> DisplayImageList = new Collection<ImageSource>();

            if (Directory.Exists(filePath)) {
                string[] imageFiles = Directory.GetFiles(filePath,"*.*");

                foreach (string fileName in imageFiles)
                {
                    BitmapImage bitmap = new BitmapImage();
                    bitmap.BeginInit();
                    bitmap.UriSource = new Uri(fileName);
                    bitmap.CacheOption = BitmapCacheOption.OnLoad;
                    bitmap.EndInit();

                    DisplayImageList.Add(bitmap);
                }
            }
            return DisplayImageList;
        }

        
    }
}
