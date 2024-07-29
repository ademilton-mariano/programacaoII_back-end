using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using programacaoII_back_end.Domain.Entities;
using programacaoII_back_end.Domain.Interfaces.Repositories;

namespace programacaoII_back_end.Aplication.Services;

public class TokenService
{
    private readonly IConfiguration _configuration;
    private readonly IUsuarioRepository _usuarioRepository;

    public TokenService(IConfiguration configuration, IUsuarioRepository usuarioRepository)
    {
        _configuration = configuration;
        _usuarioRepository = usuarioRepository;
    }

    public string GerarToken(Usuario usuario)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var chave = Encoding.ASCII.GetBytes(_configuration["Jwt:Key"] ?? string.Empty);
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Expires = DateTime.UtcNow.AddHours(8),
            SigningCredentials = new SigningCredentials(
                new SymmetricSecurityKey(chave),
                SecurityAlgorithms.HmacSha256Signature),
            Subject = GerarClaims(usuario)
        };
        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }
    
    private static ClaimsIdentity GerarClaims(Usuario usuario)
    {
        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, usuario.Nome),
            new Claim(ClaimTypes.Email, usuario.Email),
            new Claim("Id", usuario.Id.ToString())
        };
        return new ClaimsIdentity(new GenericIdentity(usuario.Email, "Login"), claims);
    }
}