using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using WPFCap.Models;

namespace WPFCap.Views.DataTemplateSelectors
{
    class ListEntryTypeSelect : DataTemplateSelector
    {
        public DataTemplate NormalEntryTemplate { get; set; }
        public DataTemplate LocalFileTemplate { get; set; }

        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            switch (item)
            {
                case EntryFileModel:
                    return LocalFileTemplate;
                case EntryModel:
                    return NormalEntryTemplate;
            }

            return base.SelectTemplate(item, container);
        }
    }
}
