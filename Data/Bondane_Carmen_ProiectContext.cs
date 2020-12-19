using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Bondane_Carmen_Proiect.Models;

namespace Bondane_Carmen_Proiect.Data
{
    public class Bondane_Carmen_ProiectContext : DbContext
    {
        public Bondane_Carmen_ProiectContext (DbContextOptions<Bondane_Carmen_ProiectContext> options)
            : base(options)
        {
        }

        public DbSet<Bondane_Carmen_Proiect.Models.Album> Album { get; set; }

        public DbSet<Bondane_Carmen_Proiect.Models.RecordLabel> RecordLabel { get; set; }

        public DbSet<Bondane_Carmen_Proiect.Models.Genre> Genre { get; set; }
    }
}
