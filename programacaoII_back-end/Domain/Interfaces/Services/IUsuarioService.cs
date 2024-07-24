using programacaoII_back_end.Aplication.ViewModels;
using programacaoII_back_end.Domain.Entities;

namespace programacaoII_back_end.Domain.Interfaces.Services;

public interface IUsuarioService
{
    Usuario ObterPorEmail(string email);
    Usuario CadastrarUsuario(UsuarioViewModel usuario);
    Usuario AtualizarUsuario(int id, UsuarioViewModel usuario);
    Usuario ObterPorId(int id);
    void DeletarUsuario(Usuario usuario);
    IQueryable<Usuario> ObterTodosUsuarios();
}