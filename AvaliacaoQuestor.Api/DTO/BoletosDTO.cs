using System.ComponentModel.DataAnnotations;

namespace AvaliacaoQuestor.Api.DTO;

public class BoletosDTO
{
    [Required(ErrorMessage = "O campo Id é obrigatório.")]
    public int Id { get; set; }

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
}
