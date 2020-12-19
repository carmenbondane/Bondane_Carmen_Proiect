using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Bondane_Carmen_Proiect.Data;
using Bondane_Carmen_Proiect.Models;

namespace Bondane_Carmen_Proiect.Pages.RecordLabels
{
    public class DeleteModel : PageModel
    {
        private readonly Bondane_Carmen_Proiect.Data.Bondane_Carmen_ProiectContext _context;

        public DeleteModel(Bondane_Carmen_Proiect.Data.Bondane_Carmen_ProiectContext context)
        {
            _context = context;
        }

        [BindProperty]
        public RecordLabel RecordLabel { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            RecordLabel = await _context.RecordLabel.FirstOrDefaultAsync(m => m.ID == id);

            if (RecordLabel == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            RecordLabel = await _context.RecordLabel.FindAsync(id);

            if (RecordLabel != null)
            {
                _context.RecordLabel.Remove(RecordLabel);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
