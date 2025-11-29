using Google.Apis.Drive.v3.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFCap.Models
{
    public class GoogleFile
    {
        public string FileName { get; private set; }
        public string Id { get; private set; }
        public string WebViewLink { get; private set; }

        public GoogleFile(string fileName, string id, string webViewLink)
        {
            FileName = fileName;
            Id = id;
            WebViewLink = webViewLink;
        }

        public GoogleFile(File file)
        {
            FileName = file.Name;
            Id = file.Id;
            WebViewLink = file.WebViewLink;
        }

        public File GetFile()
        {
            return new File() { Name = FileName, Id = Id, WebViewLink = WebViewLink };
        }
    }
}
