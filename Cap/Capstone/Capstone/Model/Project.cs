using Capstone.Controller;
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
                if (InputValidator.IsValidString(value))
                {
                    title = value;
                    OnPropertyChanged(nameof(Title));
                }
            }
        }

        private string projectImage;

        public string ProjectImage
        {
            get
            {
                return projectImage;
            }
            set
            {
                if (InputValidator.IsValidString(value))
                {
                    projectImage = value;
                    OnPropertyChanged(nameof(ProjectImage));
                }
            }
        }

        public int Id { get; }



        public ObservableCollection<NoteEntry> EntryList { get; set; }
        public Project(int id, string title, string projectImage) {
            Title = title;
            ProjectImage = projectImage;
            Id = id;
            EntryList = new ObservableCollection<NoteEntry>();
        }
  
        public void addEntry(NoteEntry input)
        {
            if (input != null)
            {
                EntryList.Add(input);
            }
        }

        public int getNextEntryId()
        {
            int id;
            if (EntryList.Count == 0)
            {
                id = 0;
            }
            else
            {
                id = EntryList.Max(x => x.Id) + 1;
            }
            return id;
        }

        private NoteEntry FindEntryById(int id)
        {
            return EntryList.FirstOrDefault(x => x.Id == id);
        }

        public void DeleteEntry(int Id)
        {
            NoteEntry found = FindEntryById(Id);
            if (found != null)
            {
                EntryList.Remove(found);
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
