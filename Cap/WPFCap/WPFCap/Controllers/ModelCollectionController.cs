using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Media.Media3D;
using WPFCap.Models.Interfaces;

namespace WPFCap.Controllers
{
    public class ModelCollectionController<T> where T: ICollectionModel
    {
        public ObservableCollection<T> ModelList { get; private set; }

        public ModelCollectionController(ObservableCollection<T> modelList)
        {
            SetFullList(modelList);
        }

        public bool IsRepeatTitle(string inputName)
        {
            T found = ModelList.FirstOrDefault(x => x.Title == inputName);
            return (found != null);
        }

        private string CreateNewTitle(string inputTitle)
        {
            string regex = ".+(\\((\\d+)\\))";
            Match match = Regex.Match(inputTitle, regex);
            string ending = "(0)";
            if (match.Success && int.TryParse(match.Groups[2].Value, out int foundNumber))
            {
                string oldEnding = match.Groups[1].Value;
                int newLength = inputTitle.Length - oldEnding.Length;
                inputTitle = inputTitle.Substring(0,newLength);
                ending = $"({foundNumber + 1})";
            }
            return $"{inputTitle} {ending}";
        }

        public T AddModel(IDuplicate<T> inputModel)
        {
            int newId = GetNextModelId();
            T createdModel = inputModel.Duplicate(newId);
            return AddBasicModel(createdModel);
        }

        public T AddBasicModel(T inputModel)
        {
            if (inputModel != null)
            {
                while (IsRepeatTitle(inputModel.Title))
                {
                    inputModel.Title = CreateNewTitle(inputModel.Title);
                }
                ModelList.Add(inputModel);
                return inputModel;
            }
            return default;
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

        public void SetFullList(ObservableCollection<T> modelList)
        {
            ModelList = modelList;
        }
        public bool IsEmpty()
        {
            return ModelList == null || ModelList.Count == 0;
        }

        
    }
}
