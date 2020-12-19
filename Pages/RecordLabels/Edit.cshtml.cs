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

namespace Bondane_Carmen_Proiect.Pages.RecordLabels
{
    public class EditModel : PageModel
    {
        private readonly Bondane_Carmen_Proiect.Data.Bondane_Carmen_ProiectContext _context;

        public EditModel(Bondane_Carmen_Proiect.Data.Bondane_Carmen_ProiectContext context)
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

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(RecordLabel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RecordLabelExists(RecordLabel.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool RecordLabelExists(int id)
        {
            return _context.RecordLabel.Any(e => e.ID == id);
        }
    }
}
