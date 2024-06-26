using Microsoft.EntityFrameworkCore;

namespace programacaoII_back_end.Infra.Data;

public class BancoDadosContext : DbContext
{
    public BancoDadosContext(DbContextOptions<BancoDadosContext> options) : base(options)
    {
    }
}