namespace gamesense_webapp.Repositories
{
    using gamesense_webapp.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public interface IPublisherRepository
    {
        IEnumerable<Publisher> GetPublishers();
        void AddPublisher(Publisher publisher);
        Publisher GetById(int Id);
        Publisher Update(int Id, Publisher updatedPublisher);
        void Delete(int Id);
    }
}
