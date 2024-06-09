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

    public async Task<int> AddMuzyk(MuzykDTO muzykDto, CancellationToken cancellationToken)
    {
        if (await _context.Muzyka.Where(x => x.Imie == muzykDto.Imie && x.Nazwisko == muzykDto.Nazwisko)
                .AnyAsync(cancellationToken))
            return -1;
        using (var transaction = await _context.Database.BeginTransactionAsync(cancellationToken))
        {
            var muzyk = new Muzyk
            {
                Imie = muzykDto.Imie,
                Nazwisko = muzykDto.Nazwisko,
                Pseudonim = muzykDto.Pseudonim,
                Utwory = new List<Utwor>()
            };

            foreach (var utworDto in muzykDto.utwory)
            {
                var utwor = await _context.Utwory.FirstOrDefaultAsync(u => u.IdUtwor == utworDto.IdUtworu,
                    cancellationToken);

                if (utwor == null)
                {
                    utwor = new Utwor
                    {
                        NazwaUtworu = utworDto.NazwaUtworu,
                        CzasTrwania = utworDto.CzasTrwania,
                        IdAlbum = utworDto.IdAlbumu
                    };

                    await _context.Utwory.AddAsync(utwor, cancellationToken);
                }

                muzyk.Utwory.Add(utwor);
            }

            await _context.Muzyka.AddAsync(muzyk, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            await transaction.CommitAsync(cancellationToken);
            return muzyk.IdMuzyk;
        }
    }
}