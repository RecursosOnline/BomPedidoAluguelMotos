using AluguelMotos.Infraestructure.Interfaces.Services;
using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace AluguelMotos.API.Endpoints.Entregador;

public class PhotoUpdate(ILogger<PhotoUpdate> _logger, IEntregadorServices _entregadorServices) : EndpointBaseAsync
    .WithRequest<UploadImagemCnhCommand>
    .WithResult<ActionResult<UpdateImagemCnhResult>>
{

    [HttpPost("/entregadores/cnhimagem")]
    [SwaggerOperation(
        Summary = "Update the CNH image of Entregador",
        Description = "Update the CNH image of Entregador",
        OperationId = "Entregador_CnhImagemUpdate",
        Tags = new[] { "EntregadorEndpoint" })
    ]
    public override async Task<ActionResult<UpdateImagemCnhResult>> HandleAsync(UploadImagemCnhCommand request, CancellationToken cancellationToken = default)
    {
        _logger.LogInformation("PhotoUpdate::HandleAsync");

        var result = await _entregadorServices.UpdateImagemCnhAsync(request, cancellationToken);

        return result;
    }
}