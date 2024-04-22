using AvaliacaoQuestor.Domain.Features;
using AvaliacaoQuestor.Infra.Shared;

namespace AvaliacaoQuestor.Infra.Repositories;

public class BoletoRepository : RepositoryBase<Boletos>
{
    public BoletoRepository(AvaliacaoQuestorDBContext db) : base(db)
    {
    }
}
