using AluguelMotos.Infraestructure.Interfaces.Repositories;
using AluguelMotos.Infraestructure.Interfaces.Services;

namespace AluguelMotos.Repository;

public class Entregadores: IEntregadorRepository
{
    public Task<CreateEntregadorResult> CreateAsync(CreateEntregadorCommand entregador, CancellationToken cancellationToken)
    {
        
    }
}