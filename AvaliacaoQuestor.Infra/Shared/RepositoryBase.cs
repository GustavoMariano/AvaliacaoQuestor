using AvaliacaoQuestor.Domain.Shared;
using Microsoft.EntityFrameworkCore;

namespace AvaliacaoQuestor.Infra.Shared;

public class RepositoryBase<T> : IRepository<T> where T : EntidadeBase
{
    protected readonly AvaliacaoQuestorDBContext _db;
    protected readonly DbSet<T> dbSet;

    public RepositoryBase(AvaliacaoQuestorDBContext db)
    {
        _db = db;
        dbSet = db.Set<T>();
    }

    public Task<int> InserirNovo(T registro)
    {
        try
        {
            dbSet.AddAsync(registro);
            return _db.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public virtual T SelecionarUmRegistro(int id)
    {
        try
        {
            return dbSet.FirstOrDefault(x => x.Id.Equals(id));
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public virtual List<T> SelecionarTodos()
    {
        try
        {
            return dbSet.ToList<T>();
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
}
