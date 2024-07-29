using Microsoft.AspNetCore.Mvc;
using programacaoII_back_end.Aplication.Services;
using programacaoII_back_end.Aplication.ViewModels;
using programacaoII_back_end.Domain.Interfaces.Services;

namespace programacaoII_back_end.WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class LoginController : ControllerBase
{
    private readonly IUsuarioService _usuarioService;
    private readonly TokenService _tokenService;

    public LoginController(IUsuarioService usuarioService, TokenService tokenService)
    {
        _usuarioService = usuarioService;
        _tokenService = tokenService;
    }

    [HttpPost]
    public IActionResult Login([FromBody] LoginViewModel login)
    {
        try
        {
            var usuario = _usuarioService.ObterPorEmail(login.Email);

            if (usuario == null || usuario.Senha != login.Senha)
                return NotFound("E-mail ou senha inválido");
            
            var token = _tokenService.GerarToken(usuario);

            return Ok(new
            {
                usuario.Id,
                usuario.Nome,
                usuario.Email,
                Token = token
            });
        }
        catch
        {
            return BadRequest("Falha interna no servidor");
        }
    }
}