using AluguelMotos.Infraestructure.Exceptions;
using AluguelMotos.Infraestructure.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace AluguelMotos.Services;

public class EntregadorServices(ILogger<EntregadorServices> logger) : IEntregadorServices
{
    public async Task<CreateEntregadorResult> CreateAsync(CreateEntregadorCommand request)
    {
        logger.LogInformation("EntregadorServices::CreateAsync");
        //TODO: Salvar o entregador no banco de dados
        return new CreateEntregadorResult{ EntregadorId = Guid.NewGuid()};
    }

    public async Task UpdateImagemCnhAsync(UpdateImagemCnhCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation("EntregadorServices::UpdateImagemCnhAsync:EntregadorId:{entregadorId}", request.EntregadorId);
        var IsBMP = request.ImagemCNH.FileName.EndsWith("bmp", StringComparison.CurrentCultureIgnoreCase);
        var IsPNG = request.ImagemCNH.FileName.EndsWith("png", StringComparison.CurrentCultureIgnoreCase);
        if (!IsBMP && !IsPNG)
        {
            throw new InvalidImageFormatException("Only bmp or png file extensions is accepted");
        }
        var fileName = $"{Guid.NewGuid().ToString()}.{(IsPNG ? "png" : "bmp")}";
        var filePath = Path.Combine(Path.GetTempPath(), fileName);
        using (var fileStream = System.IO.File.Create(filePath))
        {
            await request.ImagemCNH.CopyToAsync(fileStream, cancellationToken);
        }
        //TODO: Atualizar o caminho da imagem no banco de dados
        
    }
}

public static class Extensions
{
    public static void AddEntregadorServices(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddTransient<IEntregadorServices, EntregadorServices>();
    }
}