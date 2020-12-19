using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
//pentru a putea seta constrangeri sau valori predefinite

namespace Bondane_Carmen_Proiect.Models
{
    public class Album
    {
        public int ID { get; set; }

        [Display(Name = "Album title")]   //cum dorim sa se afiseze numele campului
        [Required, StringLength(100, MinimumLength = 2)]
        public string Title { get; set; }

        [Display(Name = "Singer/Band")]
        public string Singer { get; set; }

        [Range(1, 300)]
        [Column(TypeName = "decimal(10, 2)")]   //sunt permise valori cu 2 zecimale
        public decimal Price { get; set; }

        [Display(Name = "Release date")]
        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }

        public int RecordLabelID { get; set; }
        public RecordLabel RecordLabel { get; set; } //casa de discuri

        [Display(Name = "Genre")]
        public ICollection<AlbumGenre> AlbumGenres { get; set; }
    }
}
