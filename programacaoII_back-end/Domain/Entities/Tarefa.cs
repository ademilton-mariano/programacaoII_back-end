namespace programacaoII_back_end.Domain.Entities;

public class Tarefa
{
    public int Id { get; set; }
    public string Descricao { get; set; }
    public string  Nome { get; set; }
    public Usuario Usuario { get; set; }
    //public int UsuarioId { get; set; }
}