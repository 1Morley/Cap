using Google.Apis.Auth.OAuth2;
using Google.Apis.Drive.v3;
using Google.Apis.Drive.v3.Data;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Windows;

namespace WPFCap.Controllers
{
    public class TestGoogle
    {
        static string[] Scopes = { DriveService.Scope.Drive };
        static string ApplicationName = "Cap";

        static string credPath = "credentials.json";
        static UserCredential cred;

        static DriveService service;
        public TestGoogle()
        {
            Init();
        }

        private void Init()
        {
            cred = GetCred();
            service = new DriveService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = cred,
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

        public void listFiles()
        {
            var request = service.Files.List();
            request.Fields = "nextPageToken, files(Id, name, WebViewLink)";
            var result = request.Execute();

            foreach (var file in result.Files)
            {
                Console.WriteLine($"File ID: {file.Id}, File Name: {file.Name}");
                if (file.Name == "thing")
                {
                    OpenFile(file);
                    
                }
            }
        }

        public void OpenFile(Google.Apis.Drive.v3.Data.File file)
        {
            if (!string.IsNullOrEmpty(file.WebViewLink))
            {
                Process.Start(new ProcessStartInfo(file.WebViewLink) { UseShellExecute = true });
            }
            else
            {
                Console.WriteLine("FUCK");
            }

        }
    }
}
