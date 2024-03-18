using AluguelMotos.Infraestructure.Interfaces.Repositories;
using AluguelMotos.Infraestructure.Interfaces.Services;
using Microsoft.EntityFrameworkCore;
using System.Runtime.Serialization;
namespace AluguelMotos.Repository;

public class EntregadorRepository(AluguelMotosContext _context) : IEntregadorRepository
{
    public async Task<CreateEntregadorResult> CreateAsync(CreateEntregadorCommand entregador, CancellationToken cancellationToken)
    {

        var alreadyExists = _context.Entregadores
            .Where(x => x.CNPJ == entregador.CNPJ || x.CNH == entregador.CNH)
            .FirstOrDefault();

        if (alreadyExists is not null)
            return await Task.FromResult(new CreateEntregadorResult { EntregadorId = alreadyExists.EntregadorId });


        var result = await _context.Entregadores.AddAsync(new Entregador(
            EntregadorId: Guid.NewGuid(),
            Nome: entregador.Nome,
            CNPJ: entregador.CNPJ,
            CNH: entregador.CNH,
            ModeloCNH: entregador.ModeloCNH,
            DataNascimento: entregador.DataNascimento),
            cancellationToken: cancellationToken);
        await _context.SaveChangesAsync();
        return await Task.FromResult(new CreateEntregadorResult { EntregadorId = result.Entity.EntregadorId });
    }

    public async Task<QueryEntregadorResult> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        
        var result = await _context.Entregadores.FirstOrDefaultAsync(x => x.EntregadorId == id);
        if (result is null)
            //TODO: retornar erro
            throw new EntregadorNotFoundException();
        return new QueryEntregadorResult(
            EntregadorId: result.EntregadorId,
            Nome: result.Nome,
            CNPJ: result.CNPJ,
            CNH: result.CNH,
            ModeloCNH: result.ModeloCNH,
            DataNascimento: result.DataNascimento
            ); ;
    }

    public async Task<UpdateImagemCnhResult> UpdateImagemCnhAsync(UpdateImagemCnhCommand request, CancellationToken cancellationToken)
    {
        var result = await _context.Entregadores.FirstOrDefaultAsync(x => x.EntregadorId == request.EntregadorId);
        
        if (result is null)
            throw new EntregadorNotFoundException();
        result.ImagemCNH = request.ImagemCNH;
        await _context.SaveChangesAsync();
        return await Task.FromResult(new UpdateImagemCnhResult(result.ImagemCNH));
    }



    [Serializable]
    private class EntregadorNotFoundException : Exception
    {
        public EntregadorNotFoundException() : base("Entregador não localizado")
        {
        }
    }
}