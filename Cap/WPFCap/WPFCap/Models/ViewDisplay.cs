using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WPFCap.Models
{
    class ViewDisplay : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        private double[] Cords;
        public double Left
        {
            get
            {
                return Cords[0];
            }
            set
            {
                Cords[0] = value;
                OnPropertyChanged(nameof(Left));
            }
        }
        public double Top
        {
            get
            {
                return Cords[1];
            }
            set
            {
                Cords[1] = value;
                OnPropertyChanged(nameof(Top));
            }
        }

        public string WindowTitle { get; private set; }


        public ViewDisplay(double[] cords, string windowTitle)
        {
            Cords = cords;
            WindowTitle = windowTitle;
        }
        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
