using APBDProbnyKol2.DTOs;

namespace APBDProbnyKol2.Interfaces;

public interface IWytworniaService
{
    Task<MuzykDTO> GetMuzyk(int idMuzyk, CancellationToken cancellationToken);
    Task<int> AddMuzyk(MuzykDTO muzykDto, CancellationToken cancellationToken);
}