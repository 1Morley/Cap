using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfCapstone.Models
{
    public class ProjectModel : INotifyPropertyChanged, ICollectionModel
    {
        private string _title;
        public string Title
        {
            get
            {
                return _title;
            }
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    _title = value;  
                }
                else
                {
                    _title = DEFAULT_PROJECT_TITLE;
                }
                OnPropertyChanged(nameof(Title));
            }
        }

        private string _coverImage;
        public string CoverImage
        {
            get
            {
                return _coverImage;
            }
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    _coverImage = value;
                }
                else
                {
                    _coverImage = DEFAULT_COVER_IMAGE;
                }
                OnPropertyChanged(nameof(CoverImage));
            }
        }
        public int Id { get; }

        public ObservableCollection<EntryModel> EntryList { get; private set; }

        public const string DEFAULT_PROJECT_TITLE = "New Project";
        public const string DEFAULT_COVER_IMAGE = "Image.png";

        public ProjectModel(){}
        public ProjectModel(int id, string title, string coverImage)
            : this(id, title, coverImage, new ObservableCollection<EntryModel>()) { AddEntryData(); }
        public ProjectModel(int id, string title, string coverImage, ObservableCollection<EntryModel> entryList)
        {
            Title = title;
            CoverImage = coverImage;
            Id = id;
            EntryList = entryList;
        }

        private void AddEntryData()
        {
            AddEntry(new InputEntryModel());
            AddEntry(new InputEntryModel());
            AddEntry(new InputEntryModel());
        }

        public void AddEntry(InputEntryModel inputEntry)
        {
            ListController<EntryModel>.AddModel(EntryList, inputEntry);
        }

        public void DeleteEntry(int inputId)
        {
            ListController<EntryModel>.DeleteModel(EntryList, inputId);
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
