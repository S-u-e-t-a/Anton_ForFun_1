using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeLibrary.Models
{
    internal interface IBook
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public DateTime Year { get; set; }
        public int Count { get; set; }
    }
}
