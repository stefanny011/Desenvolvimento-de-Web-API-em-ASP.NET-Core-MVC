using LHPets.Models;
using Microsoft.AspNetCore.Mvc;

namespace LHPets.Controllers;

[ApiController]
[Route("api/pets")]
public class PetsController : ControllerBase
{
    // Lista em memória
    private static readonly List<Pet> Pets = new();

    [HttpGet]
    public ActionResult<List<Pet>> ListarPets()
    {
        return Ok(Pets);
    }

    [HttpPost]
    public ActionResult<Pet> CriarPet(Pet pet)
    {
        // Verifica se o cliente existe
        var clienteExiste = ClientesController.Clientes.Any(c => c.Id == pet.ClienteId);
        if (!clienteExiste)
        {
            return BadRequest(new { mensagem = "O cliente informado não existe." });
        }

        pet.Id = Pets.Count + 1;
        Pets.Add(pet);
        return StatusCode(StatusCodes.Status201Created, pet);
    }

    [HttpGet("cliente/{clienteId:int}")]
    public ActionResult<List<Pet>> ListarPetsPorCliente(int clienteId)
    {
        var petsDoCliente = Pets.Where(p => p.ClienteId == clienteId).ToList();
        return Ok(petsDoCliente);
    }
}