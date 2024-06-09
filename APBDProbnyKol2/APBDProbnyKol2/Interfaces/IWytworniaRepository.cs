using APBDProbnyKol2.DTOs;

namespace APBDProbnyKol2.Interfaces;

public interface IWytworniaRepository
{
    Task<MuzykDTO> GetMuzyk(int IdMuzyk, CancellationToken canellationToken);
    Task<bool> DoesMuzykExist(int IdMuzyk, CancellationToken cancellationToken);
}