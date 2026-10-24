using LHPets.Models;
using Microsoft.AspNetCore.Mvc;

namespace LHPets.Controllers;

[ApiController]
[Route("api/clientes")]
public class ClientesController : ControllerBase
{
    // Lista em memória
    public static List<Cliente> Clientes { get; } = new();

    [HttpGet]
    public ActionResult<List<Cliente>> ListarClientes()
    {
        return Ok(Clientes);
    }

    [HttpPost]
    public ActionResult<Cliente> CriarCliente(Cliente cliente)
    {
        cliente.Id = Clientes.Count + 1;
        Clientes.Add(cliente);
        return StatusCode(StatusCodes.Status201Created, cliente);
    }
}