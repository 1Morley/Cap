using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WPFCap.Controllers;

namespace WPFCap
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (!(e.OriginalSource is TextBox))
            {
                FocusManager.SetFocusedElement(this, null);
                Keyboard.ClearFocus();
            }

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Console.WriteLine("egg");
            StyleController cont = new StyleController();
            cont.UpdateColor();
        }
    }
}