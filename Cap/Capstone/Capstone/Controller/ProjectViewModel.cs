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

        public InputProject InputProject { get; set; }

        public InputEntry InputEntry { get; set; }

        private ProjectListController PC;

        public ProjectViewModel() {
            ProjectList = new ObservableCollection<Project>();
            InputProject = new InputProject();
            InputEntry = new InputEntry();
            PC = new ProjectListController(ProjectList);
        }

        public string AddProject() 
        {
            if (InputProject.createProject(PC.getNextProjectId(), out Project? newProj, out string message) && newProj != null)
            {
                PC.AddProject(newProj);
                return string.Empty;
            }
            else
            {
                return message;
            }
        }

        public void DeleteProject(int projectId)
        {
            PC.DeleteProject(projectId);
        }
        public void DeleteEntry(int projectId, int entryId)
        {
            PC.DeleteEntry(projectId, entryId);
        }

        public string AddEntryByProjectId(int projectId)
        {
            int newId = PC.GetNextEntryId(projectId);

            if (InputEntry.createNoteEntry(newId, out NoteEntry? newEntry, out string message) && newEntry != null)
            {
                PC.AddEntryToProjectById(projectId, newEntry);
                return string.Empty;
            }
            else
            {
                return message;
            }
        }

        public void MoveProjectToNewIndex(int projectId, int newIndex) {
            PC.MoveProjectToNewIndex(projectId, newIndex);
        }







    }
}
