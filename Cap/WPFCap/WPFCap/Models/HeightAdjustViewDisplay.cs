using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFCap.Models
{
    class HeightAdjustViewDisplay: ViewDisplay
    {
        private double[] Dimentions;
        public double Width
        {
            get
            {
                return Dimentions[0];
            }
            set
            {
                Dimentions[0] = value;
                OnPropertyChanged(nameof(Width));
            }
        }
        public double Height
        {
            get
            {
                return Dimentions[1];
            }
            set
            {
                Dimentions[1] = value;
                OnPropertyChanged(nameof(Height));
            }
        }

        public HeightAdjustViewDisplay(double[] cords, double[] dimentions, string windowTitle):base(cords,windowTitle)
        {
            Dimentions = dimentions;
        }
    }
}
