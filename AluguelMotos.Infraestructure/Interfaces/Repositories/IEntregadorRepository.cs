using AluguelMotos.Infraestructure.Interfaces.Services;

namespace AluguelMotos.Infraestructure.Interfaces.Repositories;

public interface IEntregadorRepository 

{
    Task<CreateEntregadorResult> CreateAsync(CreateEntregadorCommand request, CancellationToken cancellationToken);
    Task<UpdateImagemCnhResult> UpdateImagemCnhAsync(UpdateImagemCnhCommand request, CancellationToken cancellationToken);
    // Task<CreateEntregadorResult> CreateAsync(CreateEntregadorCommand entregador, CancellationToken cancellationToken);
    //Task<UpdateImagemCnhResult> UpdateImagemCnhAsync(UpdateImagemCnhCommand request, CancellationToken cancellationToken);

}
public interface IGenericRepository<TIn>
{ 
    Task<TIn> GetByIdAsync(Guid id, CancellationToken cancellationToken);
    Task<TIn> CreateAsync(TIn entity, CancellationToken cancellationToken);
}

public interface IDeleted
{
    bool IsDeleted { get; set; }
    DateTimeOffset DeletedOnUtc { get; set; }
}