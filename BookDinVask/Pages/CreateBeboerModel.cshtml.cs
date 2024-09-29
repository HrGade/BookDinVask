using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookDinVask.Pages
{
    public class CreateBeboerModel : PageModel
    {
        private readonly IBeboerRepository _beboerRepository;

        // Dette property binder data fra formularen p� CreateBeboer.cshtml
        [BindProperty]
        public Beboer Beboer { get; set; }

        // Constructor, som modtager repository via dependency injection
        public CreateBeboerModel(IBeboerRepository beboerRepository)
        {
            _beboerRepository = beboerRepository;
        }

        // GET-metoden til at vise siden
        public IActionResult OnGet()
        {
            // Dette returnerer blot siden. Der er ingen speciel logik her endnu.
            return Page();
        }

        // POST-metoden til at h�ndtere formularindsendelse
        public async Task<IActionResult> OnPostAsync()
        {
            // Validering af ModelState, sikrer at de indtastede data er korrekte
            if (!ModelState.IsValid)
            {
                return Page(); // Hvis der er fejl i formularen, vises siden igen
            }

            // Tilf�j den nye beboer til databasen gennem repository
            await _beboerRepository.AddBeboerAsync(Beboer);

            // Redirect tilbage til forsiden eller en anden side, n�r beboeren er oprettet
            return RedirectToPage("/Index");
        }
    }
}

