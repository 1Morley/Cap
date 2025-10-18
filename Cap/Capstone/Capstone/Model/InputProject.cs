using Capstone.Controller;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.Model
{
    internal class InputProject : INotifyPropertyChanged
    {
        private string title;

        public string Title
        {
            get
            {
                return title;
            }
            set
            {
                title = value;
                OnPropertyChanged(nameof(Title));
            }
        }

        private string projectImage;

        public string ProjectImage
        {
            get
            {
                return projectImage;
            }
            set
            {
                projectImage = value;
                OnPropertyChanged(nameof(ProjectImage));
            }
        }

        private static string DEFAULT_TITLE = "New Project";
        private static string DEFAULT_IMAGE = "Default.png";

        public InputProject() { 
            resetValues();
        }
        private void resetValues()
        {
            Title = DEFAULT_TITLE;
            ProjectImage = DEFAULT_IMAGE;

        }

        public bool createProject(int id, out Project? newProject, out string warningMessage)
        {
            if (checkValues(out warningMessage))
            {
                newProject = new Project(id, Title, ProjectImage);
                resetValues();
                return true;
            }
            newProject = null;
            return false;
        }

        private bool checkValues(out string warningMessage) {
            
            if (!InputValidator.IsValidString(Title))
            {
                warningMessage = "Title cannot be empty";
                return false;

            }
            else if (!InputValidator.IsValidString(ProjectImage))
            {
                warningMessage = "Image cannot be empty";
                return false;

            }
            warningMessage = string.Empty;
            return true;
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
