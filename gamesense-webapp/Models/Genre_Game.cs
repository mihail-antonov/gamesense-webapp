﻿namespace gamesense_webapp.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;


    public class Genre_Game
    {
        public int GameId { get; set; }
        public Game Game { get; set; }

        public int GenreId { get; set; }
        public Genre Genre { get; set; }
    }
}