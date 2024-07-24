using Microsoft.AspNetCore.Mvc;
using programacaoII_back_end.Aplication.ViewModels;
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
    
    [HttpGet("{id:int}")]
    public IActionResult ObterUsuarioPorId([FromRoute] int id)
    {
        try
        {
            var usuario = _usuarioService.ObterPorId(id);

            if (usuario == null)
                return NotFound("Usuário não encontrado");

            return Ok(usuario);
        }
        catch
        {
            return BadRequest("Falha interna no servidor");
        }
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
    
    [HttpGet]
    public IActionResult ObterTodosUsuarios()
    {
        try
        {
            var usuarios = _usuarioService.ObterTodosUsuarios().ToList();
            return Ok(usuarios);
        }
        catch
        {
            return BadRequest("Falha interna no servidor");
        }
    }
    
    [HttpPost]
    public IActionResult CadastrarUsuario([FromBody] UsuarioViewModel usuario)
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
    
    [HttpPut("{id:int}")]
    public IActionResult AtualizarUsuario(int id, [FromBody] UsuarioViewModel usuario)
    {
        try
        {
            
            var usuarioAtualizado = _usuarioService.AtualizarUsuario(id, usuario);
            return Ok(usuarioAtualizado);
        }
        catch
        {
            return BadRequest("Falha interna no servidor");
        }
    }
    
    [HttpDelete("{id:int}")]
    public IActionResult DeletarUsuario(int id)
    {
        try
        {
            var usuario = _usuarioService.ObterPorId(id);
            if (usuario == null)
                return NotFound("Usuário não encontrado");
                
            _usuarioService.DeletarUsuario(usuario);
            return Ok("Usuário deletado com sucesso");
        }
        catch
        {
            return BadRequest("Falha interna no servidor");
        }
    }
}