using LHPets.Models;
using Microsoft.AspNetCore.Mvc;
namespace LHPets.Controllers;
[ApiController]
[Route("api/pets")]
public class PetsController : ControllerBase
{
 private static readonly List<Pet> Pets = new();
 // GET: /api/pets
 [HttpGet]
 public ActionResult<List<Pet>> ListarPets()
 {
 return Ok(Pets);
 }
 // POST: /api/pets
 [HttpPost]
 public ActionResult<Pet> CriarPet(Pet pet)
 {
 var clienteExiste = ClientesController.Clientes
 .Any(cliente => cliente.Id == pet.ClienteId);
 if (!clienteExiste)
 {
 return BadRequest(new
 {
 mensagem = "O cliente informado não existe."
 });
 }
 pet.Id = Pets.Count + 1;
 Pets.Add(pet);
 return StatusCode(StatusCodes.Status201Created, pet);
 }
 // GET: /api/pets/cliente/1
 [HttpGet("cliente/{clienteId:int}")]
 public ActionResult<List<Pet>> ListarPetsPorCliente(int clienteId)
 {
 var petsDoCliente = Pets
 .Where(pet => pet.ClienteId == clienteId)
 .ToList();
 return Ok(petsDoCliente);
 }
}
