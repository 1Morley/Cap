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
    class FileStrategy:LinkStrategy
    {
        public FileStrategy(string filePath)
            : base(filePath){}

    }
}
