using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFCap.Models.Interfaces;

namespace WPFCap.Models
{
    public class EntryModel : INotifyPropertyChanged, ICollectionModel
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        public int Id { get; }

        private string _title;
        public string Title
        {
            get
            {
                return _title;
            }
            private set
            {
                _title = value;
                OnPropertyChanged(nameof(Title));
            }
        }

        private string? entryNotes;

        public string? EntryNotes
        {
            get
            {
                return entryNotes;
            }
            set
            {
                entryNotes = value;
                OnPropertyChanged(nameof(EntryNotes));
            }
        }


        public EntryModel() { }

        public EntryModel(int id, string title,string? entryNotes)
        {
            Id = id;
            Title = title;
            EntryNotes = entryNotes;
        }

        public void SetTitle(string title)
        {
            Title = title;
        }

        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
