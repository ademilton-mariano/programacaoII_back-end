using programacaoII_back_end.Aplication.ViewModels;
using programacaoII_back_end.Domain.Entities;
using programacaoII_back_end.Domain.Interfaces.Repositories;
using programacaoII_back_end.Domain.Interfaces.Services;

namespace programacaoII_back_end.Aplication.Services;

public class TarefaService : ITarefaService
{
    private readonly ITarefaRepository _tarefaRepository;
    private readonly IUsuarioRepository _usuarioRepository;

    public TarefaService(ITarefaRepository tarefaRepository, IUsuarioRepository usuarioRepository)
    {
        _tarefaRepository = tarefaRepository;
        _usuarioRepository = usuarioRepository;
    }

    public Tarefa ObterPorId(int id)
    {
        var retorno = _tarefaRepository.ObterPorId(id);
        return retorno;
    }

    public IQueryable<Tarefa> ObterTodasTarefas()
    {
        var retorno = _tarefaRepository.ObterTodasTarefas();
        return retorno;
    }

    public Tarefa AdicionarTarefa(TarefaViewModel tarefaViewModel, int idUsuario)
    {
        var usuario = _usuarioRepository.ObterPorId(idUsuario);
        var tarefa = new Tarefa
        {
            Descricao = tarefaViewModel.Descricao,
            Nome = tarefaViewModel.Nome,
            Usuario = usuario
            //UsuarioId = usuario.Id
        };
        
        var retorno = _tarefaRepository.AdicionarTarefa(tarefa);

        return retorno;
    }
}