using AluguelMotos.Infraestructure.Exceptions;
using AluguelMotos.Infraestructure.Interfaces.Repositories;
using AluguelMotos.Infraestructure.Interfaces.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace AluguelMotos.Services;

public class EntregadorServices(ILogger<EntregadorServices> logger, IEntregadorRepository entregadorRepository) : IEntregadorServices
{
    public async Task<CreateEntregadorResult> CreateAsync(CreateEntregadorCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation("EntregadorServices::CreateAsync");

        await entregadorRepository.CreateAsync(request, cancellationToken);

        return new CreateEntregadorResult { EntregadorId = Guid.NewGuid() };
    }

    public async Task<UpdateImagemCnhResult> UpdateImagemCnhAsync(UpdateImagemCnhCommand request, CancellationToken cancellationToken)
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

        return await entregadorRepository.UpdateImagemCnhAsync(request, cancellationToken);

    }

}

public static class Extensions
{
    public static void AddEntregadorServices(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddTransient<IEntregadorServices, EntregadorServices>();
    }
}