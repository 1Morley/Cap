using System;
using System.Collections.Generic;
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

        public const string DEFAULT_PROJECT_TITLE = "New Project";
        public const string DEFAULT_COVER_IMAGE = "Image.png";

        public ProjectModel(int id, string title, string coverImage)
        {
            Title = title;
            CoverImage = coverImage;
            Id = id;
        }


        public event PropertyChangedEventHandler? PropertyChanged;

        void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
