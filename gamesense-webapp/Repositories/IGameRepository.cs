namespace gamesense_webapp.Repositories
{
    using gamesense_webapp.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public interface IGameRepository
    {
        IEnumerable<Game> GetGames();
        void AddGame(Game game);
        Game GetById(int Id);
        Game Update(int Id, Game updatedGame);
        void Delete(int Id);
    }
}
