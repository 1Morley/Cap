using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace WPFCap.ViewModels
{
    internal class DragItemController
    {
        private Canvas BackgroundObject {  get; set; }
        private bool TransparentBackground { get; set; }
        private Point MouseOffset { get; set; }
        private UIElement DragObject { get; set; }
        public DragItemController(Canvas backgroundObject)
        {
            BackgroundObject = backgroundObject;
            MouseOffset = new Point() { X = 10, Y = 10};
            TransparentBackground = backgroundObject.Background == null;

            //if (backgroundObject.Background is SolidColorBrush brush)
            //{
            //    TransparentBackground = (brush.Color == Colors.Transparent);
            //}
        }

        public void BackgroundDragOver(DragEventArgs e)
        {
            Point mousePosition = e.GetPosition(BackgroundObject);

            if (TransparentBackground)
            {
                BackgroundObject.Background = new SolidColorBrush(Color.FromArgb(1, 0, 0, 0));
            }
            if (DragObject != null)
            {
                Canvas.SetLeft(DragObject, mousePosition.X - MouseOffset.X);
                Canvas.SetTop(DragObject, mousePosition.Y - MouseOffset.Y);
            }
        }

        public void BackgroundDrop(DragEventArgs e)
        {
            if (TransparentBackground)
            {
                BackgroundObject.Background = new SolidColorBrush(Colors.Transparent);
            }
            e.Data.GetData(DataFormats.Serializable);
        }

        public void DragMouseMove(MouseEventArgs e, UIElement dragObject)
        {
            DragObject = dragObject;
            MouseOffset = e.GetPosition(DragObject);
            DragDrop.DoDragDrop(DragObject, DragObject, DragDropEffects.Move);
        }

    }
}
