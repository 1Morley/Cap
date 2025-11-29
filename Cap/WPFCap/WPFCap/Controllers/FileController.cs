using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using WPFCap.Models;
using WPFCap.Models.SaveModels;

namespace WPFCap.Controllers
{
    public static class FileController
    {
        private static readonly JsonSerializerOptions _jsonOptions = new()
        {
            WriteIndented = true,
        };

        private static readonly string[] validImageExtensions = { ".jpg", ".jpeg", ".png", ".gif" };

        private static string GetDefaultFolder()
        {
            string baseFolder = Path.Combine(Environment.GetFolderPath(
                Environment.SpecialFolder.ApplicationData),"WPFCap",
                "SaveData");
            Directory.CreateDirectory(baseFolder);
            return baseFolder;
        }

        private static string GetImageFolder()
        {
            string imageFolder = Path.Combine(GetDefaultFolder(), "Images");
            Directory.CreateDirectory(imageFolder);
            return imageFolder;
        }

        private static string GetCoverImageFolder()
        {
            string coverImageFolder = Path.Combine(GetImageFolder(), "CoverImages");
            Directory.CreateDirectory(coverImageFolder);
            return coverImageFolder;
        }

        private static string GetSaveFileFolder()
        {
            string saveFileFolder = Path.Combine(GetDefaultFolder(), "SaveFiles");
            Directory.CreateDirectory(saveFileFolder);
            return saveFileFolder;
        }

        private static string GetSaveProjectDataFolder()
        {
            string saveProjectFolder = Path.Combine(GetSaveFileFolder(), "ProjectData");
            Directory.CreateDirectory(saveProjectFolder);
            return saveProjectFolder;
        }
        private static string GetSaveDesignFolder()
        {
            string saveDesignFolder = Path.Combine(GetSaveFileFolder(), "Design");
            Directory.CreateDirectory(saveDesignFolder);
            return saveDesignFolder;
        }



        public static ObservableCollection<ImageModel> GetCoverImageList()
        {
            return GetImageList(GetCoverImageFolder());

        }

        private static ObservableCollection<ImageModel> GetImageList(string filePath)
        {
            ObservableCollection<ImageModel> ImageList = new ObservableCollection<ImageModel>();
            string[] imageFiles = Directory.GetFiles(filePath).Where(file => CheckExtension(validImageExtensions, file)).ToArray();

            foreach (string fileName in imageFiles)
            {
                ImageList.Add(new ImageModel(fileName));
            }
            return ImageList;
        }

        private static bool CheckExtension(string[] validExtensions, string file)
        {
            string regex = ".*(\\.(.+))";
            Match match = Regex.Match(file, regex);
            if (match.Success)
            {
                string ending = match.Groups[1].Value;
                foreach (var extension in validExtensions)
                {
                    if(ending == extension)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        public static ImageModel GetEmptyImage()
        {
            string ImageDirectory = GetImageFolder();
            string fileName = $"{ImageDirectory}\\DEFAULT_MissingImage.png";

            return new ImageModel(fileName);
        }

        public static ImageSource GetImageSource(string fileName)
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

        public static bool InputLocalFileName(out string fileName, out string filePath)
        {
            var dialog = new Microsoft.Win32.OpenFileDialog();
            dialog.FileName = "test";
            dialog.DefaultExt = ".txt";
            bool? result = dialog.ShowDialog();
            if (result == true)
            {
                filePath = dialog.FileName;
                fileName = dialog.SafeFileName;
                return true;
            }
            fileName = string.Empty;
            filePath = string.Empty;
            return false;
        }

        public static void SaveProjectList(Collection<ProjectModel> ProjectList, ProjectModel? lastSelected)
        {
            string filePath = GetSaveProjectDataFolder();

            Collection<ProjectSaveFile> saveFiles = new Collection<ProjectSaveFile>();
            foreach (var item in ProjectList)
            {
                ProjectSaveFile projSave = new ProjectSaveFile(item);
                if(item == lastSelected)
                {
                    projSave.LastOpen = true;
                }
                saveFiles.Add(projSave);
            }
            SaveFile(saveFiles, "ProjectList");
        }

        private static async void SaveFile<T>(T InputFile, string fileName)
        {
            try
            {
                string fileLocation = Path.Combine(GetSaveProjectDataFolder(), "ProjectList.json");
                using FileStream stream = File.Create(fileLocation);
                await JsonSerializer.SerializeAsync(stream, InputFile, _jsonOptions);
            }
            catch (Exception ex)
            {
                Console.WriteLine("SAVE FILE FAILED");
                Console.WriteLine(ex.Message);
            }
        }

        public static ObservableCollection<ProjectModel> LoadProjectList(out ProjectModel? selected)
        {
            string fileLocation = Path.Combine(GetSaveProjectDataFolder(), "ProjectList.json");
            Collection<ProjectSaveFile> saveFiles = LoadFile<Collection<ProjectSaveFile>>(fileLocation);

            ObservableCollection<ProjectModel> projectList = new ObservableCollection<ProjectModel>();
            selected = null;

            if(saveFiles != null)
            {
                foreach (var item in saveFiles)
                {
                    ProjectModel projectModel = item.ConvertBack();
                    if (item.LastOpen)
                    {
                        selected = projectModel;
                    }
                    projectList.Add(projectModel);
                }
            }
            return projectList;
        }

        private static T LoadFile<T>(string fileName)
        {
            if (File.Exists(fileName))
            {
                try
                {
                    using FileStream stream = File.OpenRead(fileName);
                    T? output = JsonSerializer.Deserialize<T>(stream, _jsonOptions);
                    return output;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("LOAD FILE FAILED");
                    Console.WriteLine(ex.Message);
                }
            }
            return default;
        }

        public static ImageModel AddCoverImageToList()
        {
            if (InputLocalFileName(out string fileName, out string filePath))
            {
                if(CheckExtension(validImageExtensions, fileName))
                {
                    string fileLocation = Path.Combine(GetCoverImageFolder(), fileName);
                    File.Copy(filePath, fileLocation, overwrite: true);
                    return new ImageModel(fileLocation);
                }
            }
            return null;

        }

        public static ObservableCollection<EntryModel> GetEntryList(int projectId, out EntryModel? selected)
        {
            ObservableCollection<EntryModel> entryModels = new ObservableCollection<EntryModel>();
            if (true)
            {
                selected = new EntryModel(0, "egg", "egggggg");

                entryModels.Add(selected);
                entryModels.Add(new EntryModel(1, "new entry", "blah blah blah"));
                entryModels.Add(new EntryModel(2, "test", "tttesssttt"));
            }
            else
            {
                selected = null;
            }
            return entryModels;
        }

    }
}
