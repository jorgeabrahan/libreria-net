using libreria.Models;
namespace libreria.Services;

public class LibroService : ILibroService
{
  LibreriaContext context;
  public LibroService(LibreriaContext dbContext)
  {
    context = dbContext;
  }

  public async Task crear(Libro libro)
  {
    libro.LibroId = Guid.NewGuid();
    context.Add(libro);
    await context.SaveChangesAsync();
  }

  public IEnumerable<Libro>? obtener()
  {
    return context.Libro;
  }

  public async Task actualizar(Guid id, Libro actualizado)
  {
    var libro = context.Libro?.Find(id);
    if (libro == null) return;
    libro.Nombre = actualizado.Nombre;
    libro.Edicion = actualizado.Edicion;
    libro.Paginas = actualizado.Paginas;
    await context.SaveChangesAsync();
  }

  public async Task eliminar(Guid id)
  {
    var libro = context.Libro?.Find(id);
    if (libro == null) return;
    context.Remove(libro);
    await context.SaveChangesAsync();
  }
}

public interface ILibroService
{
  Task crear(Libro libro);
  IEnumerable<Libro>? obtener();
  Task actualizar(Guid id, Libro actualizado);
  Task eliminar(Guid id);
}