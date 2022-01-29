namespace gamesense_webapp.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Threading.Tasks;

    public class Genre
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Name is required!")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Description is required!")]
        [StringLength(255, MinimumLength = 10, ErrorMessage = "Length must be between 10 - 255")]
        public string Description { get; set; }

        public List<Genre_Game> Genre_Game { get; set; }
    }
}
