using System.Net;
using Microsoft.AspNetCore.Mvc;
using libreria.Models;
using libreria.Services;

namespace libreria.Controllers;

[ApiController]
[Route("api/[controller]")]
public class GeneroController : ControllerBase
{
  IGeneroService generoService;
  public GeneroController(IGeneroService serviceGenero)
  {
    generoService = serviceGenero;
  }
  [HttpPost]
  public IActionResult crearGenero([FromBody] Genero genero)
  {
    generoService.crear(genero);
    return Ok();
  }

  [HttpGet]
  public IActionResult mostrarGeneros()
  {
    return Ok(generoService.obtener());
  }

  [HttpPut("{id}")]
  public IActionResult actualizarAutor([FromBody] Genero genero, Guid id)
  {
    generoService.actualizar(id, genero);
    return Ok();
  }

  [HttpDelete("{id}")]
  public IActionResult eliminarAutor(Guid id)
  {
    generoService.eliminar(id);
    return Ok();
  }
}
