using Microsoft.AspNetCore.Mvc;
using programacaoII_back_end.Domain.Entities;
using programacaoII_back_end.Domain.Interfaces.Services;

namespace programacaoII_back_end.WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsuarioController : ControllerBase
{
    private readonly IUsuarioService _usuarioService;

    public UsuarioController(IUsuarioService usuarioService)
    {
        _usuarioService = usuarioService;
    }

    [HttpGet ("{email}:string")]
    public IActionResult ObterUsuarioPorEmail([FromRoute] string email)
    {
        try
        {
            var usuario = _usuarioService.ObterPorEmail(email);

            if (usuario == null)
                return NotFound("Usuário não encontrado");

            return Ok(usuario);
        }
        catch
        {
            return BadRequest("Falha interna no servidor");
        }
    }
    
    [HttpPost]
    public IActionResult CadastrarUsuario([FromBody] Usuario usuario)
    {
        try
        {
            var usuarioCriado = _usuarioService.CadastrarUsuario(usuario);
            return Created($"Usuário {usuarioCriado.Nome } cadastrado com sucesso"
                , usuarioCriado);
        }
        catch
        {
            return BadRequest("Falha interna no servidor");
        }
    }
}