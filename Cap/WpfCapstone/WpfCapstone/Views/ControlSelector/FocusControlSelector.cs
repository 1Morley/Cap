using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using WpfCapstone.Models;

namespace WpfCapstone.Views.ControlSelector
{
    class FocusControlSelector : DataTemplateSelector
    {
        public DataTemplate CreateProjectFocus { get; set; }
        public DataTemplate CreateEntryFocus { get; set; }



        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            if (item is FocusWindowState)
            {
                switch (item)
                {
                    case FocusWindowState.CREATE_PROJECT:
                        return CreateProjectFocus;
                    case FocusWindowState.CREATE_ENTRY:
                        return CreateEntryFocus;


                }
            }
            return null;

        }
    }
}
