using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFCap.Controllers;
using WPFCap.Models.Interfaces;

namespace WPFCap.Models
{
    public class GoogleStrategy : IOpenStrategy
    {
        private GoogleFile File {  get; set; } 
        public GoogleStrategy(GoogleFile file)
        {
            File = file;
        }
        public void Open()
        {
            GoogleController control = GoogleController.Instance;
            control.OpenFile(File.GetFile());
        }
    }
}
