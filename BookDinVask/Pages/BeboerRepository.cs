using System.Threading.Tasks;
using BookDinVask;
using Microsoft.EntityFrameworkCore;

public class BeboerRepository : IBeboerRepository
{
    private readonly ApplicationDbContext _context;

    public BeboerRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    // Hent en beboer ud fra ID
    public async Task<Beboer> GetBeboerByIdAsync(int id)
    {
        return await _context.Beboere.FindAsync(id);
    }

    // Tilføj en ny beboer
    public async Task AddBeboerAsync(Beboer beboer)
    {
        await _context.Beboere.AddAsync(beboer);
        await _context.SaveChangesAsync();
    }

    // Slet en beboer baseret på ID
    public async Task DeleteBeboerAsync(int id)
    {
        var beboer = await GetBeboerByIdAsync(id);
        if (beboer != null)
        {
            _context.Beboere.Remove(beboer);
            await _context.SaveChangesAsync();
        }
    }
}

