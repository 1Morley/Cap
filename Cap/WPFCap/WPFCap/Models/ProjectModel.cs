using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFCap.Models.Interfaces;

namespace WPFCap.Models
{
    public class ProjectModel : INotifyPropertyChanged, ICollectionModel
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
            set
            {
                _title = value;
                OnPropertyChanged(nameof(Title));
            }
        }

        private ImageModel _coverImage;
        public ImageModel CoverImage
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


        public ProjectModel() { }
        public ProjectModel(int id, string title, ImageModel cover)
        {
            Id = id;
            Title = title;
            CoverImage = cover;
        }

        void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
