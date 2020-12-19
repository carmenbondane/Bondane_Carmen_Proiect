using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bondane_Carmen_Proiect.Models
{
    public class Genre
    {
        public int ID { get; set; }
        [Display(Name = "Genre name")]
        public string GenreName { get; set; }
        public ICollection<AlbumGenre> AlbumGenres { get; set; }

    }
}
