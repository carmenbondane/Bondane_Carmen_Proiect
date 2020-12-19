using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Bondane_Carmen_Proiect.Data;
using Bondane_Carmen_Proiect.Models;
using Bondane_Carmen_Proiect.Pages;

namespace Bondane_Carmen_Proiect.Pages.Albums
{
    public class EditModel : AlbumGenresPageModel
    {
        private readonly Bondane_Carmen_Proiect.Data.Bondane_Carmen_ProiectContext _context;

        public EditModel(Bondane_Carmen_Proiect.Data.Bondane_Carmen_ProiectContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Album Album { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Album = await _context.Album
            .Include(b => b.RecordLabel)
            .Include(b => b.AlbumGenres).ThenInclude(b => b.Genre)
            .AsNoTracking()
            .FirstOrDefaultAsync(m => m.ID == id);

            if (Album == null)
            {
                return NotFound();
            }

            PopulateAssignedGenreData(_context, Album);

            ViewData["RecordLabelID"] = new SelectList(_context.Set<RecordLabel>(), "ID", "RLName");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id, string[] selectedGenres)
        {
            if (id == null)
            {
                return NotFound();
            }

            var albumToUpdate = await _context.Album
            .Include(i => i.RecordLabel)
            .Include(i => i.AlbumGenres)
            .ThenInclude(i => i.Genre)
            .FirstOrDefaultAsync(s => s.ID == id);

            if (albumToUpdate == null)
            {
                return NotFound();
            }

            if (await TryUpdateModelAsync<Album>(albumToUpdate,
                "Album",
                i => i.Title, i => i.Singer,
                i => i.Price, i => i.ReleaseDate, i => i.RecordLabel))
            {
                UpdateAlbumGenres(_context, selectedGenres, albumToUpdate);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }


            UpdateAlbumGenres(_context, selectedGenres, albumToUpdate);
            PopulateAssignedGenreData(_context, albumToUpdate);
            return Page();


            
        }

    
    }
}
