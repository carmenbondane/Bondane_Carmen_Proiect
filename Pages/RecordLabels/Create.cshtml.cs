using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Bondane_Carmen_Proiect.Data;
using Bondane_Carmen_Proiect.Models;

namespace Bondane_Carmen_Proiect.Pages.RecordLabels
{
    public class CreateModel : PageModel
    {
        private readonly Bondane_Carmen_Proiect.Data.Bondane_Carmen_ProiectContext _context;

        public CreateModel(Bondane_Carmen_Proiect.Data.Bondane_Carmen_ProiectContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public RecordLabel RecordLabel { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.RecordLabel.Add(RecordLabel);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
