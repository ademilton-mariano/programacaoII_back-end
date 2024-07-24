using programacaoII_back_end.Aplication.ViewModels;
using programacaoII_back_end.Domain.Entities;
using programacaoII_back_end.Domain.Interfaces.Repositories;
using programacaoII_back_end.Domain.Interfaces.Services;

namespace programacaoII_back_end.Aplication.Services;

public class UsuarioService : IUsuarioService
{
    private readonly IUsuarioRepository _usuarioRepository;

    public UsuarioService(IUsuarioRepository usuarioRepository)
    {
        _usuarioRepository = usuarioRepository;
    }

    public Usuario ObterPorEmail(string email)
    {
        var retorno = _usuarioRepository.ObterUsuarioPorEmail(email);
        return retorno;
    }
    
    public Usuario CadastrarUsuario(UsuarioViewModel usuario)
    {
        var novoUsuario = new Usuario
        {
            Nome = usuario.Nome,
            Email = usuario.Email,
            Senha = usuario.Senha
        };
        var retorno = _usuarioRepository.CadastrarUsuario(novoUsuario);
        return retorno;
    }

    public Usuario ObterPorId(int id)
    {
        var retorno = _usuarioRepository.ObterPorId(id);
        return retorno;
    }

    public void DeletarUsuario(Usuario usuario)
    {
        _usuarioRepository.DeletarUsuario(usuario);
    }

    public IQueryable<Usuario> ObterTodosUsuarios()
    {
        var retorno = _usuarioRepository.ObterTodosUsuarios();
        return retorno;
    }

    public Usuario AtualizarUsuario(int id,UsuarioViewModel usuario)
    {
        var usuarioPersistido = _usuarioRepository.ObterPorId(id);
        if (usuarioPersistido == null)
            return null;
        
        usuarioPersistido.Nome = usuario.Nome;
        usuarioPersistido.Email = usuario.Email;
        usuarioPersistido.Senha = usuario.Senha;
        
        var retorno = _usuarioRepository.AtualizarUsuario(usuarioPersistido);
        return retorno;
    }
}