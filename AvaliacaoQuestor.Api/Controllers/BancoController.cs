using AvaliacaoQuestor.Business.Features;
using AvaliacaoQuestor.Domain.Features;
using Microsoft.AspNetCore.Mvc;

namespace AvaliacaoQuestor.Api.Controllers;
/// <summary>
/// BancoController
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class BancoController : ControllerBase
{
    private BancosBLL _bll;

    public BancoController(BancosBLL bll)
    {
        _bll = bll ?? throw new ArgumentNullException(nameof(bll));
    }

    /// <summary>
    /// Grava um banco no banco de dados
    /// </summary>
    /// <returns></returns>
    [HttpPost]
    [Route("CadastrarBanco")]
    public async Task CadastrarBanco([FromBody] Bancos banco)
    {
        await _bll.InserirNovo(banco);
    }

    /// <summary>
    /// Busca todos os bancos gravados no banco de dados
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    [Route("BuscarTodosBancos")]
    public IActionResult BuscarTodosBancos()
    {
        return Ok(_bll.SelecionarTodos());
    }

    /// <summary>
    /// Busca um banco no banco de dados que corresponda ao Código do Banco informado
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    [Route("BuscarBancoPorCodigo")]
    public IActionResult BuscarBancoPorCodigoBanco(int codigoBanco)
    {
        return Ok(_bll.SelecionarUmRegistro(codigoBanco));
    }
}
