using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace WpfCapstone.Models.ViewConverter
{
    internal class ViewPositionConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            //0 == type of conversion in string ("CENTER")
            //1 == canvas size
            //2 == element size
            if (values.Length == 3)
            {
                try
                {
                    string ConversionType = (string)values[0];
                    double panelSize = (double)values[1];
                    double elementSize = (double)values[2];

                    switch (ConversionType.ToUpper())
                    {
                        case "CENTER":
                            return GetCenterPosition(panelSize, elementSize);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }

            }
            return Binding.DoNothing;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        private double GetCenterPosition(double panelSize, double elementSize)
        {
            return (panelSize - elementSize) / 2;
        }
    }
}
