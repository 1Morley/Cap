using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using WPFCap.Controllers;
using WPFCap.Models.InputModels;
using WPFCap.Models.Interfaces;

namespace WPFCap.Models
{
    public class ProjectModel : INotifyPropertyChanged,ICollectionModel
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        public int Id { get; }

        private string _title;
        public string Title
        {
            get
            {
                return _title;
            }
            private set
            {
                _title = value;
                OnPropertyChanged(nameof(Title));
            }
        }

        private ImageSource _coverImage;
        public ImageSource CoverImage
        {
            get
            {
                return _coverImage;
            }
            set
            {
                _coverImage = value;
                OnPropertyChanged(nameof(CoverImage));
            }
        }

        public CollectionController<EntryModel> EntryList { get; private set; }

        public ProjectModel() { }

        public ProjectModel(int id, string title, ImageSource cover)
        {
            Id = id;
            Title = title;
            CoverImage = cover;
            EntryList = new CollectionController<EntryModel>(new ObservableCollection<EntryModel>());

            InputEntryModel inputEntry = new InputEntryModel();
            EntryList.AddModel(inputEntry);
            inputEntry.Title = "egggg";
            EntryList.AddModel(inputEntry);
            inputEntry.Title = "Test";
            EntryList.AddModel(inputEntry);
            EntryList.AddModel(inputEntry);
        }
        public void SetTitle(string title)
        {
            Title = title;
        }

        void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
