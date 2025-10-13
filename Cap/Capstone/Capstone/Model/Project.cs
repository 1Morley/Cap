using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.Model
{
    internal class Project : INotifyPropertyChanged
    {
        private string title;

        public string Title {
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
        
        private int id;

        public int Id
        {
            get
            {
                return id;
            }
            set
            {
                id = value;
                OnPropertyChanged(nameof(Id));
            }
        }


        public ObservableCollection<ProjEntry> EntryList { get; set; }
        public Project() {
            resetValues();
        }
  
        public void addEntry(ProjEntry input)
        {
            EntryList.Add(input);
        }

        public void resetValues()
        {
            Title = "New Project";
            ProjectImage = "Default";
            EntryList = new ObservableCollection<ProjEntry>();
        }

        public Project createDuplicate() {
            Project newProject = new Project();
            newProject.Title = Title;
            newProject.ProjectImage = ProjectImage;
            return newProject;
        }


        public event PropertyChangedEventHandler? PropertyChanged;

        void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
