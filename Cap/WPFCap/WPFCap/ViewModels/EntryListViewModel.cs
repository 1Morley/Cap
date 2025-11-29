using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFCap.Controllers;
using WPFCap.Models;
using WPFCap.Models.InputModels;

namespace WPFCap.ViewModels
{
    public class EntryListViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        private EntryListModel EntryList {  get; set; }

        public ObservableCollection<EntryModel> Entries 
        { get
            {
                return EntryList.ModelList;
            } 
        }

        public InputEntryViewModel _inputEntryVM { get;private set; }
        public InputEntryViewModel? InputEntryVM
        {
            get { return _inputEntryVM; }
            private set
            {
                _inputEntryVM = value;
                OnPropertyChanged(nameof(InputEntryVM));
            }
        }
        public RelayCommand SelectEntryPrompt { get; private set; }
        public RelayCommand AddEntryPrompt { get; private set; }
        public RelayCommand AddEntry { get; private set; }
        public EntryListViewModel(int projectId)
        {
            EntryList = new EntryListModel(FileController.GetEntryList(projectId, out EntryModel selected));
            CreateCommands();
        }


        private void CreateCommands()
        {
            AddEntryPrompt = new RelayCommand(x =>
            {
                if(InputEntryVM == null)
                {
                    InputEntryVM = new InputEntryViewModel();
                    WindowController.Instance.CreateEntryVisible = true;
                }
                else
                {
                    InputEntryVM = null;
                    WindowController.Instance.CreateEntryVisible = false;
                }
            });
            SelectEntryPrompt = new RelayCommand(x =>
            {
                WindowController.Instance.SelectEntryVisible = !WindowController.Instance.SelectEntryVisible;
            });

            AddEntry = new RelayCommand(x =>
            {
                if (InputEntryVM != null && InputEntryVM.ValidInputModel(out InputEntryModel inputModel))
                {
                    EntryList.AddModel(inputModel);
                }
            });
        }
        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
