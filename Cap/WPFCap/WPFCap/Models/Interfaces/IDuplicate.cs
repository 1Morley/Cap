using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFCap.Models.Interfaces
{
    public interface IDuplicate<T> where T : ICollectionModel
    {
        public T Duplicate(int newId);
        public void ResetValues();
    }
}
