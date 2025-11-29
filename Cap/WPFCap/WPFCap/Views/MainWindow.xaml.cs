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
using WPFCap.ViewModels;

namespace WPFCap
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        AdjustPositionController positionControl;
        public MainWindow()
        {
            InitializeComponent();
            positionControl = new AdjustPositionController(MainCanvas);
        }

        private void Window_ClearFocusOnElement(object sender, MouseButtonEventArgs e)
        {
            if (!(e.OriginalSource is TextBox))
            {
                FocusManager.SetFocusedElement(this, null);
                Keyboard.ClearFocus();
            }
        }

        private void MainCanvas_DragOver(object sender, DragEventArgs e)
        {
            positionControl.BackgroundDragOver(e);
        }

        private void MainCanvas_Drop(object sender, DragEventArgs e)
        {
            positionControl.BackgroundDrop(e);
        }

        private void ViewWindow_MouseMove(object sender, MouseEventArgs e)
        {
            positionControl.DragMouseMove(e, (UIElement)sender);
        }
        private void TopLine_MouseDown(object sender, MouseButtonEventArgs e)
        {
            positionControl.MoveZoneMouseDown(e);
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            if (DataContext is MainWindowViewModel dataContext)
            {
                dataContext.Close();
            }
        }
    }
}