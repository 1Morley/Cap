using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace WPFCap.Controllers
{
    internal class StyleController
    {
        private ResourceDictionary styleVariables;

        public StyleController() 
        {
            styleVariables = Application.Current.Resources.MergedDictionaries[0];
        }
        public void UpdateColor()
        {
            ResourceDictionary styleDictionary = Application.Current.Resources.MergedDictionaries[0];
            if (styleDictionary["WindowBorderColor"] is SolidColorBrush)
            {                
                styleDictionary["WindowBorderColor"] = new SolidColorBrush(Colors.Yellow);
            }
            if (styleDictionary["WindowBackgroundColor"] is SolidColorBrush)
            {                
                styleDictionary["WindowBackgroundColor"] = new SolidColorBrush(Colors.CadetBlue);
            }
        }

        

    }
}
