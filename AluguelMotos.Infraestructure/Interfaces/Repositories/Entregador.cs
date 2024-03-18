using AluguelMotos.Infraestructure.Interfaces.Services;
using Microsoft.AspNetCore.Http;

namespace AluguelMotos.Infraestructure.Interfaces.Repositories;

public record Entregador(Guid EntregadorId, string Nome, string CNPJ, string CNH, ModeloCNH ModeloCNH, DateOnly DataNascimento) : IDeleted
{
    public bool IsDeleted { get; set; }
    public DateTimeOffset DeletedOnUtc { get; set; }
    public string ImagemCNH { get; set; } = "";
}
