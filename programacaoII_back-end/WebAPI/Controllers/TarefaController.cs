using Microsoft.AspNetCore.Mvc;
using programacaoII_back_end.Aplication.ViewModels;
using programacaoII_back_end.Domain.Interfaces.Services;

namespace programacaoII_back_end.WebAPI.Controllers;

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
    
    [HttpPost("{idUsuario:int}")]
    public IActionResult AdicionarTarefa([FromBody] TarefaViewModel tarefaViewModel, int idUsuario)
    {
        try
        {
            var tarefa = _tarefaService.AdicionarTarefa(tarefaViewModel, idUsuario);
            return Ok(tarefa);
        }
        catch
        {
            return BadRequest("Falha interna no servidor");
        }
    }
}