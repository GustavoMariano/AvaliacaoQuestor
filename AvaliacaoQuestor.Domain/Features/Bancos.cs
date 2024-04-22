using AvaliacaoQuestor.Domain.Shared;
using System.ComponentModel.DataAnnotations;

namespace AvaliacaoQuestor.Domain.Features;

public class Bancos : EntidadeBase
{
    [Required(ErrorMessage = "O campo NomeBanco é obrigatório.")]
    public string NomeBanco { get; set; }

    [Required(ErrorMessage = "O campo CodigoBanco é obrigatório.")]
    public int CodigoBanco { get; set; }

    [Required(ErrorMessage = "O campo PercentualJuros é obrigatório.")]
    public decimal PercentualJuros { get; set; }

    public override bool Validar()
    {
        if (string.IsNullOrEmpty(NomeBanco)) return false;
        if (CodigoBanco == 0) return false;
        if (CodigoBanco == 0) return false;

        return true;
    }
}
