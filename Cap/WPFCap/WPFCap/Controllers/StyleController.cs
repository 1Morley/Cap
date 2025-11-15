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

        private const string MainBackgroundColorKey = "MainBackgroundColor";
        private const string SecondaryBackgroundColorKey = "SecondaryBackgroundColor";
        private const string MainTextColorKey = "MainTextColor";
        private const string BorderColorKey = "BorderColor";
        public StyleController() 
        {
            styleVariables = Application.Current.Resources.MergedDictionaries[0];
        }
        public void UpdateColor()
        {
            ResourceDictionary colorDictionary = Application.Current.Resources.MergedDictionaries[0];
            if (colorDictionary["PrimaryBrush"] is SolidColorBrush)
            {                
                colorDictionary["PrimaryBrush"] = new SolidColorBrush(Colors.Red);
            }
        }

        

    }
}
