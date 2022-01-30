namespace gamesense_webapp.Repositories
{
    using gamesense_webapp.Data;
    using gamesense_webapp.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class PublisherRepository : IPublisherRepository
    {
        private readonly ApplicationDbContext _context;
        public PublisherRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void AddPublisher(Publisher publisher)
        {
            _context.Publishers.Add(publisher);
            _context.SaveChanges();
        }

        public void Delete(int Id)
        {
            var publisher = _context.Publishers.FirstOrDefault(n => n.Id == Id);
            _context.Publishers.Remove(publisher);
            _context.SaveChanges();
        }

        public IEnumerable<Publisher> GetPublishers()
        {
            var publishers = _context.Publishers.ToList();

            return publishers;
        }

        public Publisher GetById(int Id)
        {
            var publisher = _context.Publishers.FirstOrDefault(n => n.Id == Id);

            return publisher;
        }

        public Publisher Update(int Id, Publisher updatedPublisher)
        {
            _context.Update(updatedPublisher);
            _context.SaveChanges();

            return updatedPublisher;
        }
    }
}
