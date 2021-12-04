using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeLibrary.Models
{
    internal interface ILibraryBookService // описывает классы которые будут использоваться для поиска книг
    {
        void GetData(Action<ObservableCollection<IBook>, Exception?> callback);
        IBook? GetBook(IBook getBook);
        void AddNewBook();
        void DeleteBook(IBook book);

    }
}
