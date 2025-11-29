using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFCap.Controllers;
using WPFCap.Models;
using WPFCap.Models.InputModels;

namespace WPFCap.ViewModels
{
    public class ProjectListViewModel: PageSelectViewModel<ProjectModel>
    {
        public ObservableCollection<ProjectModel> Projects
        {
            get
            {
                return ModelList;
            }
        }


        public ProjectViewModel? ProjectVM
        {
            get { return _projectVM; }
            private set
            {
                _projectVM = value;
                OnPropertyChanged(nameof(ProjectVM));
            }
        }
        private ProjectViewModel? _projectVM {  get; set; }

        public InputProjectViewModel? InputProjectVM
        {
            get { return _inputProjectVM; }
            private set
            {
                _inputProjectVM = value;
                OnPropertyChanged(nameof(InputProjectVM));
            }
        }
        private InputProjectViewModel? _inputProjectVM {  get; set; }

        public RelayCommand SelectProject { get; private set; }
        public RelayCommand AddProject { get; private set; }
        public RelayCommand DeleteProject { get; private set; }

        public RelayCommand ToggleAddPrompt { get; private set; }
        public RelayCommand ToggleDeletePrompt { get; private set; }

        public RelayCommand ToggleSelectPrompt { get; private set; }


        public ProjectListViewModel():base(new ProjectListModel())
        {
            FullList = FileController.LoadProjectList(out ProjectModel selectedProject);
            if (selectedProject != null)
            {
                ProjectVM = new ProjectViewModel(selectedProject);
            }
            CreateCommands();
        }

        private void CreateCommands()
        {
            SelectItemCommand = new RelayCommand(x =>
            {
                if (RelayCommand.ParseResultNumber(x, out int index))
                {
                    ProjectVM = new ProjectViewModel(GetItemFromShownIndex(index));
                }
            });
            AddProject = new RelayCommand(x =>
            {
                if (InputProjectVM != null && InputProjectVM.ValidInputModel(out InputProjectModel inputModel))
                {
                    ProjectModel newProject = AddModel(inputModel);
                    ProjectVM = new ProjectViewModel(newProject);
                    OnPropertyChanged(nameof(Projects));
                }
            });
            DeleteProject = new RelayCommand(x =>
            {
                if (RelayCommand.ParseResultNumber(x, out int inputId))
                {
                    DeleteModel(inputId);
                }
            });

            ToggleAddPrompt = new RelayCommand(x =>
            {
                if (InputProjectVM == null)
                {
                    InputProjectVM = new InputProjectViewModel();
                    WindowController.Instance.CreateProjectVisible = true;
                }
                else
                {
                    InputProjectVM = null;
                    WindowController.Instance.CreateProjectVisible = false;
                }
            });
            ToggleDeletePrompt = new RelayCommand(x =>
            {
                WindowController.Instance.DeleteProjectVisible = !WindowController.Instance.DeleteProjectVisible;
            });
            ToggleSelectPrompt = new RelayCommand(x =>
            {
                WindowController.Instance.SelectProjectVisible = !WindowController.Instance.SelectProjectVisible;
                
            });
        }

        public void SaveProjectList()
        {
            if (ProjectVM != null)
            {
                FileController.SaveProjectList(GetFullList(), ProjectVM.Project);
            }
        }
    }
}
