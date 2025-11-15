using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using WPFCap.Controllers;
using WPFCap.Models;

namespace WPFCap.ViewModels
{
    public abstract class PageSelectViewModel<T> : INotifyPropertyChanged
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
        public int GetAmountPerPage
        {
            get
            {
                return PageController.AmountOfItemsPerPage;
            }
        }
        private PageListController<T> PageController { get; set; }
        public RelayCommand NextPageCommand { get; private set; }
        public RelayCommand PrevPageCommand { get; private set; }
        public RelayCommand SelectItemCommand { get; protected set; }
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


        public PageSelectViewModel(Collection<T> FullList, ObservableCollection<T> ShownList, int AmountOfItemsPerPage)
        {
            PageController = new PageListController<T>(FullList, ShownList, AmountOfItemsPerPage);
            SetSelectedItem(0);
            CreateCommands();
            UpdateShownList();
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

        public ObservableCollection<T> GetShownList()
        {
            return PageController.ShownList;
        }
        public Collection<T> GetFullList()
        {
            return PageController.FullList;
        }
        public T GetItemFromShownIndex(int index)
        {
            return PageController.GetSelectedItem(index);
        }

        public void UpdateShownList()
        {
            PageController.UpdateShownList();
            CheckActiveOptions();
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

        public void SetToNewestItem()
        {
            SelectedItem = PageController.GetNewestItem();
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
