using Google.Apis.Auth.OAuth2;
using Google.Apis.Drive.v3;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFCap.Models;

namespace WPFCap.Controllers
{
    internal class GoogleController
    {

        private static GoogleController _instance;

        public static GoogleController Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_lock)
                    {
                        if (_instance == null)
                        {
                            _instance = new GoogleController();
                        }
                    }
                }
                return _instance;
            }
        }

        private static readonly object _lock = new object();

        static string[] Scopes = { DriveService.Scope.Drive };
        static string ApplicationName = "Cap";

        static string credPath = "credentials.json";
        static UserCredential Credentials;

        static DriveService Service;

        private GoogleController()
        {
            Credentials = GetCred();
            Service = new DriveService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = Credentials,
                ApplicationName = ApplicationName
            });
        }


        private UserCredential GetCred()
        {
            using (var stream = new FileStream(credPath, FileMode.Open, FileAccess.Read))
            {
                string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), ".credentials/drive-api-credentials.json");

                // Request user authentication
                return GoogleWebAuthorizationBroker.AuthorizeAsync(
                    GoogleClientSecrets.Load(stream).Secrets,
                    Scopes,
                    "user",
                    CancellationToken.None,
                    new FileDataStore(path, true)).Result;
            }

        }

        public Collection<GoogleFile> ListFiles()
        {
            var request = Service.Files.List();
            request.Fields = "nextPageToken, files(id, name, webViewLink)";
            var result = request.Execute();

            Collection<GoogleFile> files = new Collection<GoogleFile>();
            foreach (var file in result.Files)
            {
                files.Add(new GoogleFile(file));
            }
            return files;
        }

        public void OpenFile(Google.Apis.Drive.v3.Data.File file)
        {
            if (!string.IsNullOrEmpty(file.WebViewLink))
            {
                Process.Start(new ProcessStartInfo(file.WebViewLink) { UseShellExecute = true });
            }
            else
            {
                Console.WriteLine("FAILURE TO LOAD FILE");
            }

        }
    }
}
