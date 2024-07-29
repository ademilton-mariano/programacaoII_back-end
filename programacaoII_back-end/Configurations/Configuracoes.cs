using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using programacaoII_back_end.Aplication.Services;
using programacaoII_back_end.Domain.Interfaces.Repositories;
using programacaoII_back_end.Domain.Interfaces.Services;
using programacaoII_back_end.Infra.Data;
using programacaoII_back_end.Infra.Repositories;

namespace programacaoII_back_end.CrossCutting.IoC;

public static class Configuracoes
{
    public static IServiceCollection ConfigurarInjecao(this IServiceCollection services, IConfiguration configuration)
    { 
        //configuracao do banco de dados
        var connectionString = configuration.GetConnectionString("DefaultConnection");
        services.AddDbContext<BancoDadosContext>(options =>
            options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

        services.AddTransient<TokenService>();
        
        //servicos
        services.AddScoped<IUsuarioService, UsuarioService>();
        services.AddScoped<ITarefaService, TarefaService>();

        //repositorios
        services.AddScoped<IUsuarioRepository, UsuarioRepository>();
        services.AddScoped<ITarefaRepository, TarefaRepository>();

        return services;
    }
    
    public static IServiceCollection ConfigurarJwt(this IServiceCollection services, IConfiguration configuration)
    { 
        var chave = Encoding.ASCII.GetBytes(configuration["Jwt:Key"] ?? string.Empty);
        
        services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(chave),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });

        return services;
    }
    
}