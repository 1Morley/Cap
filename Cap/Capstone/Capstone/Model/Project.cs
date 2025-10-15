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

        public int Id { get; set; }



        public ObservableCollection<ProjEntry> EntryList { get; set; }
        public Project() {
            resetValues();
        }
  
        public void addEntry(ProjEntry input)
        {
            int id;
            if (EntryList.Count == 0)
            {
                id = 0;
            }
            else
            {
                id = EntryList.Max(x => x.Id) + 1;
            }
            input.Id=id;
            EntryList.Add(input);
        }

        private ProjEntry FindEntryById(int id)
        {
            return EntryList.FirstOrDefault(x => x.Id == id);
        }

        public void DeleteEntry(int Id)
        {
            ProjEntry found = FindEntryById(Id);
            if (found != null)
            {
                EntryList.Remove(found);
            }
        }


        public void resetValues()
        {
            Title = "New Project";
            ProjectImage = "Default.png";
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
