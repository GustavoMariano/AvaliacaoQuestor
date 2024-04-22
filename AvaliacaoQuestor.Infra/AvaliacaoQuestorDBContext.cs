using AvaliacaoQuestor.Domain.Features;
using Microsoft.EntityFrameworkCore;

namespace AvaliacaoQuestor.Infra;

public class AvaliacaoQuestorDBContext : DbContext
{
    public AvaliacaoQuestorDBContext(DbContextOptions<AvaliacaoQuestorDBContext> options) : base(options)
    {
    }

    public DbSet<Boletos> Boletos { get; set; }
    public DbSet<Bancos> Bancos { get; set; }
}
