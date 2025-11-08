using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfCapstone.Models
{
    public class InputEntryModel : EntryModel, IDuplicate<EntryModel>
    {

        public InputEntryModel() :base(0,DEFAULT_ENTRY_TITLE,null,null,null) { }

        public EntryModel Duplicate(int newId)
        {
            EntryModel dup = new EntryModel(newId, Title, Status, DueDate, EntryNotes);
            ResetValues();
            return dup;
        }

        public void ResetValues()
        {
            Title = DEFAULT_ENTRY_TITLE;
            Status = null;
            DueDate = null;
            EntryNotes = null;
        }
    }
}
