namespace gamesense_webapp.Repositories
{
    using gamesense_webapp.Data;
    using gamesense_webapp.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class GameRepository : IGameRepository
    {
        private readonly ApplicationDbContext _context;
        public GameRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void AddGame(Game game)
        {
            _context.Games.Add(game);
            _context.SaveChanges();
        }

        public void Delete(int Id)
        {
            var game = _context.Games.FirstOrDefault(n => n.Id == Id);
            _context.Games.Remove(game);
            _context.SaveChanges();
        }

        public IEnumerable<Game> GetGames()
        {
            var games = _context.Games.ToList();

            return games;
        }

        public Game GetById(int Id)
        {
            var game = _context.Games.FirstOrDefault(n => n.Id == Id);

            return game;
        }

        public Game Update(int Id, Game updatedGame)
        {
            _context.Update(updatedGame);
            _context.SaveChanges();

            return updatedGame;
        }
    }
}
