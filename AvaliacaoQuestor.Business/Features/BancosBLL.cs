using AvaliacaoQuestor.Business.Shared;
using AvaliacaoQuestor.Domain.Features;
using AvaliacaoQuestor.Domain.Shared;

namespace AvaliacaoQuestor.Business.Features;

public class BancosBLL : BusinessBase<Bancos>
{
    private readonly IRepository<Bancos> _bancosRepository;

    public BancosBLL(IRepository<Bancos> bancoRepository)
    {
        _bancosRepository = bancoRepository ?? throw new ArgumentNullException(nameof(bancoRepository));
    }

    public override Task<int> InserirNovo(Bancos registro)
    {
        if (registro.Validar())
            return _bancosRepository.InserirNovo(registro);

        throw new NotImplementedException();
    }

    public override Bancos SelecionarUmRegistro(int codigoBanco)
    {
        return _bancosRepository.SelecionarUmRegistro(codigoBanco);
    }

    public override List<Bancos> SelecionarTodos()
    {
        return _bancosRepository.SelecionarTodos();
    }
}
