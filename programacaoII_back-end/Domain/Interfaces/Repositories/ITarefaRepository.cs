using programacaoII_back_end.Domain.Entities;

namespace programacaoII_back_end.Domain.Interfaces.Repositories;

public interface ITarefaRepository
{
    Tarefa ObterPorId(int id);
    IQueryable<Tarefa> ObterTodasTarefas();
    Tarefa AdicionarTarefa(Tarefa tarefa);
}