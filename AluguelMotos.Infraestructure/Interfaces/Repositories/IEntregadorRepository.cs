using AluguelMotos.Infraestructure.Interfaces.Services;

namespace AluguelMotos.Infraestructure.Interfaces.Repositories;

public interface IEntregadorRepository
{
    Task<CreateEntregadorResult> CreateAsync(CreateEntregadorCommand entregador, CancellationToken cancellationToken);
}