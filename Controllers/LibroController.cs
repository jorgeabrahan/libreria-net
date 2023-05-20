using System.Net;
using Microsoft.AspNetCore.Mvc;
using libreria.Models;
using libreria.Services;

namespace libreria.Controllers;

[ApiController]
[Route("api/[controller]")]
public class LibroController : ControllerBase
{
  ILibroService libroService;
  public LibroController(ILibroService serviceLibro)
  {
    libroService = serviceLibro;
  }
  [HttpPost]
  public IActionResult crearLibro([FromBody] Libro libro)
  {
    libroService.crear(libro);
    return Ok();
  }

  [HttpGet]
  public IActionResult mostrarLibros()
  {
    return Ok(libroService.obtener());
  }

  [HttpPut("{id}")]
  public IActionResult actualizarLibro([FromBody] Libro libro, Guid id)
  {
    libroService.actualizar(id, libro);
    return Ok();
  }

  [HttpDelete("{id}")]
  public IActionResult eliminarLibro(Guid id)
  {
    libroService.eliminar(id);
    return Ok();
  }
}
