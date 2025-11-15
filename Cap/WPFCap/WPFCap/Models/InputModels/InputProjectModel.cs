using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFCap.Models.Interfaces;

namespace WPFCap.Models.InputModels
{
    public class InputProjectModel: ProjectModel, IDuplicate<ProjectModel>
    {
        public const string DEFAULT_PROJECT_TITLE = "New Project";
        public new string Title
        {
            get { return base.Title; }
            set { base.SetTitle(value); }
        }
        public InputProjectModel() 
        { 
            ResetValues();
        }

        public ProjectModel Duplicate(int newId)
        {
            ProjectModel duplicatedModel = new ProjectModel(newId, Title, CoverImage);
            ResetValues();
            return duplicatedModel;
        }

        public void ResetValues()
        {
            Title = DEFAULT_PROJECT_TITLE;

        }



    }
}
