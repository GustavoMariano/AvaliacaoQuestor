using AvaliacaoQuestor.Domain.Shared;
using System.ComponentModel.DataAnnotations;

namespace AvaliacaoQuestor.Domain.Features;

public class Boletos : EntidadeBase
{
    [Required(ErrorMessage = "O campo NomePagador é obrigatório.")]
    public string NomePagador { get; set; }

    [Required(ErrorMessage = "O campo CpfCnpj é obrigatório.")]
    public string CpfCnpj { get; set; }

    [Required(ErrorMessage = "O campo NomeBeneficiario é obrigatório.")]
    public string NomeBeneficiario { get; set; }

    [Required(ErrorMessage = "O campo Valor é obrigatório.")]
    public decimal Valor { get; set; }

    [Required(ErrorMessage = "O campo DataVencimento é obrigatório.")]
    [DataType(DataType.Date)]
    public DateTime DataVencimento { get; set; }

    public string? Observacao { get; set; }

    [Required(ErrorMessage = "O campo BancoId é obrigatório.")]
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
