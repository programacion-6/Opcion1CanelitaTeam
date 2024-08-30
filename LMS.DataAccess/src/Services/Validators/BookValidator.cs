using LMS.DataAccess.Systems.Entities;

namespace LMS.DataAccess.Services.Validators
{
    public class BookValidator
    {
        private const int ISBN_LENGTH = 10;
        private const int MIN_FIELD_LENGTH = 3;
        private const int MAX_FIELD_LENGTH = 50;

        public bool ValidateBook(Book book)
        {
            return ValidateTitle(book.Title) &&
                   ValidateAuthor(book.Author) &&
                   ValidateGenre(book.Genre) &&
                   ValidateISBN(book.ISBN) &&
                   ValidateStock(book.Stock);
        }

        public bool ValidateTitle(string title)
        {
            return !string.IsNullOrEmpty(title) && title.Length >= MIN_FIELD_LENGTH && title.Length <= MAX_FIELD_LENGTH;
        }

        public bool ValidateAuthor(string author)
        {
            return !string.IsNullOrEmpty(author) && author.Length >= MIN_FIELD_LENGTH && author.Length <= MAX_FIELD_LENGTH;
        }

        public bool ValidateGenre(string genre)
        {
            return !string.IsNullOrEmpty(genre) && genre.Length >= MIN_FIELD_LENGTH && genre.Length <= MAX_FIELD_LENGTH;
        }

        public bool ValidateISBN(string isbn)
        {
            return !string.IsNullOrEmpty(isbn) && isbn.Length == ISBN_LENGTH;
        }

        public bool ValidateStock(int stock)
        {
            return stock > 0;
        }

        public bool ValidateUpdateParameters(string title, string? newTitle = null, string? newAuthor = null, string? newGenre = null, int? newStock = null)
        {
            return ValidateTitle(title) &&
                   (newTitle == null || ValidateTitle(newTitle)) &&
                   (newAuthor == null || ValidateAuthor(newAuthor)) &&
                   (newGenre == null || ValidateGenre(newGenre)) &&
                   (newStock == null || ValidateStock((int)newStock));
        }
    }
}
