using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.Model
{
    class ProjEntry : INotifyPropertyChanged
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
                title = value;
                OnPropertyChanged(nameof(Title));
            }
        }

        private string status;
        public string Status
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

        private DateTime dueDate;

        public DateTime DueDate {
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

        private string entryDocument;

        public string EntryDocument
        {
            get
            {
                return entryDocument;
            }
            set
            {
                entryDocument = value;
                OnPropertyChanged(nameof(EntryDocument));
            }
        }

        public int Id { get; set; }
        

        public ProjEntry() { 
            resetValues();
        }


        public event PropertyChangedEventHandler? PropertyChanged;

        void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void resetValues() {
            Title = "New Entry";
            Status = "Null";
            DueDate = DateTime.Now;
            EntryDocument = "Null";
        }

        public ProjEntry createDuplicate() { 
            ProjEntry newEntry = new ProjEntry();
            newEntry.Title = Title;
            newEntry.DueDate = DueDate;
            newEntry.Status = Status;
            newEntry.EntryDocument = EntryDocument;
            return newEntry;
        }
    }
}
