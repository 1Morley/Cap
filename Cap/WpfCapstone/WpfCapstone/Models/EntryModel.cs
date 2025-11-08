using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfCapstone.Models
{
    public class EntryModel : INotifyPropertyChanged, ICollectionModel
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        private string _title;
        public string Title
        {
            get
            {
                return _title;
            }
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    _title = value;
                }
                else
                {
                    _title = DEFAULT_ENTRY_TITLE;
                }
                OnPropertyChanged(nameof(Title));
            }
        }

        private string? status;
        public string? Status
        {
            get
            {
                return status;
            }
            set
            {
                status = value;
                OnPropertyChanged(nameof(Status));
            }
        }

        private DateTime? dueDate;

        public DateTime? DueDate
        {
            get
            {
                return dueDate;
            }
            set
            {
                dueDate = value;
                OnPropertyChanged(nameof(DueDate));
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

        public int Id { get; }

        public const string DEFAULT_ENTRY_TITLE = "New Entry";

        public EntryModel() { }
        public EntryModel(int id, string title, string? status, DateTime? dueDate, string? entryNotes)
        {
            Title = title;
            Status = status;
            DueDate = dueDate;
            EntryNotes = entryNotes;
            Id = id;
        }


        void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
