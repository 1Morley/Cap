using Capstone.Controller;

namespace Capstone
{
    public partial class MainPage : ContentPage
    {
        int count = 0;
        ProjectController controller;
        
        public MainPage()
        {
            InitializeComponent();
            controller = new ProjectController();
            this.BindingContext = controller;
        }

        private void Add_Project_Click(object sender, EventArgs e)
        {
            controller.addProjectClick();
        }

        private void Test_Click(object sender, EventArgs e)
        {
        }

        //private void OnCounterClicked(object? sender, EventArgs e)
        //{
        //    count++;

        //    if (count == 1)
        //        CounterBtn.Text = $"Clicked {count} time";
        //    else
        //        CounterBtn.Text = $"Clicked {count} times";

        //    SemanticScreenReader.Announce(CounterBtn.Text);
        //}


    }
}
