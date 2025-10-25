using Capstone.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.Selectors
{
    public class EntryDataTemplateSelector : DataTemplateSelector
    {
        public DataTemplate EntryTemplate { get; set; }
        public DataTemplate FileTemplate { get; set; }
        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            NoteEntry noteEntry = (NoteEntry)item;
            if (noteEntry is FileEntry)
            {
                return FileTemplate;
            }
            return EntryTemplate;
        }
    }
}
