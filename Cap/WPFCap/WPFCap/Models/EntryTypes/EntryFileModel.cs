using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFCap.Models.Interfaces;

namespace WPFCap.Models
{
    internal class EntryFileModel : EntryModel
    {
        private IOpenStrategy OpenFunction { get; set; }

        public RelayCommand OpenCommand { get; private set; }
        public EntryFileModel() : base() { }

        public EntryFileModel(int id, string title, string? entryNotes, IOpenStrategy function)
            : base(id, title, entryNotes)
        {
            OpenFunction = function;
            CreateCommands();
        }

        private void CreateCommands()
        {
            OpenCommand = new RelayCommand(x =>
            {
                OpenFunction.Open();
            });
        }
    }
}
