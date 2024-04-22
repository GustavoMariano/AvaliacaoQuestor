using AvaliacaoQuestor.Domain.Shared;

namespace AvaliacaoQuestor.Domain.Features;

public class Bancos : EntidadeBase
{
    public string NomeBanco { get; set; }
    public int CodigoBanco { get; set; }
    public decimal PercentualJuros { get; set; }

    public override bool Validar()
    {
        if (string.IsNullOrEmpty(NomeBanco)) return false;
        if (CodigoBanco == 0) return false;
        if (CodigoBanco == 0) return false;

        return true;
    }
}
