using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;


namespace WPFCap.Controllers
{
    public class WindowController : INotifyPropertyChanged
    {
        private static WindowController _instance;

        private static readonly object _lock = new object();
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


        private Visibility _createProjectVis { get; set; }
        public Visibility CreateProjectVis
        {
            get
            {
                return _createProjectVis;
            }
            private set
            {
                _createProjectVis = value;
                OnPropertyChanged(nameof(CreateProjectVis));
            }
        }

        public bool CreateProjectVisible
        {
            get
            {
                return ConvertVisibilityToBool(CreateProjectVis);
            }
            set
            {
                CreateProjectVis = ConvertBoolToVisibility(value);
            }
        }
        private Visibility _createEntryVis { get; set; }
        public Visibility CreateEntryVis
        {
            get
            {
                return _createEntryVis;
            }
            private set
            {
                _createEntryVis = value;
                OnPropertyChanged(nameof(CreateEntryVis));
            }
        }
        public bool CreateEntryVisible
        {
            get
            {
                return ConvertVisibilityToBool(CreateEntryVis);
            }
            set
            {
                CreateEntryVis = ConvertBoolToVisibility(value);
            }
        }

        private Visibility _selectEntryVis { get; set; }
        public Visibility SelectEntryVis
        {
            get
            {
                return _selectEntryVis;
            }
            private set
            {
                _selectEntryVis = value;
                OnPropertyChanged(nameof(SelectEntryVis));
            }
        }
        public bool SelectEntryVisible
        {
            get
            {
                return ConvertVisibilityToBool(SelectEntryVis);
            }
            set
            {
                SelectEntryVis = ConvertBoolToVisibility(value);
            }
        }

        private Visibility _selectProjectVis { get; set; }
        public Visibility SelectProjectVis
        {
            get
            {
                return _selectProjectVis;
            }
            private set
            {
                _selectProjectVis = value;
                OnPropertyChanged(nameof(SelectProjectVis));
            }
        }
        public bool SelectProjectVisible
        {
            get
            {
                return ConvertVisibilityToBool(SelectProjectVis);
            }
            set
            {
                SelectProjectVis = ConvertBoolToVisibility(value);
            }
        }

        private Visibility _deleteProjectVis { get; set; }
        public Visibility DeleteProjectVis
        {
            get
            {
                return _deleteProjectVis;
            }
            private set
            {
                _deleteProjectVis = value;
                OnPropertyChanged(nameof(DeleteProjectVis));
            }
        }
        public bool DeleteProjectVisible
        {
            get
            {
                return ConvertVisibilityToBool(DeleteProjectVis);
            }
            set
            {
                DeleteProjectVis = ConvertBoolToVisibility(value);
            }
        }

        private WindowController() 
        {
            CreateEntryVisible = false;
            SelectEntryVisible = false;

            CreateProjectVisible = false;
            SelectProjectVisible = false;
            DeleteProjectVisible = false;
        }


        private Visibility ConvertBoolToVisibility(bool value)
        {
            if (value)
            {
                return Visibility.Visible;
            }
            return Visibility.Collapsed;
        }
        private bool ConvertVisibilityToBool(Visibility value)
        {
            return value == Visibility.Visible;
        }



        public event PropertyChangedEventHandler? PropertyChanged;
        void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
