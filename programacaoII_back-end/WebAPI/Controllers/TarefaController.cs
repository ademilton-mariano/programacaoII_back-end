using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using programacaoII_back_end.Aplication.ViewModels;
using programacaoII_back_end.Domain.Interfaces.Services;

namespace programacaoII_back_end.WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class TarefaController : ControllerBase
{
    private readonly ITarefaService _tarefaService;

    public TarefaController(ITarefaService tarefaService)
    {
        _tarefaService = tarefaService;
    }
    
    [HttpGet("{id:int}")]
    public IActionResult ObterTarefaPorId([FromRoute] int id)
    {
        try
        {
            var tarefa = _tarefaService.ObterPorId(id);

            if (tarefa == null)
                return NotFound("Tarefa não encontrada");

            return Ok(tarefa);
        }
        catch
        {
            return BadRequest("Falha interna no servidor");
        }
    }
    
    [HttpGet]
    public IActionResult ObterTodasTarefas()
    {
        try
        {
            var tarefas = _tarefaService.ObterTodasTarefas().ToList();
            return Ok(tarefas);
        }
        catch
        {
            return BadRequest("Falha interna no servidor");
        }
    }
    
    [HttpPost]
    public IActionResult AdicionarTarefa([FromBody] TarefaViewModel tarefaViewModel)
    {
        try
        {
            var obterUsuarioClaims = User.Claims.FirstOrDefault(c => c.Type == "Id");
            if (obterUsuarioClaims == null)
                return Unauthorized("Usuário não autenticado");
            
            var idUsuario = int.Parse(obterUsuarioClaims.Value);
            
            var tarefa = _tarefaService.AdicionarTarefa(tarefaViewModel, idUsuario);
            return Ok(tarefa);
        }
        catch
        {
            return BadRequest("Falha interna no servidor");
        }
    }
}