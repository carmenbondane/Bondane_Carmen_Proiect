using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Bondane_Carmen_Proiect.Data;


namespace Bondane_Carmen_Proiect.Models
{
    public class AssignedGenreData
    {

        public int GenreID { get; set; }
        public string Name { get; set; }
        public bool Assigned { get; set; }
    }

}
