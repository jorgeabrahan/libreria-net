using System.ComponentModel.DataAnnotations;

namespace libreria.Models;

public class Autor
{
  [Key]
  public Guid AutorId { get; set; }

  [Required]
  [MaxLength(250)]
  public String? Nombre { get; set; }

  [MaxLength(250)]
  public String? Apellido { get; set; }

  [MaxLength(250)]
  public String? Nacionalidad { get; set; }

  public virtual ICollection<Libro>? Libros { get; set; }
}