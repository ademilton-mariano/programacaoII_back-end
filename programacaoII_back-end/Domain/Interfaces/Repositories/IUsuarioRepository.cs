using programacaoII_back_end.Domain.Entities;

namespace programacaoII_back_end.Domain.Interfaces.Repositories;

public interface IUsuarioRepository
{
    Usuario? ObterUsuarioPorEmail(string email);
    Usuario CadastrarUsuario(Usuario usuario);
}