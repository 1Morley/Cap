using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Documents;
using WPFCap.Controllers;
using WPFCap.Models;
using WPFCap.Models.Interfaces;

namespace WPFCap.ViewModels
{
    public class PageSelectViewModel<T> : INotifyPropertyChanged where T : ICollectionModel
    {
        private T _selectedItem;
        public T SelectedItem
        {
            get
            {
                return _selectedItem;
            }
            protected set
            {
                _selectedItem = value;
                OnPropertyChanged(nameof(SelectedItem));
            }
        }

        public ObservableCollection<T> GetFullList()
        {
            return PageController.FullList;
        }


        public ObservableCollection<T> FullList 
        {
            get
            {
                return PageController.FullList;
            }
            set
            {
                PageController.FullList = value;
                OnPropertyChanged(nameof(FullList));
                OnPropertyChanged(nameof(ModelList));
                CheckActiveOptions();
            }
        }





        public ObservableCollection<T> ModelList
        {
            get
            {
                return PageController.ModelList;
            }
        }
        private PageListController<T> PageController { get; set; }
        public RelayCommand NextPageCommand { get; private set; }
        public RelayCommand PrevPageCommand { get; private set; }
        public RelayCommand SelectItemCommand { get; set; }
        public Visibility NextActive
        {
            get
            {
                if (PageController.NextPageAvailible)
                {
                    return Visibility.Visible;
                }
                return Visibility.Collapsed;
            }
        }
        public Visibility PrevActive
        {
            get
            {
                if (PageController.PrevPageAvailible)
                {
                    return Visibility.Visible;
                }
                return Visibility.Collapsed;
            }
        }

        public int AmountOfItemsPerPage
        { get
            {
                return PageController.AmountOfItemsPerPage;
            } 
        }


        public PageSelectViewModel(PageListController<T> pageListController)
        {
            PageController = pageListController;
            SetSelectedItem(0);
            CreateCommands();
            CheckActiveOptions();
        }
        private void CreateCommands()
        {
            NextPageCommand = new RelayCommand(x =>
            {
                PageController.NextPage();
                CheckActiveOptions();
            }
            );
            PrevPageCommand = new RelayCommand(x =>
            {
                PageController.PrevPage();
                CheckActiveOptions();
            }
            );
            SelectItemCommand = new RelayCommand(x =>
            {
                if (RelayCommand.ParseResultNumber(x, out int inputId))
                {
                    SetSelectedItem(inputId);
                }
            });
        }

        public ObservableCollection<T> GetModelList()
        {
            return PageController.ModelList;
        }
        
        public T GetItemFromShownIndex(int index)
        {
            return PageController.GetSelectedItem(index);
        }

        private void CheckActiveOptions()
        {
            OnPropertyChanged(nameof(NextActive));
            OnPropertyChanged(nameof(PrevActive));
        }

        public void SetSelectedItem(int index)
        {
            SelectedItem = PageController.GetSelectedItem(index);
        }

        public T AddModel(IDuplicate<T> model)
        {
            SelectedItem = PageController.AddModel(model);
            CheckActiveOptions();
            return SelectedItem;
        }
        public T AddBasicModel(T model)
        {
            SelectedItem = PageController.AddBasicModel(model);
            CheckActiveOptions();
            return SelectedItem;
        }

        public bool DeleteModel(int inputId)
        {
            bool result = PageController.DeleteModel(inputId);
            CheckActiveOptions();
            return result;
        }

        public void SelectModel(int index)
        {
            SelectedItem = PageController.GetSelectedItem(index);
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
