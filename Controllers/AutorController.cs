using Microsoft.AspNetCore.Mvc;
using libreria.Models;
using libreria.Services;

namespace libreria.Controllers;

//ATRIBUTOS CONTROLLER
[ApiController]
[Route("api/[controller]")]
public class AutorController : ControllerBase
{

  IAutorService autorService;
  public AutorController(IAutorService serviceAutor)
  {
    autorService = serviceAutor;
  }

  [HttpPost]
  public IActionResult crearAutor([FromBody] Autor nuevoAutor)
  {
    autorService.crear(nuevoAutor);
    return Ok();
  }

  //READ
  [HttpGet]
  public IActionResult mostrarAutores()
  {
    return Ok(autorService.obtener());
  }

  //UPDATE
  [HttpPut("{id}")]
  public IActionResult actualizarAutor([FromBody] Autor autorActualizar, Guid id)
  {
    autorService.actualizar(id, autorActualizar);
    return Ok();
  }

  //DELETE
  [HttpDelete("{id}")]
  public IActionResult eliminarAutor(Guid id)
  {
    autorService.eliminar(id);
    return Ok();
  }
}