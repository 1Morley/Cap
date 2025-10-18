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
    class NoteEntry : INotifyPropertyChanged
    {
        private string title;
        public string Title
        {
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

        public DateTime? DueDate {
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

        public int Id { get;}
        

        public NoteEntry(int id, string title, string? status, DateTime? dueDate, string? entryNotes) { 
            Title = title;
            Status = status;
            DueDate = dueDate;
            EntryNotes = entryNotes;
            Id = id;
        }


        public event PropertyChangedEventHandler? PropertyChanged;

        void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
