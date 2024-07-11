using programacaoII_back_end.Domain.Entities;
using programacaoII_back_end.Domain.Interfaces.Repositories;
using programacaoII_back_end.Infra.Data;

namespace programacaoII_back_end.Infra.Repositories;

public class UsuarioRepository : IUsuarioRepository
{
    private readonly BancoDadosContext _context;

    public UsuarioRepository(BancoDadosContext context)
    {
        _context = context;
    }

    public Usuario? ObterUsuarioPorEmail(string email)
    {
        var retorno = _context.Usuarios
            .FirstOrDefault(u => u.Email == email);
        return retorno;
    }

    public Usuario CadastrarUsuario(Usuario usuario)
    {
        _context.Usuarios.Add(usuario);
        _context.SaveChanges();
        return usuario;
    }
}