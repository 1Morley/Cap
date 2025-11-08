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
    public class ProjectListViewModel
    {
        public ObservableCollection<ProjectModel> ProjectList { get; private set; }
        public InputProjectModel InputProject { get; private set; }


        public ProjectListViewModel()
        {
            ProjectList = new ObservableCollection<ProjectModel>();
            InputProject = new InputProjectModel();

            AddTestProjects();
            FileController thing = new FileController();
            var output = thing.LoadFile();
            ObservableCollection<ProjectModel> test = output.Result;
        }

        private void AddTestProjects()//TODO REMOVE 
        {
            AddProject();
            AddProject();
            AddProject();
        }

        public ProjectModel AddProject() {
            return ListController<ProjectModel>.AddModel(ProjectList, InputProject);
        }

        public void DeleteProject(int inputId) 
        {
            ListController<ProjectModel>.DeleteModel(ProjectList, inputId);
        }

        public void MoveProjectToNewIndex(int projectId, int newIndex)
        {
            ListController<ProjectModel>.MoveModelToNewIndex(ProjectList, projectId,newIndex);
        }

        public ProjectModel GetProject(int inputId) 
        { 
            return ListController<ProjectModel>.FindModelById(ProjectList, inputId);
        }

    }
}
