using Microsoft.AspNetCore.Mvc;
using SQS.Domain.Interfaces;

namespace SQS.Contatos.API.Controllers;

[Route("api/[controller]")]
public class ContatoController : ControllerBase
{
    private readonly IAmazonRepository<Domain.Entities.Contato> _amazonRepository;
    public ContatoController(IAmazonRepository<Domain.Entities.Contato> amazonRepository)
    {
        _amazonRepository = amazonRepository;
    }
    [HttpPost]
    public async Task PostAsync([FromBody]Domain.Entities.Contato obj)
    {
        obj.Id = Guid.NewGuid();
        obj.Data = DateTime.Now;
        await _amazonRepository.Save(obj);
    }
}