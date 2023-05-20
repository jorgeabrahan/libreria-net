using libreria.Models;
namespace libreria.Services;

public class AutorService : IAutorService
{
  //Inyeccion de dependencias
  LibreriaContext context;
  public AutorService(LibreriaContext dbContext)
  {
    context = dbContext;
  }

  public async Task crear(Autor autor)
  {
    autor.AutorId = Guid.NewGuid();
    await context.AddAsync(autor);
    await context.SaveChangesAsync();
  }

  //READ - Obtener de la DB
  public IEnumerable<Autor>? obtener()
  {
    return context.Autor;
  }

  public async Task actualizar(Guid id, Autor actualizado)
  {
    var autor = context.Autor?.Find(id);
    if (autor == null) return;
    autor.Nombre = actualizado.Nombre;
    autor.Apellido = actualizado.Apellido;
    autor.Nacionalidad = actualizado.Nacionalidad;
    await context.SaveChangesAsync();
  }

  public async Task eliminar(Guid id)
  {
    var autor = context.Autor?.Find(id);
    if (autor == null) return;
    context.Remove(autor);
    await context.SaveChangesAsync();
  }
}

public interface IAutorService
{
  Task crear(Autor autor);
  IEnumerable<Autor>? obtener();
  Task actualizar(Guid id, Autor actualizado);
  Task eliminar(Guid id);
}