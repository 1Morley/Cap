using Google.Apis.Drive.v3.Data;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WPFCap.Models.Interfaces;

namespace WPFCap.Controllers
{
    public class PageListController<T> : ModelCollectionController<T> where T : ICollectionModel
    {
        new public ObservableCollection<T> ModelList { 
            get
            {
                return ShownList;
            } 
        }
        public ObservableCollection<T> FullList
        {
            get
            {
                return base.ModelList;
            }
            set
            {
                base.SetFullList(value);
                UpdateRange();
            } 
        }




        private ObservableCollection<T> ShownList { get; set; }

        public int AmountOfItemsPerPage { get; set; }
        private int PageNumber {  get; set; }

        private int StartIndex { get; set; }
        private int EndIndex { get; set; }

        public bool PrevPageAvailible
        {
            get
            {
                return !(StartIndex == 0);
            }
        }
        public bool NextPageAvailible
        {
            get
            {
                return !(EndIndex >= (base.ModelList.Count - 1));
            }
        }

        public int FullListLength { 
            get
            {
                return base.ModelList.Count;
            } 
        }
        public PageListController(ObservableCollection<T> modelList, int itemPerPage)
            :base(modelList) 
        {
            AmountOfItemsPerPage = itemPerPage;
            PageNumber = 0;
            ShownList = new ObservableCollection<T>();
            UpdateRange();
        }
    
        private void ResetShownList()
        {
            ShownList.Clear();
        }

        private void UpdateShownList()
        {
            ResetShownList();
            for (int i = StartIndex; i <= EndIndex; i++)
            {
                if (i < FullListLength)
                {
                    ShownList.Add(base.ModelList.ElementAt(i));
                }
            }

        }

        private void UpdateRange()
        {
            StartIndex = PageNumber * AmountOfItemsPerPage;
            EndIndex = (AmountOfItemsPerPage - 1) + StartIndex;

            if (EndIndex >= FullListLength)
            {
                EndIndex = (FullListLength - 1);
                StartIndex = EndIndex - (AmountOfItemsPerPage - 1);
                StartIndex = (StartIndex < 0) ? 0 : StartIndex;
            }

            UpdateShownList();
        }
       
        public void NextPage()
        {
            int maxPg = (FullListLength - AmountOfItemsPerPage + 1) / AmountOfItemsPerPage;
            if (PageNumber <= maxPg)
            {
                PageNumber++;
                UpdateRange();
            }
        }

        public void PrevPage()
        {
            if (PageNumber > 0)
            {
                PageNumber--;
                UpdateRange();
            }
        }

        public T GetSelectedItem(int index)
        {
            if (index < 0 || index >= FullListLength)
            {
                return default;
            }
            return ShownList.ElementAt(index);
        }

        new public T AddModel(IDuplicate<T> inputModel)
        {
            T model = base.AddModel(inputModel);
            UpdateRange();
            return model;
        }

        new public T AddBasicModel(T inputModel)
        {
            T model = base.AddBasicModel(inputModel);
            UpdateRange();
            return model;
        }

        new public bool DeleteModel(int modelId)
        {
            bool result = base.DeleteModel(modelId);
            UpdateRange();
            return result;
        }



        
        new public void MoveModelToNewIndex(int modelId, int newIndex)
        {
            base.MoveModelToNewIndex(modelId, newIndex);
            UpdateShownList();
        }
    }
}
