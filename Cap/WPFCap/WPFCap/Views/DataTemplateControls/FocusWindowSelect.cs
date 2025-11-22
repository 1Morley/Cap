using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using WPFCap.Models;
using WPFCap.Models.Enums;

namespace WPFCap.Views.DataTemplateControls
{
    class FocusWindowSelect: DataTemplateSelector
    {
        public DataTemplate ProjectCreateTemplate { get; set; }
        public DataTemplate EntryCreateTemplate { get; set; }

        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            if (item.GetType() == typeof(FocusWindowModes))
            {
                switch (item)
                {
                    case FocusWindowModes.ENTRY_CREATE:
                        return EntryCreateTemplate;
                    case FocusWindowModes.PROJECT_CREATE:
                        return ProjectCreateTemplate;
                }
            }

            return base.SelectTemplate(item, container);
        }
    }
}
