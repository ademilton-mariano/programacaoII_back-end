using programacaoII_back_end.Aplication.ViewModels;
using programacaoII_back_end.Domain.Entities;

namespace programacaoII_back_end.Domain.Interfaces.Repositories;

public interface IUsuarioRepository
{
    Usuario? ObterUsuarioPorEmail(string email);
    Usuario CadastrarUsuario(Usuario usuario);
    Usuario? AtualizarUsuario(Usuario usuarioAtualizado);
    Usuario ObterPorId(int id);
    void DeletarUsuario(Usuario usuario);
    IQueryable<Usuario> ObterTodosUsuarios();
}