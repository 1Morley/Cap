using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfCapstone.Models
{
    public class InputProjectModel: ProjectModel, IDuplicate<ProjectModel>
    {

        public InputProjectModel() : base(0, DEFAULT_PROJECT_TITLE, DEFAULT_COVER_IMAGE, null) { }

        public void ResetValues()
        {
            Title = DEFAULT_PROJECT_TITLE;
            CoverImage = DEFAULT_COVER_IMAGE;
        }

        public ProjectModel Duplicate(int newId)
        {
            ProjectModel dup = new ProjectModel(newId, Title, CoverImage);
            ResetValues();
            return dup;
        }
    }
}
