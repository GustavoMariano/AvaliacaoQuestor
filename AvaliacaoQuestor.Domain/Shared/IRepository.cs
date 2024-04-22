namespace AvaliacaoQuestor.Domain.Shared;

public interface IRepository<T> where T : EntidadeBase
{
    Task<int> InserirNovo(T registro);
    List<T> SelecionarTodos();
    T SelecionarUmRegistro(int id);
}
