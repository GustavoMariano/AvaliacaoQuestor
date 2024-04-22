using AvaliacaoQuestor.Domain.Features;
using AvaliacaoQuestor.Infra.Shared;

namespace AvaliacaoQuestor.Infra.Repositories;

public class BancoRepository : RepositoryBase<Bancos>
{
    public BancoRepository(AvaliacaoQuestorDBContext db) : base(db)
    {
    }

    public override Bancos SelecionarUmRegistro(int id)
    {
        try
        {
            return dbSet.FirstOrDefault(x => x.CodigoBanco.Equals(id));
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
}
