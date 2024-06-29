using Microsoft.EntityFrameworkCore;
using programacaoII_back_end.Aplication.Services;
using programacaoII_back_end.Domain.Interfaces.Repositories;
using programacaoII_back_end.Domain.Interfaces.Services;
using programacaoII_back_end.Infra.Data;
using programacaoII_back_end.Infra.Repositories;

namespace programacaoII_back_end.CrossCutting.IoC;

public static class InjecaoDependencia
{
    public static IServiceCollection ConfigurarInjecao(this IServiceCollection services, IConfiguration configuration)
    { 
        var connectionString = configuration.GetConnectionString("DefaultConnection");
        services.AddDbContext<BancoDadosContext>(options =>
            options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));
        
        //servicos
        services.AddScoped<IUsuarioService, UsuarioService>();

        //repositorios
        services.AddScoped<IUsuarioRepository, UsuarioRepository>();

        return services;
    }
    
}