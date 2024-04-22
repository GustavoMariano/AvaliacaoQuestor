using AvaliacaoQuestor.Business.Features;
using AvaliacaoQuestor.Domain.Features;
using Microsoft.AspNetCore.Mvc;

namespace AvaliacaoQuestor.Api.Controllers;
/// <summary>
/// BoletoController
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class BoletoController : ControllerBase
{
    private BoletosBLL _bll;

    public BoletoController(BoletosBLL bll)
    {
        _bll = bll ?? throw new ArgumentNullException(nameof(bll));
    }

    /// <summary>
    /// Grava um boleto no banco de dados
    /// </summary>
    /// <returns></returns>
    [HttpPost]
    [Route("CadastrarBoleto")]
    public async Task CadastrarBoleto([FromBody] Boletos boleto)
    {
        await _bll.InserirNovo(boleto);
    }

    /// <summary>
    /// Busca um boleto no banco de dados que corresponda ao ID informado
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet]
    [Route("BuscarBoletoPorId")]
    public IActionResult BuscarBoletoPorId(int id)
    {
        return Ok(_bll.SelecionarUmRegistro(id));
    }
}
