namespace gamesense_webapp.Repositories
{
    using gamesense_webapp.Data;
    using gamesense_webapp.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class GenreRepository : IGenreRepository
    {
        private readonly ApplicationDbContext _context;
        public GenreRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void AddGenre(Genre genre)
        {
            _context.Genres.Add(genre);
            _context.SaveChanges();
        }

        public void Delete(int Id)
        {
            var genre = _context.Genres.FirstOrDefault(n => n.Id == Id);
            _context.Genres.Remove(genre);
            _context.SaveChanges();
        }

        public IEnumerable<Genre> GetGenres()
        {
            var genres = _context.Genres.ToList();

            return genres;
        }

        public Genre GetById(int Id)
        {
            var genre = _context.Genres.FirstOrDefault(n => n.Id == Id);

            return genre;
        }

        public Genre Update(int Id, Genre updatedGenre)
        {
            _context.Update(updatedGenre);
            _context.SaveChanges();

            return updatedGenre;
        }
    }
}
