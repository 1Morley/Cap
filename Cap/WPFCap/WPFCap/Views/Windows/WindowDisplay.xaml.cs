using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPFCap.Views.Windows
{
    /// <summary>
    /// Interaction logic for WindowDisplay.xaml
    /// </summary>
    public partial class WindowDisplay : UserControl
    {
        public event EventHandler<MouseButtonEventArgs> TopLineEvent;
        public event EventHandler<MouseEventArgs> ViewWindowEvent;
        public WindowDisplay()
        {
            InitializeComponent();
        }
        private void ViewWindow_MouseMove(object sender, MouseEventArgs e)
        {
            ViewWindowEvent?.Invoke(this, e);
        }
        private void TopLine_MouseDown(object sender, MouseButtonEventArgs e)
        {
            TopLineEvent?.Invoke(this, e);
        }

    }
}
