using AluguelMotos.Infraestructure.Interfaces;
using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace AluguelMotos.API.Endpoints.Entregador;

public class PhotoUpdate(ILogger<PhotoUpdate> _logger, IEntregadorServices _entregadorServices) : EndpointBaseAsync
    .WithRequest<UpdateImagemCnhCommand>
    .WithResult<ActionResult<string[]>>
{

    [HttpPost("/entregadores/cnhimagem")]
    [SwaggerOperation(
        Summary = "Update the CNH image of Entregador",
        Description = "Update the CNH image of Entregador",
        OperationId = "Entregador_CnhImagemUpdate",
        Tags = new[] { "EntregadorEndpoint" })
    ]
    public override async Task<ActionResult<string[]>> HandleAsync(UpdateImagemCnhCommand request, CancellationToken cancellationToken = default)
    {
        _logger.LogInformation("PhotoUpdate::HandleAsync");

        await _entregadorServices.UpdateImagemCnhAsync(request, cancellationToken);

        return new[]
        {
            request.ImagemCNH.FileName,
            request.ImagemCNH.ContentType,
            request.ImagemCNH.ContentDisposition,
            request.ImagemCNH.Length.ToString()
        };
    }
}