using AvaliacaoQuestor.Domain.Shared;

namespace AvaliacaoQuestor.Business.Shared;

public abstract class BusinessBase<T> where T : EntidadeBase
{
    public abstract Task<int> InserirNovo(T registro);
    public abstract List<T> SelecionarTodos();
    public abstract T SelecionarUmRegistro(int id);
}
