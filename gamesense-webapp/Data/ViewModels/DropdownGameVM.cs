namespace gamesense_webapp.Data.ViewModels
{
    using gamesense_webapp.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class DropdownGameVM
    {
      public DropdownGameVM()
        {
            Genres = new List<Genre>();
            Publishers = new List<Publisher>();
        }

        public List<Genre> Genres { get; set; }
        public List<Publisher> Publishers { get; set; }
    }
}
