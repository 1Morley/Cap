using System;
using System.Collections.Generic;
using System.Linq;
using System.Printing;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls.Primitives;
using WpfCapstone.Models;

namespace WpfCapstone.ViewModels
{
    class MainWindowViewModel
    {
        public ProjectViewVisibilityViewModel ProjectVisibilityVM { get; set; }
        public ProjectListViewModel ProjectListVM { get; set; }

        public EntryListViewModel EntryListVM { get; set; }

        public RelayCommand SetProjectSelect {  get; private set; }
        public RelayCommand SetProjectDelete {  get; private set; }
        public RelayCommand SetFocusCreate { get; private set; }
        public RelayCommand SetFocusCreateEntry { get; private set; }


        public RelayCommand SetFocusNone { get; private set; }
        public RelayCommand ClickSelectProject {  get; private set; }
        public RelayCommand ClickCreateProject {  get; private set; }
        public RelayCommand ClickCreateEntry {  get; private set; }
        public RelayCommand ClickDeleteEntry {  get; private set; }

        public RelayCommand OnSelect {  get; private set; }


        

        public MainWindowViewModel()
        {
            ProjectVisibilityVM = new ProjectViewVisibilityViewModel();
            ProjectListVM = new ProjectListViewModel();
            EntryListVM = new EntryListViewModel();
            SelectProjectOnLoad();

            SetProjectSelect = new RelayCommand(input => ProjectVisibilityVM.SetSelectProjectState());
            SetProjectDelete = new RelayCommand(input => ProjectVisibilityVM.SetDeleteProjectState());
            SetFocusCreate = new RelayCommand(input => ProjectVisibilityVM.SetCreateProjectFocusState());
            SetFocusNone = new RelayCommand(input => ProjectVisibilityVM.SetNoneFocusState());
            SetFocusCreateEntry = new RelayCommand(input => ProjectVisibilityVM.SetCreateEntryFocusState());

            ClickSelectProject = new RelayCommand(input =>
            {
                if (input != null)
                {
                    if (int.TryParse(input.ToString(), out int inputId))
                    {
                        switch (ProjectVisibilityVM.ProjectState)
                        {
                            case ProjectWindowState.SELECT:
                                SelectProject(inputId);
                                break;
                            case ProjectWindowState.DELETE:
                                DeleteProject(inputId);
                                break;

                        }
                    }
                }
            });
            ClickCreateProject = new RelayCommand(input =>
            {
                ProjectModel newProj = ProjectListVM.AddProject();
                EntryListVM.SetProject(newProj);
                ProjectVisibilityVM.SetDefaultProjectState();
                ProjectVisibilityVM.SetNoneFocusState();
            });
            ClickCreateEntry = new RelayCommand(input =>
            {
                EntryListVM.AddEntry();
                ProjectVisibilityVM.SetNoneFocusState();
            });
            ClickDeleteEntry = new RelayCommand(input =>
            {
                if (input != null)
                {
                    if(int.TryParse(input.ToString(), out int inputId))
                    {
                        EntryListVM.DeleteEntry(inputId);
                    }

                }
            });
            


            OnSelect = new RelayCommand(input => { ProjectVisibilityVM.SetNoneFocusState(); });


        }

        private bool EmptyListCheck()
        {
            if(ProjectListVM.ProjectList.Count == 0)
            {
                ProjectVisibilityVM.SetEmptyProjectState();
                return false;
            }
            return true;
        }

        private void DeleteProject(int inputId)
        {
            ProjectListVM.DeleteProject(inputId);
            if (EmptyListCheck())//todo check if current project
            {
                ProjectVisibilityVM.SetSelectProjectState();
            }
        }

        private void SelectProject(int inputId)
        {
            ProjectModel selected = ProjectListVM.GetProject(inputId);
            EntryListVM.SetProject(selected);
            ProjectVisibilityVM.SetDefaultProjectState();
        }

        private void SelectProjectOnLoad() //TODO SAVE FIRST OPEN PROJ ID
        {
            if (EmptyListCheck())
            {
                EntryListVM.SetProject(ProjectListVM.GetProject(1));
            }
        }
    }
}
