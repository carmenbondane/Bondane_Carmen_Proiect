using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Bondane_Carmen_Proiect.Data;
using Bondane_Carmen_Proiect.Models;

namespace Bondane_Carmen_Proiect.Pages.Albums
{
    public class CreateModel : AlbumGenresPageModel
    {
        private readonly Bondane_Carmen_Proiect.Data.Bondane_Carmen_ProiectContext _context;

        public CreateModel(Bondane_Carmen_Proiect.Data.Bondane_Carmen_ProiectContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["RecordLabelID"] = new SelectList(_context.Set<RecordLabel>(), "ID", "RLName");
            
            var album = new Album();
            album.AlbumGenres = new List<AlbumGenre>();
            PopulateAssignedGenreData(_context, album);
            return Page();
        }

        [BindProperty]
        public Album Album { get; set; }


        public async Task<IActionResult> OnPostAsync(string[] selectedGenres)
        {
            var newAlbum = new Album();
            if (selectedGenres != null)
            {
                newAlbum.AlbumGenres = new List<AlbumGenre>();
                foreach (var gen in selectedGenres)
                {
                    var genToAdd = new AlbumGenre
                    {
                        GenreID = int.Parse(gen)
                    };
                    newAlbum.AlbumGenres.Add(genToAdd);
                }
            }

            if (await TryUpdateModelAsync<Album>(
            newAlbum,
            "Album",
            i => i.Title, i => i.Singer,
            i => i.Price, i => i.ReleaseDate, i => i.RecordLabelID))
            {
                _context.Album.Add(newAlbum);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            PopulateAssignedGenreData(_context, newAlbum);
            return Page();
        }

    }
}
