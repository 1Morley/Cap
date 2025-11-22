using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFCap.Controllers;

namespace WPFCap.Models.SaveModel
{
    class ProjectSaveFile
    {
        public string Title {  get; set; }

        public string ImageFilePath { get; set; }
        public CollectionController<EntryModel> EntryList { get; set; }

        public ProjectSaveFile() { }
        public ProjectSaveFile(ProjectModel input) 
        {
            Title = input.Title;
            ImageFilePath = input.CoverImage.FilePath;
            EntryList = input.EntryList;
        }

        public ProjectModel ConvertBack(int id)
        {
            return new ProjectModel(id, Title, new ImageModel(ImageFilePath), EntryList);
            
        }
    }
}
