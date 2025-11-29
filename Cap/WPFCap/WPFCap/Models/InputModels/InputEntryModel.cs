using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFCap.Models.Interfaces;

namespace WPFCap.Models.InputModels
{
    public class InputEntryModel : EntryModel, IDuplicate<EntryModel>
    {
        public const string DEFAULT_ENTRY_TITLE = "New Entry";
        public const string DEFAULT_ENTRY_NOTES = "";

        private string _entryLocalFile { get; set; }
        public string EntryLocalFile
        {
            get
            {
                return _entryLocalFile;
            }
            set
            {
                if (value != string.Empty)
                {
                    ResetEntryTypes();
                }
                _entryLocalFile = value;
                OnPropertyChanged(nameof(EntryLocalFile));
            }
        }

        private string _entryLink { get; set; }
        public string EntryLink
        {
            get
            {
                return _entryLink;
            }
            set
            {
                if (value != string.Empty)
                {
                    ResetEntryTypes();
                }
                _entryLink = value;
                OnPropertyChanged(nameof(EntryLink));
            }
        }

        private GoogleFile _entryGoogleFile { get; set; }
        public GoogleFile EntryGoogleFile
        {
            get
            {
                return _entryGoogleFile;
            }
            set
            {
                if (value != null)
                {
                    ResetEntryTypes();
                }
                _entryGoogleFile = value;
                OnPropertyChanged(nameof(EntryGoogleFile));
            }
        }
        public InputEntryModel()
        {
            ResetValues();
        }

        public EntryModel Duplicate(int newId)
        {
            EntryModel duplicatedModel = null;
            if (!string.IsNullOrEmpty(EntryLocalFile))
            {
                duplicatedModel = new EntryFileModel(newId, Title, EntryNotes, new FileStrategy(EntryLocalFile));
            }
            else if (!string.IsNullOrEmpty(EntryLink))
            {
                duplicatedModel = new EntryFileModel(newId, Title, EntryNotes, new LinkStrategy(EntryLink));
            }
            else if (EntryGoogleFile != null)
            {
                duplicatedModel = new EntryFileModel(newId, Title, EntryNotes, new GoogleStrategy(EntryGoogleFile));
            }
            else
            {
                duplicatedModel = new EntryModel(newId, Title, EntryNotes);
            }

            ResetValues();
            return duplicatedModel;
        }

        private void ResetEntryTypes()
        {
            EntryLocalFile = string.Empty;
            EntryLink = string.Empty;
            EntryGoogleFile = null;
        }

        public void ResetValues()
        {
            Title = DEFAULT_ENTRY_TITLE;
            EntryNotes = DEFAULT_ENTRY_NOTES;
            ResetEntryTypes();
        }
    }
}
