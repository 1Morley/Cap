using Capstone.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.View
{
    public class EntryDataTemplateSelector : DataTemplateSelector
    {
        public DataTemplate NoteEntryTemplate { get; set; }
        public DataTemplate FileEntryTemplate { get; set; }
        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            if(item is FileEntry)
            {
                return FileEntryTemplate;
            }
            return NoteEntryTemplate;
        }
    }
}
