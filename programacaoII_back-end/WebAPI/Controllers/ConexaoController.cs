using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MySql.Data.MySqlClient;
using programacaoII_back_end.Infra.Data;

namespace programacaoII_back_end.WebAPI.Controllers;

[ApiController]
public class ConexaoController : ControllerBase
{
    private readonly IConfiguration _configuration;
    private readonly BancoDadosContext _context;

    public ConexaoController(IConfiguration configuration, BancoDadosContext context)
    {
        _configuration = configuration;
        _context = context;
    }

    [HttpGet("teste-conexao-dapper")]
    public IActionResult TesteDapper()
    {
        var connectionString = _configuration.GetConnectionString("DefaultConnection");
        using (var db = new MySqlConnection(connectionString))
        {
            try
            {
                db.Open();
                return Ok("Conexão realizada com sucesso");
            }
            catch (Exception excecao)
            {
                return StatusCode(500, $"A conexão falhou: {excecao.Message}");
            }
        }
    }
    
    [HttpGet("teste-conexao-entity")]
    public IActionResult TesteEntity()
    {
        try
        {
            _context.Database.OpenConnection();
            _context.Database.CloseConnection();
            return Ok("Conexão realizada com sucesso");
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"A conexão falhou: {ex.Message}");
        }
    }
    
    [HttpGet("teste-conexao-ado-net")]
    public IActionResult TesteAdoNet()
    {
        var connectionString = _configuration.GetConnectionString("DefaultConnection");
        using (var db = new MySqlConnection(connectionString))
        {
            try
            {
                db.Open();
                return Ok("Conexão realizada com sucesso");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"A conexão falhou: {ex.Message}");
            }
        }
    }
}