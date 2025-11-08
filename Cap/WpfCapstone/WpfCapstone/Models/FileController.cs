using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace WpfCapstone.Models
{
    class FileController
    {
        private readonly JsonSerializerOptions _jsonOptions = new()
        {
            WriteIndented = true,
            //PropertyNameCaseInsensitive = true
        };


        public async void SaveFile(ObservableCollection<ProjectModel> input)
        {
            try
            {
                using FileStream stream = File.Create("SaveTest.json");
                await JsonSerializer.SerializeAsync(stream, input, _jsonOptions);
            }
            catch {}

        }

        public ObservableCollection<ProjectModel> LoadFile()
        {
            if(File.Exists("SaveTest.json"))
            {
                try
                {
                    using FileStream stream = File.OpenRead("SaveTest.json");
                    return JsonSerializer.Deserialize<ObservableCollection<ProjectModel>>(stream, _jsonOptions);
                }
                catch {}
            }

            return new ObservableCollection<ProjectModel>();

        }
    }
}
