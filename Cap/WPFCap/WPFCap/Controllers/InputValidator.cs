using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFCap.Controllers
{
    static class InputValidator
    {
        public static bool ValidTitle(string title)
        {
            return !string.IsNullOrWhiteSpace(title);
        }

        public static bool ValidFile(string filePath)
        {
            return !string.IsNullOrWhiteSpace(filePath);
        }
    }
}
