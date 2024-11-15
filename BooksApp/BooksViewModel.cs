using System.Collections.ObjectModel;
using System.ComponentModel;

namespace BooksApp.ViewModels
{
    public class BooksViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<Book> books;
        private Book selectedBook;

        public ObservableCollection<Book> Books
        {
            get { return books; }
            set
            {
                books = value;
                OnPropertyChanged("Books");
            }
        }

        public Book SelectedBook
        {
            get { return selectedBook; }
            set
            {
                selectedBook = value;
                OnPropertyChanged("SelectedBook");
            }
        }

        public BooksViewModel()
        {
            Books = new ObservableCollection<Book>();
        }

        public void AddBook(Book book)
        {
            Books.Add(book);
        }

        public void UpdateBook(Book oldBook, Book newBook)
        {
            int index = Books.IndexOf(oldBook);
            if (index != -1)
                Books[index] = newBook;
        }

        public void RemoveBook(Book book)
        {
            Books.Remove(book);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
