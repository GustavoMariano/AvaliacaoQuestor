using System.ComponentModel.DataAnnotations;

namespace AvaliacaoQuestor.Domain.Shared;

public abstract class EntidadeBase
{
    [Key]
    public int Id { get; set; }
    public abstract bool Validar();
}
