using programacaoII_back_end.Domain.Entities;

namespace programacaoII_back_end.Domain.Interfaces.Services;

public interface IUsuarioService
{
    Usuario? ObterPorEmail(string email);
    Usuario CadastrarUsuario(Usuario usuario);
}