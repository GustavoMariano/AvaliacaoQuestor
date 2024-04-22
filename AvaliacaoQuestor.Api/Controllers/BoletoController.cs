using AutoMapper;
using AvaliacaoQuestor.Api.DTO;
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
    private readonly IMapper _mapper;

    public BoletoController(BoletosBLL bll, IMapper mapper)
    {
        _bll = bll ?? throw new ArgumentNullException(nameof(bll));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    /// <summary>
    /// Grava um boleto no banco de dados
    /// </summary>
    /// <returns></returns>
    [HttpPost]
    [Route("CadastrarBoleto")]
    public async Task CadastrarBoleto([FromBody] BoletosDTO boletoDTO)
    {
        await _bll.InserirNovo(_mapper.Map<Boletos>(boletoDTO));
    }

    /// <summary>
    /// Busca um boleto no banco de dados que corresponda ao ID informado
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    [Route("BuscarBoletoPorId")]
    public IActionResult BuscarBoletoPorId(int id)
    {
        var boleto = _bll.SelecionarUmRegistro(id);
        if(boleto == null)
            return NotFound();

        return Ok(_mapper.Map<BoletosDTO>(boleto));
    }
}
