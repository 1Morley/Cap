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
        DragItemController dragItemController;
        Point offset;
        public MainWindow()
        {
            InitializeComponent();
            dragItemController = new DragItemController(MainCanvas);

        }

        private void Window_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (!(e.OriginalSource is TextBox))
            {
                FocusManager.SetFocusedElement(this, null);
                Keyboard.ClearFocus();
            }

        }

        private void MainCanvas_DragOver(object sender, DragEventArgs e)
        {
            MainCanvas.Background = new SolidColorBrush(Color.FromArgb(100, 0, 0, 0));
            dragItemController.BackgroundDragOver(e);
        }

        private void DragWindow_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                dragItemController.DragMouseMove(e, (UIElement)sender);
            }
        }

        private void MainCanvas_Drop(object sender, DragEventArgs e)
        {
            dragItemController.BackgroundDrop(e);
        }
    }
}