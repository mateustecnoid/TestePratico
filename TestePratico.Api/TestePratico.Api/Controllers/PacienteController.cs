using Microsoft.AspNetCore.Mvc;
using TestePratico.Aplicacao.Servicos.Interfaces;
using TestePratico.DataTransfer.Request;

namespace TestePratico.Api.Controllers
{
    [Route("api/")]
    [ApiController]
    public class PacienteController : ControllerBase
    {
        private readonly IPacienteAppServico pacienteServico;

        public PacienteController(IPacienteAppServico pacienteServico)
        {
            this.pacienteServico = pacienteServico;
        }        

        [HttpPost("paciente")]
        public IActionResult Inserir([FromBody]PacienteRequest request)
        {
            pacienteServico.Inserir(request);

            return Ok();
        }

        [HttpGet("paciente/{codigo:int}")]
        public IActionResult Recuperar([FromRoute] int codigo)
        {
            var response = pacienteServico.Recuperar(codigo);

            if(response == null)
            {
                return NotFound();
            }

            return Ok(response);
        }

        [HttpGet("paciente")]
        public IActionResult RecuperarFiltrado([FromQuery] FiltroPacienteRequest request)
        {
            var response = pacienteServico.Recuperar(request);

            if (response == null)
            {
                return NotFound();
            }

            return Ok(response);
        }

        [HttpPut("paciente")]
        public IActionResult Atualizar([FromBody]PacienteRequest request)
        {
            pacienteServico.Atualizar(request);

            return Ok();
        }

        [HttpDelete("paciente/{codigo:int}")]
        public IActionResult Excluir([FromRoute] int codigo)
        {
            pacienteServico.Excluir(codigo);

            return Ok();
        }
    }
}