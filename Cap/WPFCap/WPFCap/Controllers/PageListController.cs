using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFCap.Controllers
{
    public class PageListController<T>
    {
        public Collection<T> FullList { get; set; }

        public ObservableCollection<T> ShownList { get; private set; }

        public int AmountOfItemsPerPage { get; set; }
        private int PageNumber { get; set; }

        public bool NextPageAvailible { get; private set;}
        public bool PrevPageAvailible { get; private set;}

        public PageListController(Collection<T> fullList, ObservableCollection<T> shownList, int amountOfItemsPerPage)
        {
            FullList = fullList;
            ShownList = shownList;
            AmountOfItemsPerPage = amountOfItemsPerPage;
            PageNumber = 0;
            UpdateShownList();
        }

        private void UpdateAvailibility(int start, int end)
        {
            PrevPageAvailible = !(start == 0);
            NextPageAvailible = !(end == FullList.Count - 1);
        }

        private void ResetShownList()
        {
            ShownList.Clear();
        }

        public void UpdateShownList()
        {
            GetRange(out int start, out int end);

            ResetShownList();
            for (int i = start; i <= end; i++)
            {
                if(i < FullList.Count)
                {
                    ShownList.Add(FullList.ElementAt(i));
                }
            }
            
            UpdateAvailibility(start, end);
        }

        public T GetNewestItem()
        {
            return FullList.Last();
        }

        private void GetRange(out int start, out int end)
        {
            start = PageNumber * AmountOfItemsPerPage;
            end = (AmountOfItemsPerPage - 1) + start;

            if (end >= FullList.Count)
            {
                end = (FullList.Count - 1);
                start = end - (AmountOfItemsPerPage - 1);
            }

            end = (end < 0) ? 0 : end;
            start = (start < 0) ? 0 : start;
        }

        public void NextPage()
        {
            int maxPg = (FullList.Count - AmountOfItemsPerPage + 1) / AmountOfItemsPerPage;
            if (PageNumber <= maxPg)
            {
                PageNumber++;
                UpdateShownList();
            }
        }

        public void PrevPage()
        {
            if (PageNumber > 0)
            {
                PageNumber--;
                UpdateShownList();
            }
        }

        public T GetSelectedItem(int index)
        {
            if(index < 0 ||  index >= FullList.Count)
            {
                return default;
            }
            return ShownList.ElementAt(index);
        }
    }
}
