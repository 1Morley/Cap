using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFCap.Controllers;


namespace WPFCap.Models.SaveModels
{
    public class ProjectSaveFile
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public string ImageFilePath { get; set; }

        public bool LastOpen { get; set; }
        

        public ProjectSaveFile() { }
        public ProjectSaveFile(ProjectModel input)
        {
            Id = input.Id;
            Title = input.Title;
            ImageFilePath = input.CoverImage.FilePath;
        }

        public ProjectModel ConvertBack()
        {
            return new ProjectModel(Id, Title, new ImageModel(ImageFilePath));
        }
    }
}
