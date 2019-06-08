using Microsoft.AspNetCore.Mvc;
using TestePratico.Aplicacao.Servicos.Interfaces;
using TestePratico.DataTransfer.Request;

namespace TestePratico.Api.Controllers
{
    [Route("api/")]
    [ApiController]
    public class AgendamentoController : ControllerBase
    {
        private readonly IAgendamentoAppServico agendamentoServico;

        public AgendamentoController(IAgendamentoAppServico agendamentoServico)
        {
            this.agendamentoServico = agendamentoServico;
        }

        [HttpPost("agendamento")]
        public IActionResult Inserir(AgendamentoRequest request)
        {
            agendamentoServico.Inserir(request);

            return Ok();
        }

        [HttpGet("agendamento/{codigo:int}")]
        public IActionResult Recuperar([FromRoute] int codigo)
        {
            var response = agendamentoServico.Recuperar(codigo);

            if (response == null)
            {
                return NotFound();
            }

            return Ok(response);
        }

        [HttpGet("agendamento")]
        public IActionResult RecuperarFiltrado([FromRoute] FiltroAgendamentoRequest request)
        {
            var response = agendamentoServico.Recuperar(request);           

            return Ok(response);
        }

        [HttpPut("agendamento")]
        public IActionResult Atualizar([FromBody]AgendamentoRequest request)
        {
            agendamentoServico.Atualizar(request);

            return Ok();
        }

        [HttpDelete("agendamento/{codigo:int}")]
        public IActionResult Excluir([FromRoute] int codigo)
        {
            agendamentoServico.Excluir(codigo);

            return Ok();
        }
    }
}