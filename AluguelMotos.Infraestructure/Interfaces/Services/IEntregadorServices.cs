using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace AluguelMotos.Infraestructure.Interfaces.Services;

public interface IEntregadorServices
{
    Task<CreateEntregadorResult> CreateAsync(CreateEntregadorCommand request, CancellationToken cancellationToken);
    Task<UpdateImagemCnhResult> UpdateImagemCnhAsync(UploadImagemCnhCommand request, CancellationToken cancellationToken);    
}
//TODO: Separar as classes e enumns em arquivos diferentes
public enum ModeloCNH
{
    A = 1,
    B = 2,
    /// <summary>
    /// A + B
    /// </summary>
    Ambos = 3
}

public class CreateEntregadorCommand
{
    [Required] public string Nome { get; set; } = null!;
    [Required] public string CNH { get; set; } = null!;
    [Required] public string CNPJ { get; set; } = null!;
    [Required] public ModeloCNH ModeloCNH { get; set; }
    [Required] public DateOnly DataNascimento { get; set; }
}

public class CreateEntregadorResult
{
    public Guid EntregadorId { get; set; }
}
public record QueryEntregadorResult(Guid EntregadorId, string Nome, string CNH, string CNPJ, ModeloCNH ModeloCNH, DateOnly DataNascimento);
public class UploadImagemCnhCommand
{
    [Required] public Guid EntregadorId { get; set; }
    [Required] public IFormFile ImagemCNH { get; set; } = null!;
}
public record UpdateImagemCnhCommand(Guid EntregadorId, string ImagemCNH);
public record UpdateImagemCnhResult(string Info);
