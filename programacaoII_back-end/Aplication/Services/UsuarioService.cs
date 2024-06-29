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

    public Usuario? ObterPorEmail(string email)
    {
        var retorno = _usuarioRepository.ObterPorEmail(email);
        return retorno;
    }
}