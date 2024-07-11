using Microsoft.AspNetCore.Mvc;
using programacaoII_back_end.Aplication.ViewModels;
using programacaoII_back_end.Domain.Interfaces.Services;

namespace programacaoII_back_end.WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class LoginController : ControllerBase
{
    private readonly IUsuarioService _usuarioService;

    public LoginController(IUsuarioService usuarioService)
    {
        _usuarioService = usuarioService;
    }

    [HttpPost]
    public IActionResult Login([FromBody] LoginViewModel login)
    {
        try
        {
            var usuario = _usuarioService.ObterPorEmail(login.Email);

            if (usuario == null)
                return NotFound("E-mail ou senha inválido");

            return Ok("Logado com sucesso");
        }
        catch
        {
            return BadRequest("Falha interna no servidor");
        }
    }
}