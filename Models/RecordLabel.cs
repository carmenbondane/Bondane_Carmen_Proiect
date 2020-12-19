using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bondane_Carmen_Proiect.Models
{
    public class RecordLabel
    {
        public int ID { get; set; }   //cheie straina pentru Album
        
        [Display(Name = "Record label name")]
        public string RLName { get; set; }
        public ICollection<Album> Albums { get; set; } //navigation property
    }
}
