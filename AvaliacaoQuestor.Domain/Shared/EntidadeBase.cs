using System.ComponentModel.DataAnnotations;

namespace AvaliacaoQuestor.Domain.Shared;

public abstract class EntidadeBase
{
    [Required(ErrorMessage = "O campo Id é obrigatório.")]
    [Key]
    public int Id { get; set; }
    public abstract bool Validar();
}
