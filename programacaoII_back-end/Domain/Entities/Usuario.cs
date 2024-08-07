﻿namespace programacaoII_back_end.Domain.Entities;

public class Usuario
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Email { get; set; }
    public string Senha { get; set; }
    public IList<Tarefa> Tarefas { get; set; }
}