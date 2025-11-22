using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using WPFCap.Controllers;
using WPFCap.Models;

namespace WPFCap.ViewModels
{
    class WindowSelectViewModel
    {
        public RelayCommand ToggleDisplayEntrySelect { get; private set; }
        public RelayCommand ToggleDisplayEntryCreate { get; private set; }
        public RelayCommand ToggleDisplayProjectCreate { get; private set; }
        public RelayCommand ToggleDisplayProjectSelect { get; private set; }

        public RelayCommand CloseFocusWindow { get; private set; }

        private WindowController windowCon;
        public WindowSelectViewModel() 
        {
            windowCon = WindowController.Instance;
            CreateCommands();
        }

        private void CreateCommands()
        {
            ToggleDisplayEntrySelect = new RelayCommand(x =>
            {
                windowCon.ToggleEntrySelectWindow();
            });

            ToggleDisplayEntryCreate = new RelayCommand(x =>
            {
                windowCon.ToggleEntryCreateWindow();
            });

            ToggleDisplayProjectCreate = new RelayCommand(x =>
            {
                windowCon.ToggleProjectCreateWindow();
            });
            ToggleDisplayProjectSelect = new RelayCommand(x =>
            {
                windowCon.ToggleProjectSelectWindow();
            });
            CloseFocusWindow = new RelayCommand(x =>
            {
                windowCon.CloseFocusWindow();
            });
        }
    }
}
