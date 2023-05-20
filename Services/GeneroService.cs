using libreria.Models;
namespace libreria.Services;

public class GeneroService : IGeneroService
{
  LibreriaContext context;
  public GeneroService(LibreriaContext dbContext)
  {
    context = dbContext;
  }

  public async Task crear(Genero genero)
  {
    genero.GeneroId = Guid.NewGuid();
    context.Add(genero);
    await context.SaveChangesAsync();
  }

  public IEnumerable<Genero>? obtener()
  {
    return context.Genero;
  }

  public async Task actualizar(Guid id, Genero actualizado)
  {
    var genero = context.Genero?.Find(id);
    if (genero == null) return;
    genero.Nombre = actualizado.Nombre;
    await context.SaveChangesAsync();
  }

  public async Task eliminar(Guid id)
  {
    var genero = context.Genero?.Find(id);
    if (genero == null) return;
    context.Remove(genero);
    await context.SaveChangesAsync();
  }
}

public interface IGeneroService
{
  Task crear(Genero genero);
  IEnumerable<Genero>? obtener();
  Task actualizar(Guid id, Genero actualizado);
  Task eliminar(Guid id);
}
