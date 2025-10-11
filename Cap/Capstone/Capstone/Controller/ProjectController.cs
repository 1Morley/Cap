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
            InputProject = new Project("New Project");
            InputEntry = new ProjEntry("New Entry");
            testData();
        }

        public void addProjectClick() {
            string title = InputProject.Title;
            addProject(new Project(title));
        }
        private void addProject(Project input) {
            int index = ProjectList.Count + 1;
            input.Index = index;
            ProjectList.Add(input);
        }
        public void testData() {
            addProject(new Project("Egg"));
            addProject(new Project("Red Wood"));
            addProject(new Project("Essay"));
        }
    }
}
