using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using WPFCap.Models.Interfaces;

namespace WPFCap.Models
{
    class FileEntryModel:EntryModel
    {
        private IOpenStrategy OpenFunction {  get; set; }

        public RelayCommand OpenCommand { get; private set; }
        public FileEntryModel():base() {}

        public FileEntryModel(int id, string title, string? entryNotes, IOpenStrategy function)
            : base(id, title, entryNotes)
        {
            OpenFunction = function;
            CreateCommands();
        }

        private void CreateCommands()
        {
            OpenCommand = new RelayCommand(x =>
            {
                OpenFunction.Open();
            });
        }

        public void test()
        {
            //string filepath = @"C:\Users\Bug\OneDrive\Documents\year3Q1\capstone\notes\TEST.txt";

            //Process pro = new Process();
            //pro.StartInfo = new ProcessStartInfo()
            //{
            //    UseShellExecute = true,
            //    FileName = filepath
            //};
            //pro.Start();

            //string filepath = @"C:\Users\Bug\OneDrive\Documents\year3Q1\capstone\notes\TEST.txt";

            //IOpenStrategy test = new FileStrategy(filepath);
            //FileEntryModel entryTest = new FileEntryModel(1, "tit", "blahblah", test);
            //entryTest.test();
            OpenFunction.Open();
        }

        
    }
}
