using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFCap.Models.Interfaces;

namespace WPFCap.Models
{
    public class LinkStrategy : IOpenStrategy
    {
        private string _path;
        public string Path
        {
            get
            {
                return _path;
            }
            set
            {
                _path = value;
                UpdateProcess();
            }
        }
        private Process PreparedProcess { get; set; }
        public LinkStrategy(string path)
        {
            PreparedProcess = new Process();
            Path = path;
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
                FileName = Path
            };
        }
    }
}
