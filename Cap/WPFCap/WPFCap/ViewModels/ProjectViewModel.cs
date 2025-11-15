using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFCap.Models;
using WPFCap.Models.Enums;
using WPFCap.Models.InputModels;

namespace WPFCap.ViewModels
{
    public class ProjectViewModel : INotifyPropertyChanged
    {
        private ProjectModel _selectedProject;
        public ProjectModel SelectedProject
        {
            get
            {
                return _selectedProject;
            }
            private set
            {
                _selectedProject = value;
                OnPropertyChanged(nameof(SelectedProject));
                UpdateShownEntryList();
            }
        }

        public ObservableCollection<EntryModel> ShownEntryList {  get; set; }

        public InputEntryModel InputEntry { get; private set; }
        public RelayCommand AddEntryCommand { get; private set; }
        public RelayCommand DeleteEntryCommand { get; private set; }

        public RelayCommand UpdateEntryFileType {  get; private set; }

        public ProjectViewModel()
        {
            InputEntry = new InputEntryModel();
            CreateCommands();
        }

        private void CreateCommands()
        {
            AddEntryCommand = new RelayCommand(x => AddEntry());
            DeleteEntryCommand = new RelayCommand(x =>
            {
                if (RelayCommand.ParseResultNumber(x, out int inputId))
                {
                    DeleteEntry(inputId);
                }
            });
            UpdateEntryFileType = new RelayCommand(x =>
            {
                if (RelayCommand.ParseResultEntryFileType(x, out EntryFileTypes inputId))
                {
                    InputEntry.SelectedEntryType = inputId;
                }
            });
        }

        private void AddEntry()
        {
            if (SelectedProject != null)
            {
                SelectedProject.EntryList.AddModel(InputEntry);
            }
        }

        private void DeleteEntry(int id)
        {
            if (SelectedProject != null)
            {
                SelectedProject.EntryList.DeleteModel(id);
            }
        }

        public void SetSelectProject(ProjectModel project)
        {
            SelectedProject = project;
        }

        private void UpdateShownEntryList()
        {
            ShownEntryList = SelectedProject.EntryList.ModelList;
            OnPropertyChanged(nameof(ShownEntryList));
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
