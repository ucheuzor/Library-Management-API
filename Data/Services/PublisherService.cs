using BookApi.Data.Model;
using BookApi.Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookApi.Data.Services
{
    public class PublisherService
    {
        private AppDbContext _context;
        public PublisherService(AppDbContext context)
        {
            _context = context;
        }

        public Publisher AddPublisher(PublisherVM publisher)
        {
            var publishInfo = new Publisher()
            {
                Name = publisher.Name
            };

            _context.Publishers.Add(publishInfo);
            _context.SaveChanges();

            return publishInfo;
        }

        //service to get publisher by Ids 
        public Publisher GetPublisherById(int id) => _context.Publishers.FirstOrDefault(x => x.Id == id);

        public PublisherWithBooksAndAuthorsVM GetPublisherData(int publisherId)
        {
            var _publisherData = _context.Publishers.Where(n => n.Id == publisherId)
                                         .Select(n => new PublisherWithBooksAndAuthorsVM()
                                         {
                                             Name = n.Name,
                                             BookAuthors = n.Books.Select(n => new BookAuthorVM()
                                             {
                                                 BookName = n.Title,
                                                 BookAuthors = n.Book_Authors.Select(x => x.Authors.FullName).ToList()
                                             }).ToList()
                                         }).FirstOrDefault();
            return _publisherData;
        }

        public void DeletePublisherById(int id)
        {
            var _publisher = _context.Publishers.FirstOrDefault(n => n.Id == id);

            if (_publisher != null)
            {
                _context.Publishers.Remove(_publisher);
                _context.SaveChanges();
            }
        }
    }
}
