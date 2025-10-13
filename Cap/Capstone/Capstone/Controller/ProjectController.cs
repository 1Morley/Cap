using Capstone.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.Controller
{
    internal class ProjectController
    {
        public ObservableCollection<Project> ProjectList { get; set; }
        public Project InputProject { get; set; }

        public ProjEntry InputEntry { get; set; }

        public ProjectController() {
            ProjectList = new ObservableCollection<Project>();
            InputProject = new Project();
            InputEntry = new ProjEntry();
        }

        private Project findProjectById(int id)
        {
            //ProjectList.OrderBy(x => x.Id);
            return ProjectList.First(x => x.Id == id);

        }

        public void addEntryByProjectIdClick(int id) { 
            Project found = findProjectById(id);
            if (found != null) { 
                addEntryToProject(found, InputEntry.createDuplicate());
                InputEntry.resetValues();
            }
        }

        public void addEntryToProject(Project project, ProjEntry inputEntry) { 
            project.addEntry(inputEntry);
        }

        public void addProjectClick() {
            addProject(InputProject.createDuplicate());
            InputProject.resetValues();
        }
        private void addProject(Project input) {
            int id = ProjectList.Count + 1;
            input.Id = id;
            ProjectList.Add(input);
        }


        
    }
}
