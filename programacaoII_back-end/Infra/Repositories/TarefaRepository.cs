using programacaoII_back_end.Domain.Entities;
using programacaoII_back_end.Domain.Interfaces.Repositories;
using programacaoII_back_end.Infra.Data;

namespace programacaoII_back_end.Infra.Repositories;

public class TarefaRepository : ITarefaRepository
{
    private readonly BancoDadosContext _context;

    public TarefaRepository(BancoDadosContext context)
    {
        _context = context;
    }

    public Tarefa ObterPorId(int id)
    {
        var retorno = _context.Tarefas
            .FirstOrDefault(t => t.Id == id);
        return retorno;
    }

    public IQueryable<Tarefa> ObterTodasTarefas()
    {
        var retorno = _context.Tarefas;
        return retorno;
    }

    public Tarefa AdicionarTarefa(Tarefa tarefa)
    {
        _context.Tarefas.Add(tarefa);
        _context.SaveChanges();
        return tarefa;
    }
}