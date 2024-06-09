using APBDProbnyKol2.DTOs;
using APBDProbnyKol2.Interfaces;

namespace APBDProbnyKol2.Services;

public class WytworniaService : IWytworniaService
{
    private readonly IWytworniaRepository _wytworniaRepository;

    public WytworniaService(IWytworniaRepository wytworniaRepository)
    {
        _wytworniaRepository = wytworniaRepository;
    }

    public async Task<MuzykDTO> GetMuzyk(int idMuzyk, CancellationToken cancellationToken)
    {
        if (!await _wytworniaRepository.DoesMuzykExist(idMuzyk, cancellationToken))
        {
            return null;
        }

        return await _wytworniaRepository.GetMuzyk(idMuzyk, cancellationToken);
    }
}