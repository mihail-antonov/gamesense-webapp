namespace gamesense_webapp.Repositories
{
    using gamesense_webapp.Data.ViewModels;
    using gamesense_webapp.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public interface IGameRepository
    {
        IEnumerable<Game> GetGames();
        Task AddGame(NewGameVM newGVM);
        Task<Game> GetById(int id);
        Task Update(NewGameVM newGVM);
        void Delete(int Id);

        Task<DropdownGameVM> GetDropdownValuesVM();
    }
}
