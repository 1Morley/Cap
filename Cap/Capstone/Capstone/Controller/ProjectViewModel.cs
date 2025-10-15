using Capstone.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.Controller
{
    internal class ProjectViewModel
    {
        public ObservableCollection<Project> ProjectList { get; set; }

        public Project InputProject { get; set; }

        public ProjEntry InputEntry { get; set; }

        private ProjectListController PC;

        public ProjectViewModel() {
            ProjectList = new ObservableCollection<Project>();
            InputProject = new Project();
            InputEntry = new ProjEntry();
            PC = new ProjectListController(ProjectList);
        }

        public void AddProject() 
        {
            PC.AddProject(InputProject.createDuplicate());
            InputProject.resetValues();
        }

        public void DeleteProject(int projectId)
        {
            PC.DeleteProject(projectId);
        }
        public void DeleteEntry(int projectId, int entryId)
        {
            PC.DeleteEntry(projectId, entryId);
        }

        public void AddEntryByProjectId(int projectId)
        { 
            PC.AddEntryToProjectById(projectId, InputEntry.createDuplicate());
            InputEntry.resetValues();
        }

        public void MoveProjectToNewIndex(int projectId, int newIndex) {
            PC.MoveProjectToNewIndex(projectId, newIndex);
        }







    }
}
