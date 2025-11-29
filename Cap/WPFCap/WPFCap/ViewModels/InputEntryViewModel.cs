using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFCap.Controllers;
using WPFCap.Models;
using WPFCap.Models.InputModels;

namespace WPFCap.ViewModels
{
    public class InputEntryViewModel
    {
        public InputEntryModel InputModel { get; set; }

        public RelayCommand InputLocalFile {  get; private set; }
        public InputEntryViewModel()
        {
            InputModel = new InputEntryModel();
            InputLocalFile = new RelayCommand(x =>
            {
                if(FileController.InputLocalFileName(out string fileName, out string filePath))
                {
                    InputModel.EntryLocalFile = filePath;
                }
            });
        }

        public bool ValidInputModel(out InputEntryModel entry)
        {
            entry = InputModel;
            return true;
        }
    }
}
