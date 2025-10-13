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

        private void Add_Entry_Click(object sender, EventArgs e)
        {
            Button? clickedButt = sender as Button;
            if (clickedButt != null) { 
                int buttId;
                if (int.TryParse(clickedButt.CommandParameter.ToString(), out buttId))
                {
                    controller.addEntryByProjectIdClick(buttId);
                }
            }
            
        }

        //private void Test_Click(object sender, EventArgs e)
        //{
        //}

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
