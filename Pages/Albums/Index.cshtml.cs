﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Bondane_Carmen_Proiect.Data;
using Bondane_Carmen_Proiect.Models;

namespace Bondane_Carmen_Proiect.Pages.Albums
{
    public class IndexModel : PageModel
    {
        private readonly Bondane_Carmen_Proiect.Data.Bondane_Carmen_ProiectContext _context;

        public IndexModel(Bondane_Carmen_Proiect.Data.Bondane_Carmen_ProiectContext context)
        {
            _context = context;
        }

        public IList<Album> Album { get;set; }
        public AlbumData AlbumD { get; set; }
        public int AlbumID { get; set; }
        public int GenreID { get; set; }
        public async Task OnGetAsync(int? id, int? genreID)
        {
            AlbumD = new AlbumData();
            AlbumD.Albums = await _context.Album
            .Include(b => b.RecordLabel)
            .Include(b => b.AlbumGenres)
            .ThenInclude(b => b.Genre)
            .AsNoTracking()
            .OrderBy(b => b.Title)
            .ToListAsync();

            if (id != null)
            {
                AlbumID = id.Value;
                Album album = AlbumD.Albums
                .Where(i => i.ID == id.Value).Single();
                AlbumD.Genres = album.AlbumGenres.Select(s => s.Genre);
            }
        }
    }
}
