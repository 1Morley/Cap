using Capstone.Controller;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.Model
{
    internal class InputEntry : INotifyPropertyChanged
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

        public DateTime DueDate
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

        private string entryNotes;

        public string EntryNotes
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

        private string entryType;

        public string EntryType
        {
            get
            {
                return entryType;
            }
            set
            {
                entryType = value;
                OnPropertyChanged(nameof(EntryType));
            }
        }

        private string entryContent;

        public string EntryContent
        {
            get
            {
                return entryContent;
            }
            set
            {
                entryContent = value;
                OnPropertyChanged(nameof(EntryContent));
            }
        }


        private static string DEFAULT_TITLE = "New Entry";
        private static string DEFAULT_STATUS = "Null";
        private static string DEFAULT_ENTRY_NOTES = "Null";

        public InputEntry()
        {
            resetValues();
        }
        private void resetValues()
        {
            Title = DEFAULT_TITLE;
            Status = DEFAULT_STATUS;
            DueDate = DateTime.Now;
            EntryNotes = DEFAULT_ENTRY_NOTES;
            EntryContent = string.Empty;
        }

        public bool createNoteEntry(int entryId, out NoteEntry? newEntry, out string warningMessage)
        {
            if (CheckValues(out warningMessage))
            {
                if (EntryType == "FILE")
                {
                    newEntry = new FileEntry(entryId, Title, Status, DueDate, EntryNotes,EntryContent);
                }
                else
                {
                    newEntry = new NoteEntry(entryId, Title, Status, DueDate, EntryNotes);
                }
                resetValues();
                return true;
            }
            newEntry = null;
            return false;
        }

        private bool CheckValues(out string warningMessage)
        {
            if (!InputValidator.IsValidString(Title))
            {
                warningMessage = "Title cannot be empty";
                return false;

            }
            warningMessage = string.Empty;
            return true;
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
