using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using WPFCap.Models;
using WPFCap.Models.SaveModel;

namespace WPFCap.Controllers
{
    public static class FileController
    {
        private static readonly JsonSerializerOptions _jsonOptions = new()
        {
            WriteIndented = true,
        };

        private static string GetSelectedImageFolderStr(string selectedFolder)
        {
            string ImageDirectory = GetDefaultImageFolderStr();
            return  $"{ImageDirectory}\\{selectedFolder}";
        }
        private static string GetDefaultImageFolderStr()
        {
            return Path.Combine(Directory.GetCurrentDirectory(), "DefaultImages");
        }

        //public static Collection<ImageSource> GetImageList(string selectedFolder)
        //{
        //    string filePath = GetSelectedImageFolderStr(selectedFolder);

        //    Collection<ImageSource> DisplayImageList = new Collection<ImageSource>();

        //    if (Directory.Exists(filePath)) {
        //        string[] imageFiles = Directory.GetFiles(filePath,"*.*");

        //        foreach (string FileName in imageFiles)
        //        {
        //            DisplayImageList.Add(GetImage(FileName));
        //        }
        //    }
        //    return DisplayImageList;
        //}
        public static Collection<ImageModel> GetImageList(string selectedFolder)
        {
            string filePath = GetSelectedImageFolderStr(selectedFolder);

            Collection<ImageModel> DisplayImageList = new Collection<ImageModel>();

            if (Directory.Exists(filePath)) {
                string[] imageFiles = Directory.GetFiles(filePath,"*.*");

                foreach (string fileName in imageFiles)
                {

                    DisplayImageList.Add(new ImageModel(fileName));
                }
            }
            return DisplayImageList;
        }

        public static ImageModel GetEmptyImage()
        {
            string ImageDirectory = GetDefaultImageFolderStr();
            string fileName = $"{ImageDirectory}\\DefaultMissingImage.png";

            return new ImageModel(fileName);
        }

        public static ImageSource GetImage(string fileName)
        {
            if (File.Exists(fileName))
            {
                BitmapImage bitmap = new BitmapImage();
                bitmap.BeginInit();
                bitmap.UriSource = new Uri(fileName);
                bitmap.CacheOption = BitmapCacheOption.OnLoad;
                bitmap.EndInit();

                return bitmap;
            }
            return null;
        }

        public static bool InputLocalFile(out string fileName)
        {
            var dialog = new Microsoft.Win32.OpenFileDialog();
            dialog.FileName = "test";
            dialog.DefaultExt = ".txt";
            bool? result = dialog.ShowDialog();
            if (result == true)
            {
                fileName = dialog.FileName;
                return true;
            }
            fileName = string.Empty;
            return false;
        }


        public static async void SaveFile(Collection<ProjectModel> input)
        {
            try
            {
                Collection<ProjectSaveFile> saveFile = new Collection<ProjectSaveFile>();
                foreach (var model in input)
                {
                    ProjectSaveFile save = new ProjectSaveFile(model);
                    saveFile.Add(save);
                }

                using FileStream stream = File.Create("SaveTest.json");
                await JsonSerializer.SerializeAsync(stream, saveFile, _jsonOptions);
            }
            catch { }

        }

        public static ObservableCollection<ProjectModel> LoadFile()
        {
            if (File.Exists("SaveTest.json"))
            {
                try
                {
                    using FileStream stream = File.OpenRead("SaveTest.json");
                    ObservableCollection<ProjectSaveFile> saveFile = JsonSerializer.Deserialize<ObservableCollection<ProjectSaveFile>>(stream, _jsonOptions);
                    ObservableCollection < ProjectModel > returnList = new ObservableCollection<ProjectModel >();
                    int index = 0;
                    foreach (var model in saveFile)
                    {
                        returnList.Add(model.ConvertBack(index++));
                    }
                    return returnList;
                }
                catch { }
            }

            return new ObservableCollection<ProjectModel>();

        }
    }
}
