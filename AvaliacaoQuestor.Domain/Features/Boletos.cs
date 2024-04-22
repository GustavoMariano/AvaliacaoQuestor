using AvaliacaoQuestor.Domain.Shared;

namespace AvaliacaoQuestor.Domain.Features;

public class Boletos : EntidadeBase
{
    public string NomePagador { get; set; }
    public string CpfCnpj { get; set; }
    public string NomeBeneficiario { get; set; }
    public decimal Valor { get; set; }
    public DateTime DataVencimento { get; set; }
    public string? Observacao { get; set; }
    public int BancoId { get; set; }

    public override bool Validar()
    {
        if (string.IsNullOrEmpty(NomePagador)) return false;
        if (string.IsNullOrEmpty(CpfCnpj)) return false;
        if (string.IsNullOrEmpty(NomeBeneficiario)) return false;
        if (Valor == 0) return false;
        if (BancoId == 0) return false;

        AlteraParaDataValidaComUtc();

        return true;
    }

    public void CalcularJuros(decimal percentualJuros)
    {
        this.Valor += this.Valor * (percentualJuros / 100);
    }

    private void AlteraParaDataValidaComUtc()
    {
        this.DataVencimento = new DateTime(DataVencimento.Year, DataVencimento.Month, DataVencimento.Day, 23, 59, 59, DateTimeKind.Utc);
    }
}
