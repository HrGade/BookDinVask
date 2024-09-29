using BookDinVask;
using System.Threading.Tasks;

public interface IBeboerRepository
{
    Task<Beboer> GetBeboerByIdAsync(int id);      // Hent en beboer ud fra ID
    Task AddBeboerAsync(Beboer beboer);           // Tilføj en ny beboer
    Task DeleteBeboerAsync(int id);               // Slet en beboer baseret på ID
}

