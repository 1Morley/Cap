using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFCap.Models.Interfaces
{
    public interface ICollectionModel
    {
        public int Id { get; }
        public string Title { get; set; }
    }
}
