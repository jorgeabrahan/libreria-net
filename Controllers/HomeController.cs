using Microsoft.AspNetCore.Mvc;

namespace libreria.Controllers;

[ApiController]
[Route("[controller]")]
public class HomeController : ControllerBase
{
  LibreriaContext dbcontext;
  public HomeController(LibreriaContext db)
  {
    dbcontext = db;
  }

  [HttpGet]
  [Route("conectar")]
  public IActionResult conectar()
  {
    dbcontext.Database.EnsureCreated();
    return Ok();
  }
}