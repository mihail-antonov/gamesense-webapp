namespace gamesense_webapp.Repositories
{
    using gamesense_webapp.Data;
    using gamesense_webapp.Data.ViewModels;
    using gamesense_webapp.Models;
    using Microsoft.EntityFrameworkCore;
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

        public async Task AddGame(NewGameVM newGVM)
        {
            var game = new Game()
            {
                Title = newGVM.Title,
                Description = newGVM.Description,
                Cover = newGVM.Cover,
                Price = newGVM.Price,
                Platform = newGVM.Platform,
                PublisherId = newGVM.PublisherId
            };

            this._context.Games.Add(game);
            this._context.SaveChanges();

            foreach (var genreId in newGVM.Genre_Ids)
            {
                var GenreGame = new Genre_Game()
                {
                    GameId = game.Id,
                    GenreId = genreId
                };
                
                await _context.Genres_Games.AddAsync(GenreGame);
            }

            _context.SaveChanges();
        }

        public async Task<Game> GetById(int id)
        {
            var details = await _context.Games
                .Include(p => p.Publisher)
                .Include(gg => gg.Genre_Game)
                .ThenInclude(g => g.Genre)
                .FirstOrDefaultAsync(n => n.Id == id);

            return details;
        }

        public async Task<DropdownGameVM> GetDropdownValuesVM()
        {

            var response = new DropdownGameVM();
            response.Genres = await _context.Genres.OrderBy(n => n.Name).ToListAsync();
            response.Publishers = await _context.Publishers.OrderBy(n => n.Name).ToListAsync();

            return response;
        }

        public IEnumerable<Game> GetGames()
        {
            var result = _context.Games.ToList();
            return result;
        }

        public async Task Update(NewGameVM newGVM)
        {
            var game = await _context.Games.FirstOrDefaultAsync(n => n.Id == newGVM.Id);
            if (game != null)
            {
                game.Title = newGVM.Title;
                game.Description = newGVM.Description;
                game.Cover = newGVM.Cover;
                game.Price = newGVM.Price;
                game.Platform = newGVM.Platform;
                game.PublisherId = newGVM.PublisherId;

                await _context.SaveChangesAsync();
            }

            var genres = _context.Genres_Games.Where(n => n.GameId == newGVM.Id).ToList();
            _context.Genres_Games.RemoveRange(genres);
            await this._context.SaveChangesAsync();

            foreach (var genreId in newGVM.Genre_Ids)
            {
                var newGenre = new Genre_Game()
                {
                    GameId = newGVM.Id,
                    GenreId = genreId,
                };

                await _context.Genres_Games.AddAsync(newGenre);
            }

            await _context.SaveChangesAsync();
        }

        public void Delete(int Id)
        {
            var game = _context.Games.FirstOrDefault(n => n.Id == Id);

            this._context.Games.Remove(game);

            this._context.SaveChanges();
        }
    }
}
