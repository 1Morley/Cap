using Capstone.Controller;

namespace Capstone
{
    public partial class MainPage : ContentPage
    {
        int count = 0;
        ProjectViewModel controller;
        
        public MainPage()
        {
            InitializeComponent();
            controller = new ProjectViewModel();
            this.BindingContext = controller;
        }

        private void Add_Project_Click(object sender, EventArgs e)
        {
            controller.AddProject();
        }

        private void Add_Entry_Click(object sender, EventArgs e)
        {
            int projectId = getIdFromButton(sender);
            if (projectId != -1) {
                controller.AddEntryByProjectId(projectId);
            }            
        }

        private void Delete_Project_Click(object sender, EventArgs e)
        {
            int projectId = getIdFromButton(sender);
            if (projectId != -1)
            {
                controller.DeleteProject(projectId);
            }
        }

        private void Delete_Entry_Click(object sender, EventArgs e)
        {
            int entryId = getIdFromButton(sender);
            if (entryId != -1)
            {
                int projectId;
                if (int.TryParse(SelectedProjectIdLabel.Text, out projectId)) { 
                    controller.DeleteEntry(projectId, entryId);
                }

            }

        }

        private int getIdFromButton(object sender) {
            Button? clickedButt = sender as Button;
            int buttId = -1;
            if (clickedButt != null)
            {
                int.TryParse(clickedButt.CommandParameter.ToString(), out buttId);
            }
            return buttId;
        }

        private void Test_Page_Click(object sender, EventArgs e)
        {
            Navigation.PushAsync(new TestPage());
        }

        private void Swap_Project_Index(object sender, EventArgs e) 
        {
            int projectId = getIdFromButton(sender);
            if (projectId != -1) {
                int newPosition;
                var textBox = NewPositionEntry;
               if (int.TryParse(textBox.Text, out newPosition)) {
                    controller.MoveProjectToNewIndex(projectId, newPosition);
                }
                textBox.Text = String.Empty; ;
            }
        }
    }
}
