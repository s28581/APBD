using APBDProbnyKol2.Data;
using APBDProbnyKol2.DTOs;
using APBDProbnyKol2.Interfaces;
using APBDProbnyKol2.Models;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.EntityFrameworkCore;

namespace APBDProbnyKol2.Repositories;

public class WytworniaRepository : IWytworniaRepository
{
    private readonly DataContext _context;

    public WytworniaRepository(DataContext context)
    {
        _context = context;
    }

    public async Task<MuzykDTO> GetMuzyk(int idMuzyk, CancellationToken cancellationToken)
    {
        MuzykDTO result = (await _context.Muzyka
            .Where(x => x.IdMuzyk == idMuzyk)
            .Select(m => new MuzykDTO(
                m.Imie,
                m.Nazwisko,
                m.Pseudonim,
                m.Utwory
                    .Select(u => new UtworDTO(
                        u.IdUtwor,
                        u.NazwaUtworu,
                        u.CzasTrwania,
                        u.IdAlbum)).ToList()
            )).FirstOrDefaultAsync(cancellationToken))!;
        return result;
    }

    public async Task<bool> DoesMuzykExist(int IdMuzyk, CancellationToken cancellationToken)
    {
        return await _context.Muzyka.Where(x => x.IdMuzyk == IdMuzyk).AnyAsync(cancellationToken);
        
    }
}