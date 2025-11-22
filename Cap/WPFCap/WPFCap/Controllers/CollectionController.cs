using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using WPFCap.Models.Interfaces;

namespace WPFCap.Controllers
{
    public class CollectionController<T> where T : ICollectionModel
    {
        public ObservableCollection<T> ModelList { get; private set; }

        public CollectionController(ObservableCollection<T> modelList)
        {
            ModelList = modelList;
        }

        public bool IsRepeatTitle(string inputName, out string updateName)
        {
            string regex = ".+\\(\\d+\\)";
            Match match = Regex.Match(inputName, regex);
            string ending = "(hehe)";
            if (match.Success)
            {
                ending = "(youuuu >:( )";
            }
            updateName = $"{inputName} {ending}";
            return false;
        }

        public T AddModel(IDuplicate<T> inputModel)
        {
            int newId = GetNextModelId();
            T createdModel = inputModel.Duplicate(newId);
            if(IsRepeatTitle(createdModel.Title, out string newTitle))
            {
                createdModel.SetTitle(newTitle);
            }
            ModelList.Add(createdModel);
            return createdModel;
        }

        public bool DeleteModel(int modelId)
        {
            return DeleteModel(modelId, out T deletedModel);
        }
        private bool DeleteModel(int modelId, out T deletedModel)
        {
            deletedModel = FindModelById(modelId);

            if (deletedModel != null)
            {
                return ModelList.Remove(deletedModel);
            }
            return false;
        }
        private int GetNextModelId()
        {
            if (ModelList.Count == 0)
            {
                return 0;
            }
            else
            {
                return ModelList.Max(x => x.Id) + 1;
            }
        }

        public T FindModelById(int modelId)
        {
            return ModelList.FirstOrDefault(x => x.Id == modelId);
        }

        private bool CheckIndexInBounds(int newIndex, out int validIndex)
        {
            if (ModelList.Count != 0)
            {
                if (newIndex < 0)
                {
                    validIndex = 0;
                }
                else if (newIndex >= ModelList.Count)
                {
                    validIndex = ModelList.Count - 1;
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

        public void MoveModelToNewIndex(int modelId, int newIndex)
        {
            if (CheckIndexInBounds(newIndex, out newIndex))
            {
                if (DeleteModel(modelId, out T foundModel))
                {
                    ModelList.Insert(newIndex, foundModel);
                }

            }
        }
    }
}

