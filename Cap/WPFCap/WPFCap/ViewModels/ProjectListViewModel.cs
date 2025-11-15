using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Printing;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using WPFCap.Controllers;
using WPFCap.Models;
using WPFCap.Models.InputModels;
using WPFCap.Models.Interfaces;

namespace WPFCap.ViewModels
{
    public class ProjectListViewModel: PageSelectViewModel<ProjectModel>
    {
        public CollectionController<ProjectModel> ProjectList;
        public ObservableCollection<ProjectModel> ShownProjectList { get; private set; }
        public ProjectViewModel ChosenProjectVM { get; }
        public InputProjectModel InputProject { get; }
        public SelectPictureViewModel SelectPictureVM { get; }
        public RelayCommand AddProjectCommand { get; private set; }
        public RelayCommand DeleteProjectCommand { get; private set; }
        public RelayCommand SwitchDeleteModeCommand { get; private set; }

        public Visibility DeleteAvailibility
        {
            get
            {
                if (DeleteMode)
                {
                    return Visibility.Visible;
                }
                return Visibility.Collapsed;
            }
        }
        public Visibility SelectAvailibility
        {
            get
            {
                if (DeleteMode)
                {
                    return Visibility.Collapsed;
                }
                return Visibility.Visible;
            }
        }

        private bool _deleteMode = false;
        private bool DeleteMode
        {
            get
            {
                return _deleteMode;
            }
            set
            {
                _deleteMode = value;
                OnPropertyChanged(nameof(DeleteAvailibility));
                OnPropertyChanged(nameof(SelectAvailibility));
            }
        }

        private void SwitchDeleteMode()
        {
            DeleteMode = !DeleteMode;
        }
        public ProjectListViewModel():
            base(new ObservableCollection<ProjectModel>(), new ObservableCollection<ProjectModel>(),3)
        {
            ProjectList = new CollectionController<ProjectModel>((ObservableCollection<ProjectModel>)GetFullList());
            ShownProjectList = GetShownList();

            ChosenProjectVM = new ProjectViewModel();
            InputProject = new InputProjectModel();
            SelectPictureVM = new SelectPictureViewModel();

            CreateCommands();

            TestGoogle thing = new TestGoogle();
        }

        private void CreateCommands()
        {
            AddProjectCommand = new RelayCommand(x => AddProject());
            DeleteProjectCommand = new RelayCommand(x =>
            {
                if(RelayCommand.ParseResultNumber(x,out int inputId))
                {
                    DeleteProject(inputId);
                }
            });
            SwitchDeleteModeCommand = new RelayCommand(x => SwitchDeleteMode());
            SelectItemCommand = new RelayCommand(x =>
            {
                if (RelayCommand.ParseResultNumber(x, out int inputId))
                {
                    SetSelectedItem(inputId);
                    SetChosenProject();
                }
            });
        }

        public void AddProject()
        {
            InputProject.CoverImage = SelectPictureVM.SelectedItem;
            ProjectList.AddModel(InputProject);

            SetToNewestItem();
            UpdateShownList();
            SetChosenProject();
        }
        public void DeleteProject(int id)
        {
            ProjectList.DeleteModel(id);
            DeleteMode = false;
            UpdateShownList();
        }

        private void SetChosenProject()
        {
            ChosenProjectVM.SetSelectProject(SelectedItem);
            OnPropertyChanged(nameof(ChosenProjectVM));
        }
       
    }
}
