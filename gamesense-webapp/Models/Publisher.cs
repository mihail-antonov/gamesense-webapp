namespace gamesense_webapp.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Threading.Tasks;

    public class Publisher
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Name is required!")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Description is required!")]
        [StringLength(255, MinimumLength = 10, ErrorMessage = "Length must be between 10 - 255")]
        public string? Description { get; set; }
        [Required(ErrorMessage = "Year is required!")]
        public int Founded { get; set; }

        public List<Game> Games { get; set; }
    }
}
