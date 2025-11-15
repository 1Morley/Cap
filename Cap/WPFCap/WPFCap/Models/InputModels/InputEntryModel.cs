using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFCap.Models.Enums;
using WPFCap.Models.Interfaces;

namespace WPFCap.Models.InputModels
{
    public class InputEntryModel : EntryModel, IDuplicate<EntryModel>
    {
        public const string DEFAULT_ENTRY_TITLE = "New Entry";
        public const string DEFAULT_ENTRY_NOTES = "";
        public EntryFileTypes SelectedEntryType { get; set; }

        public new string Title
        {
            get { return base.Title; }
            set { base.SetTitle(value); }
        }
        public InputEntryModel()
        {
            ResetValues();
        }

        public EntryModel Duplicate(int newId)
        {
            EntryModel duplicatedModel;
            switch (SelectedEntryType)
            {
                case EntryFileTypes.LOCAL_FILE:
                    duplicatedModel = new FileEntryModel(newId, "FILE THINGIE", EntryNotes, new FileStrategy(@"C:\Users\Bug\OneDrive\Documents\year3Q1\capstone\notes\TEST.txt"));
                    break;

                default:
                    duplicatedModel = new EntryModel(newId, "NORMAL BITCH", EntryNotes);
                    break;
            } 
            ResetValues();
            return duplicatedModel;
        }

        public void ResetValues()
        {
            Title = DEFAULT_ENTRY_TITLE;
            EntryNotes = DEFAULT_ENTRY_NOTES;
        }
    }
}
