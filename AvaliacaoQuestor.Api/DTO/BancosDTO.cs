using System.ComponentModel.DataAnnotations;

namespace AvaliacaoQuestor.Api.DTO;

public class BancosDTO
{
    [Required(ErrorMessage = "O campo Id é obrigatório.")]
    public int Id { get; set; }
    [Required(ErrorMessage = "O campo NomeBanco é obrigatório.")]
    public string NomeBanco { get; set; }

    [Required(ErrorMessage = "O campo CodigoBanco é obrigatório.")]
    public int CodigoBanco { get; set; }

    [Required(ErrorMessage = "O campo PercentualJuros é obrigatório.")]
    public decimal PercentualJuros { get; set; }
}
