using AluguelMotos.Infraestructure.Interfaces.Services;

namespace AluguelMotos.Infraestructure.Interfaces.Repositories;

public interface IEntregadorRepository: 
    IRepository<CreateEntregadorCommand, CreateEntregadorResult>
    
{
   // Task<CreateEntregadorResult> CreateAsync(CreateEntregadorCommand entregador, CancellationToken cancellationToken);
    Task<UpdateImagemCnhResult> UpdateImagemCnhAsync(UpdateImagemCnhCommand request, CancellationToken cancellationToken);
}
public interface IRepository<TIn, TOut>
{ 
    Task<TOut> GetByIdAsync(Guid id, CancellationToken cancellationToken);
    Task<TOut> CreateAsync(TIn entity, CancellationToken cancellationToken);
}