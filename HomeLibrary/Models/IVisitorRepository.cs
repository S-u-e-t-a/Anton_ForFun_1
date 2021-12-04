using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeLibrary.Models
{
    internal interface IVisitorRepository // используется для получения информации о посетителях библиотеки
    {
        List<Visitor> GetAll();
    }
}
