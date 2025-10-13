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

        private DateTime date;

        public DateTime Date {
            get
            {
                return date;
            }
            set
            {
                date = value;
                OnPropertyChanged(nameof(Date));
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
            Date = DateTime.Now;
            EntryDocument = "Null";
        }

        public ProjEntry createDuplicate() { 
            ProjEntry newEntry = new ProjEntry();
            newEntry.Title = Title;
            newEntry.Date = Date;
            newEntry.Status = Status;
            newEntry.EntryDocument = EntryDocument;
            return newEntry;
        }
    }
}
