using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.Model
{
    internal class Project : INotifyPropertyChanged
    {
        private string title;
        public string Title {
            get
            {
                return title;
            }
            set
            {
                title = value;
                OnPropertyChanged(nameof(Title));
            }
        }

        public int Index { get; set; }


        public ObservableCollection<ProjEntry> EntryList { get; set; }
        public Project(string title) {
            Title = title;
            EntryList = new ObservableCollection<ProjEntry>();

        }
  
        public void addEntry(string title)
        {
            EntryList.Add(new ProjEntry(title));
        }
        public void testData()
        {
            addEntry("thing");
            addEntry("aaa");
        }





        public event PropertyChangedEventHandler? PropertyChanged;

        void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
