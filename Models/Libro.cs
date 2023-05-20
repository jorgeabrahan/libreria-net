using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace libreria.Models;

public class Libro
{
  [Key]
  public Guid LibroId { get; set; }

  [ForeignKey("AutorId")]
  public Guid AutorId { get; set; }

  [ForeignKey("GeneroId")]
  public Guid GeneroId { get; set; }

  [Required]
  [MaxLength(250)]
  public String? Nombre { get; set; }

  [Required]
  public int Edicion { get; set; }

  [Required]
  public int Paginas { get; set; }

  public virtual Autor? Autor { get; set; }
  public virtual Genero? Genero { get; set; }
}
