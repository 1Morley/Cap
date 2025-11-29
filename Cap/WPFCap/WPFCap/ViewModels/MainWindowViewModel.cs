using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFCap.Models;

namespace WPFCap.ViewModels
{
    class MainWindowViewModel
    {
        public ProjectListViewModel ProjectListVM { get; set; }

        public ViewDisplay EntryCreateVD { get; private set; }
        public ViewDisplay ProjectCreateVD { get; private set; }
        public ViewDisplay EntryListVD { get; private set; }
        public ViewDisplay ProjectListVD { get; private set; }
        public ViewDisplay ToolbarListVD { get; private set; }
        
        public RelayCommand save {  get; set; }
        public RelayCommand CloseCommand {  get; set; }
        public MainWindowViewModel()
        {
            ProjectListVM = new ProjectListViewModel();
            EntryCreateVD = new HeightAdjustViewDisplay(new double[] {200,500}, new double[] { 500, 350 }, "Entry Create Window");
            ProjectCreateVD = new HeightAdjustViewDisplay(new double[] {500,500}, new double[] { 500, 350 }, "Project Create Window");
            EntryListVD = new HeightAdjustViewDisplay(new double[] { 0, 700 }, new double[] { 400, 550 }, "Entry List Window");
            ProjectListVD = new ViewDisplay(new double[] { 0, 0 }, "Project List Window");
            ToolbarListVD = new ViewDisplay(new double[] { 0, 200 }, "");
            save = new RelayCommand(x =>
            {
                Close();
            });
        }

        public void Close()
        {
            Console.WriteLine("CLOSE PROTOCAL CALLED");
            ProjectListVM.SaveProjectList();
        }
    }
}
