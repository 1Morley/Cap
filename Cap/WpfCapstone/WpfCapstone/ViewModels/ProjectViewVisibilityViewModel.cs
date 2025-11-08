using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WpfCapstone.Models;

namespace WpfCapstone.ViewModels
{
    public class ProjectViewVisibilityViewModel : INotifyPropertyChanged
    {

        private ProjectWindowState _projectState;

        public ProjectWindowState ProjectState
        {
            get { return _projectState; }
            private set 
            { 
                _projectState = value; 
                OnPropertyChanged(nameof(ProjectState));
            }
        }
        
        private FocusWindowState _focusState;

        public FocusWindowState FocusState
        {
            get { return _focusState; }
            private set
            {
                _focusState = value;
                OnPropertyChanged(nameof(FocusState));
            }
        }


        public void SetDeleteProjectState()
        {
            ProjectState = ProjectWindowState.DELETE;
        }

        public void SetDefaultProjectState()
        {
            ProjectState = ProjectWindowState.DEFAULT;
        }

        public void SetSelectProjectState()
        {
            ProjectState = ProjectWindowState.SELECT;

        }
        public void SetEmptyProjectState()
        {
            ProjectState = ProjectWindowState.EMPTY;

        }

        public void SetNoneFocusState()
        {
            FocusState = FocusWindowState.NONE;
        }
        public void SetCreateProjectFocusState()
        {
            FocusState = FocusWindowState.CREATE_PROJECT;
        }
        public void SetCreateEntryFocusState()
        {
            FocusState = FocusWindowState.CREATE_ENTRY;
        }
        public ProjectViewVisibilityViewModel()
        {
            FocusState = FocusWindowState.NONE; 
            ProjectState = ProjectWindowState.DEFAULT;
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
