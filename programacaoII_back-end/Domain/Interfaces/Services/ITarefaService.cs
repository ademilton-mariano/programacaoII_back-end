using programacaoII_back_end.Aplication.ViewModels;
using programacaoII_back_end.Domain.Entities;

namespace programacaoII_back_end.Domain.Interfaces.Services;

public interface ITarefaService
{
   Tarefa ObterPorId(int id);
   IQueryable<Tarefa> ObterTodasTarefas();
   Tarefa AdicionarTarefa(TarefaViewModel tarefaViewModel, int idUsuario);
}