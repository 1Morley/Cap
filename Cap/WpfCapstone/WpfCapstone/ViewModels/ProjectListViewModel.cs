using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WpfCapstone.Models;

namespace WpfCapstone.ViewModels
{
    internal class ProjectListViewModel
    {
        public ObservableCollection<ProjectModel> ProjectList { get; set; }
        public InputProjectModel InputProject { get; set; }
        public RelayCommand AddProjectCommand { get; private set; }
        public RelayCommand DeleteProjectCommand { get; private set; }


        public ProjectListViewModel()
        {
            ProjectList = new ObservableCollection<ProjectModel>();
            
            InputProject = new InputProjectModel();

            AddProjectCommand = new RelayCommand(input => AddProject());

            DeleteProjectCommand = new RelayCommand(input =>
            {
                if(int.TryParse(input.ToString(), out int inputId)) 
                {
                    DeleteProject(inputId);
                }
            });
        }

        private void AddProject() {
            ProjectList.Add(InputProject.Duplicate(getNextProjectId()));
        }

        private bool DeleteProject(int inputId) 
        {
            ProjectModel found = FindProjectById(inputId);
            if (found != null)
            {
                return ProjectList.Remove(found);
            }
            return false;
        }

        private int getNextProjectId()
        {
            int id;
            if (ProjectList.Count == 0)
            {
                id = 1;
            }
            else
            {
                id = ProjectList.Max(x => x.Id) + 1;
            }
            return id;
        }

        private ProjectModel FindProjectById(int id)
        {
            //ProjectList.OrderBy(x => x.Id);
            return ProjectList.FirstOrDefault(x => x.Id == id);
        }

        private void MoveProjectToNewIndex(int projectId, int newIndex)
        {
            if (ProjectList.Count != 0)
            {
                if (newIndex < 0)
                {
                    newIndex = 0;
                }
                else if (newIndex >= ProjectList.Count)
                {
                    newIndex = ProjectList.Count - 1;
                }
                ProjectModel found = FindProjectById(projectId);

                if (DeleteProject(projectId))
                {
                    ProjectList.Insert(newIndex, found);
                }

            }

        }
    }
}
