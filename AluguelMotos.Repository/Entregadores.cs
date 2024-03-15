using AluguelMotos.Infraestructure.Interfaces.Repositories;
using AluguelMotos.Infraestructure.Interfaces.Services;

namespace AluguelMotos.Repository;

public class Entregadores: IEntregadorRepository
{
    public async Task<CreateEntregadorResult> CreateAsync(CreateEntregadorCommand entregador, CancellationToken cancellationToken)
    {
        CreateEntregadorResult  result = new();
        result.EntregadorId = Guid.NewGuid();
        return await Task.FromResult<CreateEntregadorResult>(result);
    }

    public Task<CreateEntregadorResult> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<UpdateImagemCnhResult> UpdateImagemCnhAsync(UpdateImagemCnhCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}