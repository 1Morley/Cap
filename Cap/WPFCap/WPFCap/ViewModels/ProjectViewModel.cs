using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using WPFCap.Controllers;
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
        public RelayCommand SetInputEntryFile {  get; private set; }

        public RelayCommand SetGoogleFile { get; private set; }

        private WindowController windowCon;
        public Collection<GoogleFile> GoogleList { get; private set; }

        public ProjectViewModel()
        {
            GoogleList = GoogleController.Instance.ListFiles();
            InputEntry = new InputEntryModel();
            windowCon = WindowController.Instance;
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
            SetInputEntryFile = new RelayCommand(x =>
            {
                if(FileController.InputLocalFile(out string fileName))
                {
                    InputEntry.EntryLocalFile = fileName;
                }
            });
            SetGoogleFile = new RelayCommand(x =>
            {
                if(x is GoogleFile file)
                {
                    InputEntry.EntryGoogleFile = file;
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
            if (SelectedProject != null)
            {
                windowCon.ProjectSelected = true;
                SelectedProject = project;
            }
            else
            {
                SetSelectProjectNull();
            }
        }

        public void SetSelectProjectNull()
        {
            ImageModel defaultImage = FileController.GetEmptyImage();
            SelectedProject = new ProjectModel(0,"Empty Project", defaultImage);
            windowCon.ProjectSelected = false;
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
