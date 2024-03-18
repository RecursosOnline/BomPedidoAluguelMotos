namespace AluguelMotos.Infraestructure.Interfaces.Repositories;

public record Moto(Guid MotoId, string Placa, string Renavan) : IDeleted
{
    public bool IsDeleted { get; set; }
    public DateTimeOffset DeletedOnUtc { get; set; }
}
