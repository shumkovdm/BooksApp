using BooksApp.ViewModels;
using System.Windows;

namespace BooksApp
{
    public partial class MainWindow : Window
    {
        public BooksViewModel ViewModel { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            ViewModel = new BooksViewModel();
            DataContext = ViewModel;
        }

        private void AddBookButton_Click(object sender, RoutedEventArgs e)
        {
            var bookEditor = new BookEditorWindow(new Book());
            if (bookEditor.ShowDialog() == true)
            {
                ViewModel.AddBook(bookEditor.Book);
            }
        }

        private void EditBookButton_Click(object sender, RoutedEventArgs e)
        {
            if (ViewModel.SelectedBook != null)
            {
                var bookEditor = new BookEditorWindow(ViewModel.SelectedBook);
                if (bookEditor.ShowDialog() == true)
                {
                    ViewModel.UpdateBook(ViewModel.SelectedBook, bookEditor.Book);
                }
            }
            else
            {
                MessageBox.Show("Выбери книгу для редактирования.", "Ошибка =/", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void RemoveBookButton_Click(object sender, RoutedEventArgs e)
        {
            if (ViewModel.SelectedBook != null)
            {
                ViewModel.RemoveBook(ViewModel.SelectedBook);
            }
            else
            {
                MessageBox.Show("Выбери книгу для удаления.", "Ошибка =(", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}