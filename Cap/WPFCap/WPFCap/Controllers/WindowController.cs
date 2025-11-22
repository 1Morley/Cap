using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WPFCap.Models.Enums;

namespace WPFCap.Controllers
{
    public class WindowController:INotifyPropertyChanged
    {
        private static WindowController _instance;
        
        private static readonly object _lock = new object();

        private FocusWindowModes _focusMode;
        public FocusWindowModes FocusMode
        {
            get { return _focusMode; }
            set
            {
                if (ProjectSelected || value != FocusWindowModes.ENTRY_CREATE)
                {
                    _focusMode = value;
                    OnPropertyChanged(nameof(FocusMode));
                    OnPropertyChanged(nameof(FocusWindow));
                }

            }
        }

        public Visibility FocusWindow
        {
            get
            {
                return ConvertBoolToVisibility(FocusMode != FocusWindowModes.DEFAULT);
            }
        }

        private bool _entrySelect;
        private bool EntrySelect
        {
            get
            {
                return _entrySelect;
            }
            set {
                    if (ProjectSelected || !value)
                    {
                        _entrySelect = value;
                        OnPropertyChanged(nameof(EntrySelectWindow));
                    }
                }
            }
        public Visibility EntrySelectWindow
        {
            get
            {
                return ConvertBoolToVisibility(EntrySelect);
            }
        }

        private ProjectWindowModes _projectMode;
        public ProjectWindowModes ProjectMode
        {
            get { return _projectMode; }
            set
            {
                _projectMode = value;
                OnPropertyChanged(nameof(ProjectMode));
                OnPropertyChanged(nameof(ProjectWindow));
            }
        }

        public Visibility ProjectWindow
        {
            get
            {
                return ConvertBoolToVisibility(ProjectMode != ProjectWindowModes.DEFAULT);
            }
        }

        private bool _projectSelected { get; set; }
        public bool ProjectSelected
        {
            get
            {
                return _projectSelected;
            }
            set
            {
                _projectSelected = value;
                if (!value)
                {
                    NoSelectedProjectSettings();
                }
            }
        }



        private WindowController()
        {
        }
        public static WindowController Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_lock)
                    {
                        if (_instance == null)
                        {
                            _instance = new WindowController();
                        }
                    }
                }
                return _instance;
            }
        }

        public void ToggleEntrySelectWindow()
        {
            EntrySelect = !EntrySelect;
        }
        public void ToggleEntryCreateWindow()
        {
            FocusMode = (FocusMode == FocusWindowModes.ENTRY_CREATE) ?
                FocusWindowModes.DEFAULT : FocusWindowModes.ENTRY_CREATE;
        }
        public void ToggleProjectCreateWindow()
        {
            FocusMode = (FocusMode == FocusWindowModes.PROJECT_CREATE) ?
                FocusWindowModes.DEFAULT : FocusWindowModes.PROJECT_CREATE;
        }
        public void ToggleProjectSelectWindow()
        {
            ProjectMode = (ProjectMode == ProjectWindowModes.PROJECT_SELECT) ?
                ProjectWindowModes.DEFAULT : ProjectWindowModes.PROJECT_SELECT;
        }

        public void CloseFocusWindow()
        {
            FocusMode = FocusWindowModes.DEFAULT;
        }

        private void NoSelectedProjectSettings()
        {
            EntrySelect = false;
            if (FocusMode == FocusWindowModes.ENTRY_CREATE)
            {
                FocusMode = FocusWindowModes.DEFAULT;
            }
        }

        private Visibility ConvertBoolToVisibility(bool value)
        {
            return value ? Visibility.Visible : Visibility.Collapsed;
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
