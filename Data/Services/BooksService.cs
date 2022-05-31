using BookApi.Data.Model;
using BookApi.Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookApi.Data.Services
{
    public class BooksService
    {
        private AppDbContext _context;
        public BooksService(AppDbContext context)
        {
            _context = context;
        }

        //Method to post a user data to the database
        public void AddBookWithAuthors(BookVM book)
        {
            //Creating a Book Object
             var _book = new Book()
            {
                Title = book.Title,
                Description = book.Description,
                IsRead = book.IsRead,
                DateRead = book.IsRead ? book.DateRead.Value : null,
                Rate = book.IsRead ?  book.Rate.Value : null,
                Genre = book.Genre,
                CoverURL = book.CoverURL,
                DateAdded = DateTime.Now,
                PublisherId = book.publisherId
            };

            _context.Books.Add(_book);
            _context.SaveChanges();

            foreach (var id in book.AuthorIds)
            {
                var _book_author = new Book_Author()
                {
                    BookId = _book.Id,
                    AuthorId = id
                };
                _context.Book_Authors.Add(_book_author);
                _context.SaveChanges();
            }
        }

        //Method to get all records from the database
        public List<Book> GetAllBooks()
        {
            return _context.Books.ToList();
        }

        //getting a single book
        public BookWithAuthorsVM GetABook(int bookId)
        {
            var _bookWithAuthors = _context.Books.Where(n => n.Id == bookId).Select(book => new BookWithAuthorsVM()
            {
                Title = book.Title,
                Description = book.Description,
                IsRead = book.IsRead,
                DateRead = book.IsRead ? book.DateRead.Value : null,
                Rate = book.IsRead ? book.Rate.Value : null,
                Genre = book.Genre,
                CoverURL = book.CoverURL,
                publisherName = book.Publisher.Name,
                AuthorNames = book.Book_Authors.Select(n => n.Authors.FullName).ToList()
            }).FirstOrDefault();

            return _bookWithAuthors;
        }

        //Updating an exisiting book
        public Book UpdateBook(int bookId, BookVM book)
        {
            var _book = _context.Books.Find(bookId);

            if (_book != null)
            {
                _book.Title = book.Title;
                _book.Description = book.Description;
                _book.IsRead = book.IsRead;
                _book.DateRead = book.IsRead ? book.DateRead.Value : null;
                _book.Rate = book.IsRead ? book.Rate.Value : null;
                 _book.Genre = book.Genre;
                _book.CoverURL = book.CoverURL;

                _context.SaveChanges();
            }
            return _book;
        }

        //Deleting an existing book
        public void DeleteBookById(int BookId)
        {
            var deletedBook = _context.Books.Find(BookId);

            if (deletedBook != null)
            {
                _context.Books.Remove(deletedBook);
                _context.SaveChanges();
            }
        }
    }
}
