﻿namespace gamesense_webapp.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Threading.Tasks;

    public class Game
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Title is required!")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Description is required!")]
        [StringLength(255, MinimumLength = 10, ErrorMessage = "Length must be between 10 - 255")]
        public string Description { get; set; }
        public string Cover { get; set; }
        public float Price { get; set; }
        public string Platform { get; set; }

        public List<Genre_Game> Genre_Game { get; set; }
        public int PublisherId { get; set; }
        [ForeignKey("PublisherId")]
        public Publisher Publisher { get; set; }
    }
}
