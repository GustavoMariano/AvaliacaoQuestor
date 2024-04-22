using AvaliacaoQuestor.Business.Shared;
using AvaliacaoQuestor.Domain.Features;
using AvaliacaoQuestor.Domain.Shared;

namespace AvaliacaoQuestor.Business.Features;

public class BoletosBLL : BusinessBase<Boletos>
{
    private readonly IRepository<Boletos> _boletosRepository;
    private readonly IRepository<Bancos> _bancosRepository;

    public BoletosBLL(IRepository<Boletos> boletoRepository, IRepository<Bancos> bancosRepository)
    {
        _boletosRepository = boletoRepository ?? throw new ArgumentNullException(nameof(boletoRepository));
        _bancosRepository = bancosRepository ?? throw new ArgumentNullException(nameof(bancosRepository));
    }

    public override Task<int> InserirNovo(Boletos registro)
    {
        if (registro.Validar())
            return _boletosRepository.InserirNovo(registro);

        throw new NotImplementedException();
    }

    public override Boletos SelecionarUmRegistro(int id)
    {
        var boleto = _boletosRepository.SelecionarUmRegistro(id);
        var banco = _bancosRepository.SelecionarUmRegistro(boleto.BancoId);
        boleto.CalcularJuros(banco.PercentualJuros);

        return boleto;
    }

    public override List<Boletos> SelecionarTodos()
    {
        throw new NotImplementedException();
    }
}
