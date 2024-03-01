using AluguelMotos.Infraestructure.Exceptions;
using AluguelMotos.Infraestructure.Interfaces;
using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace AluguelMotos.API.Endpoints.Entregador;

public class Create(ILogger<Create> _logger, IEntregadorServices _entregadorServices) : EndpointBaseAsync
    .WithRequest<CreateEntregadorCommand>
    .WithResult<CreateEntregadorResult>
{
    [HttpPost("/entregadores")]
    [SwaggerOperation(
        Summary = "Creates a new Entregador",
        Description = "Creates a new Entregador",
        OperationId = "Entregador_Create",
        Tags = new[] { "EntregadorEndpoint" })
    ]
    public override async Task<CreateEntregadorResult> HandleAsync([FromBody]CreateEntregadorCommand request, CancellationToken cancellationToken = default)
    {
        _logger.LogInformation("Create::HandleAsync");
        if (!ModelState.IsValid)
        {
            throw new Exception(ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToString());
        }

        return await _entregadorServices.CreateAsync(request);
    }
}