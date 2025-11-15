using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFCap.Models.Interfaces;
using System.Diagnostics;
using WPFCap.Controllers;


namespace WPFCap.Models
{
    class FileStrategy:IOpenStrategy
    {
        private string _filePath;
        public string FilePath
        {
            get
            {
                return _filePath;
            }
            set
            {
                if (InputValidator.ValidFile(value))
                {
                    _filePath = value;
                    UpdateProcess();
                }
            }
        }
        private Process PreparedProcess { get; set; }
        public FileStrategy(string filePath)
        {
            PreparedProcess = new Process();
            FilePath = filePath;
        }
        public void Open()
        {
            PreparedProcess.Start();
        }

        private void UpdateProcess()
        {
            PreparedProcess.StartInfo = new ProcessStartInfo()
            {
                UseShellExecute = true,
                FileName = FilePath
            };
        }
    }
}
