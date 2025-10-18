using Capstone.Controller;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.Model
{
    internal class FileEntry : NoteEntry, INotifyPropertyChanged
    {
        private string? path;

        public string? Path
        {
            get
            {
                return path;
            }
            set
            {
                path = value;
                OnPropertyChanged(nameof(Path));
                testValidPath();
            }
        }


        private bool isValidPath;

        public bool IsValidPath { get; }

        public FileEntry(int id, string title, string? status, DateTime? dueDate, string? entryNotes, string? path)
            : base(id, title, status, dueDate, entryNotes)
        {
            Path = path;
        }

        private void testValidPath() {
            isValidPath = true;
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
