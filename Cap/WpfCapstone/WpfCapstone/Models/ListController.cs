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
        public static T AddModel(Collection<T> list, IDuplicate<T> inputModel)
        {
            int newId = GetNextModelId(list);
            T createdModel = inputModel.Duplicate(newId);
            list.Add(createdModel);
            return createdModel;
        }

        public static bool DeleteModel(Collection<T> list, int modelId) {
            return DeleteModel(list,modelId,out T deletedModel);
        }
        private static bool DeleteModel(Collection<T> list, int modelId,out T deletedModel) {
            deletedModel = FindModelById(list,modelId);

            if (deletedModel != null)
            {
                return list.Remove(deletedModel);
            }
            return false;
        }

        public static void MoveModelToNewIndex(Collection<T> list, int modelId, int newIndex) 
        {
            if(CheckIndexInBounds(list, newIndex, out newIndex)) 
            {
                if(DeleteModel(list, modelId, out T foundModel))
                {
                    list.Insert(newIndex, foundModel);
                }
            
            }
        }
        private static int GetNextModelId(Collection<T> list) 
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

        public static T FindModelById(Collection<T> list, int modelId) 
        {
            return list.FirstOrDefault(x => x.Id == modelId);
        }



        private static bool CheckIndexInBounds(Collection<T> list, int newIndex, out int validIndex) 
        {
            if (list.Count != 0)
            { 
                if(newIndex < 0) 
                {
                    validIndex = 0;
                }
                else if(newIndex >= list.Count)
                {
                    validIndex = list.Count - 1;
                }
                else 
                {
                    validIndex = newIndex;
                }
                return true;
            }
            validIndex = 0;
            return false;
        }
    }
}
