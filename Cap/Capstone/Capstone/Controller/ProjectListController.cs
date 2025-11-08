using Capstone.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.Controller
{
    class ProjectListController
    {
        public Collection<Project> ProjectList { get; }

        public ProjectListController(Collection<Project> ProjectList) {
            this.ProjectList = ProjectList;
        }

        private Project FindProjectById(int id)
        {
            //ProjectList.OrderBy(x => x.Id);
            return ProjectList.First(x => x.Id == id);
        }
        //
        public void AddProject(Project input)
        {
            if (input != null)
            {
                ProjectList.Add(input);
            }
        }

        public int GetNextEntryId(int projectId) {
            return FindProjectById(projectId).getNextEntryId();
        }
        public int getNextProjectId() {
            int id;
            if (ProjectList.Count == 0)
            {
                id = 0;
            }
            else
            {
                id = ProjectList.Max(x => x.Id) + 1;
            }
            return id;
        }
        //
        public void DeleteEntry(int projectId, int entryId)
        {
            FindProjectById(projectId).DeleteEntry(entryId);
        }
        public void DeleteProject(int Id)
        {
            Project found = FindProjectById(Id);
            if (found != null)
            {
                ProjectList.Remove(found);
            }
        }
        //
        public void MoveProjectToNewIndex(int projectId, int newIndex)
        {
            if(ProjectList.Count != 0) 
            { 
                if (newIndex < 0) 
                { 
                    newIndex = 0;
                }else if (newIndex >= ProjectList.Count) 
                { 
                    newIndex = ProjectList.Count - 1;
                }
                Project found = FindProjectById(projectId);

                DeleteProject(projectId);
                ProjectList.Insert(newIndex, found);
            
            }

        }
        //
        public void AddEntryToProjectById(int projectId, NoteEntry inputEntry)
        {
            Project found = FindProjectById(projectId);
            if (inputEntry != null && found != null)
            {
                found.addEntry(inputEntry);
            }
        }





    }
}
