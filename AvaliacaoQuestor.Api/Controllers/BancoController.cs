using AutoMapper;
using AvaliacaoQuestor.Api.DTO;
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
    private readonly BancosBLL _bll;
    private readonly IMapper _mapper;

    public BancoController(BancosBLL bll, IMapper mapper)
    {
        _bll = bll ?? throw new ArgumentNullException(nameof(bll));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    /// <summary>
    /// Grava um banco no banco de dados
    /// </summary>
    /// <returns></returns>
    [HttpPost]
    [Route("CadastrarBanco")]
    public async Task CadastrarBanco([FromBody] BancosDTO bancoDTO)
    {
        await _bll.InserirNovo(_mapper.Map<Bancos>(bancoDTO));
    }

    /// <summary>
    /// Busca todos os bancos gravados no banco de dados
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    [Route("BuscarTodosBancos")]
    public IActionResult BuscarTodosBancos()
    {
        return Ok(_mapper.Map<List<BancosDTO>>(_bll.SelecionarTodos()));
    }

    /// <summary>
    /// Busca um banco no banco de dados que corresponda ao Código do Banco informado
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    [Route("BuscarBancoPorCodigo")]
    public IActionResult BuscarBancoPorCodigoBanco(int codigoBanco)
    {
        var banco = _bll.SelecionarUmRegistro(codigoBanco);
        if (banco == null)
            return NotFound();

        return Ok(_mapper.Map<BancosDTO>(banco));
    }
}
