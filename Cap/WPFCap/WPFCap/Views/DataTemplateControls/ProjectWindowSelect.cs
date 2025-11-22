using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using WPFCap.Models.Enums;

namespace WPFCap.Views.DataTemplateControls
{
    class ProjectWindowSelect : DataTemplateSelector
    {
        public DataTemplate ProjectSelectTemplate { get; set; }

        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            if (item.GetType() == typeof(ProjectWindowModes))
            {
                switch (item)
                {
                    case ProjectWindowModes.PROJECT_SELECT:
                    case ProjectWindowModes.PROJECT_DELETE:
                        return ProjectSelectTemplate;
                }
            }

            return base.SelectTemplate(item, container);
        }
    }
}
