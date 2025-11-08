using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfCapstone.Models;

namespace WpfCapstone.ViewModels
{
    internal class EntryListViewModel : INotifyPropertyChanged
    {
        public InputEntryModel InputEntry { get; private set; }

        private ProjectModel _selectedProject;
        public ProjectModel SelectedProject { get
            {
                return _selectedProject;
            }
            private set
            {
                _selectedProject = value;
                OnPropertyChanged(nameof(SelectedProject));
            }
        }

        public EntryListViewModel()
        {
            InputEntry = new InputEntryModel();
        }

        public void SetProject(ProjectModel project)
        {
            SelectedProject = project;
        }

        public void AddEntry()
        {
            SelectedProject.AddEntry(InputEntry);
        }

        public void DeleteEntry(int id)
        {
            SelectedProject.DeleteEntry(id);
        }
        public event PropertyChangedEventHandler? PropertyChanged;

        void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
