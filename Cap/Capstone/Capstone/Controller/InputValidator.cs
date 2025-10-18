using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.Controller
{
    internal static class InputValidator
    {
        public static bool IsValidString(string testString) 
        {
            return !string.IsNullOrEmpty(testString);
        }
    }
}
