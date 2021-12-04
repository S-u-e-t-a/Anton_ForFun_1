using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeLibrary.Models
{
    internal class HomeLibraryService : ILibraryBookService
    {
        #region Varible
        private ObservableCollection<IBook> _books;
        #endregion

        #region Constructors

        public HomeLibraryService()
        {
            _books = new ObservableCollection<IBook>();
            _books.Add(new Book { Author = "Test1", Title = "Test1", Year = new DateTime(2013, 9, 10), Count = 3, });
            _books.Add(new Book { Author = "Test2", Title = "Test2", Year = new DateTime(1999, 7, 8), Count = 2 });
        }

        public void AddNewBook()
        {
            _books.Add(new Book { Author = "Test Author", Title = "Test Title", Year = DateTime.Now, Count = 1 });
        }

        public void DeleteBook(IBook book)
        {
            if (book == null)
                return;

            _books.Remove(book);
        }

        public IBook? GetBook(IBook getBook)
        {
            if (getBook == null)
                return null;

            return _books.FirstOrDefault(book => book.Author == getBook.Author
                                       && book.Title == getBook.Title
                                       && book.Year == getBook.Year);
        }

        public void GetData(Action<ObservableCollection<IBook>, Exception?> callback)
        {
            callback(_books, null);
        }
        #endregion
        #region Methods

        #endregion
    }
}
