namespace gamesense_webapp.Repositories
{
    using gamesense_webapp.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public interface IGenreRepository
    {
        IEnumerable<Genre> GetGenres();
        void AddGenre(Genre genre);
        Genre GetById(int Id);
        Genre Update(int Id, Genre updatedGenre);
        void Delete(int Id);
    }
}
