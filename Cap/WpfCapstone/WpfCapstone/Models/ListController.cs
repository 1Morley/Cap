using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfCapstone.Models
{
    public static class ListController<T> where T : ICollectionModel
    {
        public static void AddModel(Collection<T> list, T input)
        {
            list.Add(input);
        }

        public static bool DeleteModel(Collection<T> list) {
            return false;
        }

        private static int GetNextProjectId(Collection<T> list) 
        {
            if(list.Count == 0)
            {
                return 1;
            }
            else
            {
                return list.Max(x => x.Id) + 1;
            }
        }
    }
}
