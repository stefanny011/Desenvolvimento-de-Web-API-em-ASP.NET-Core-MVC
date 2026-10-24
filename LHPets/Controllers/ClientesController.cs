using LHPets.Models;
using Microsoft.AspNetCore.Mvc;
namespace LHPets.Controllers;
[ApiController]
[Route("api/clientes")]
public class ClientesController : ControllerBase
{
 // Lista compartilhada em memória.
 public static List<Cliente> Clientes { get; } = new();
 // GET: /api/clientes
 [HttpGet]
 public ActionResult<List<Cliente>> ListarClientes()
 {
 return Ok(Clientes);
 }
 // POST: /api/clientes
 [HttpPost]
 public ActionResult<Cliente> CriarCliente(Cliente cliente)
 {
 cliente.Id = Clientes.Count + 1;
 Clientes.Add(cliente);
 return StatusCode(StatusCodes.Status201Created, cliente);
