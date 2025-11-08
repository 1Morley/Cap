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
    class ProjectControlSelector : DataTemplateSelector
    {
        public DataTemplate DefaultProject { get; set; }
        public DataTemplate SelectProject { get; set; }

        public DataTemplate EmptyProject { get; set; }


        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            if (item is ProjectWindowState)
            {
                switch (item)
                {
                    case ProjectWindowState.SELECT:
                    case ProjectWindowState.DELETE:
                        return SelectProject;
                    case ProjectWindowState.EMPTY:
                        return EmptyProject;


                }
            }
            return DefaultProject;

        }
    }
}
