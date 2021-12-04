using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF_MVVM_Classes;
using HomeLibrary.Models;
using System.Collections.ObjectModel;
using System.Runtime.CompilerServices;
using System.Windows;

namespace HomeLibrary.ViewModel
{
    internal class MainViewModel : ViewModelBase
    {
        private readonly ILibraryBookService _libraryDataService;

        public MainViewModel(ILibraryBookService libraryBookService)
        {
            _libraryDataService = libraryBookService;
            _libraryDataService.GetData((items, error) => { Books = items; });
        }
        #region variable
        private IBook _selectedBook;
        #endregion
        #region Public Properties
        public IVisitorRepository VisitorRepository { get; set; }
        public ObservableCollection<IBook> Books { get; set; }

        public IBook SelectedBook
        {
            get { return _selectedBook; }
            set
            {
                _selectedBook = value;
                OnPropertyChanged();
            }
        }
        #endregion
        #region Methods
        public void PrintBook(ILibraryBookService libraryBookService)
        {
            if (libraryBookService == null)
                throw new ArgumentNullException(nameof(libraryBookService));
            libraryBookService.GetData((items, error) =>
            {
                var books = items.Aggregate(string.Empty, (current, book) => current + (book.Title + Environment.NewLine));
                MessageBox.Show(books);
            });
        }
        private void AddNewBook(object args)
        {
            _libraryDataService.AddNewBook();
        }
        private void RemoveBook(object args)
        {
            Books.Remove(SelectedBook);
        }
        private bool CanRemoveBook(object args)
        {
            if (SelectedBook == null)
                return false;
            var book = _libraryDataService.GetBook(SelectedBook);
            if (book == null)
                return false;

            return true;
        }
        #endregion
        #region Commands

        private RelayCommand _addBookCommand;
        public RelayCommand AddBookCommand
        {
            get
            {
                return _addBookCommand ??= new RelayCommand(AddNewBook);
            }

        }

        private RelayCommand _deleteBookCommand;
        public RelayCommand DeleteBookCommand
        {
            get
            {
                return _deleteBookCommand ??= new RelayCommand(RemoveBook, CanRemoveBook);
            }

        }
        #endregion
    }
}
