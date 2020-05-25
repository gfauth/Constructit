using System;
using CalculadoraDiaUtil.Models;
using Microsoft.AspNetCore.Mvc;

namespace CalculadoraDiaUtil.Controllers
{
    [ApiController]
    [Route("calculadora")]
    public class CalculatorController : ControllerBase
    {
        /// <summary>
        /// Método GET que realizada a chamada ao calculo de variável data, para o retorno da informação de que dia da do mês e da semana será o quinto dia útil do mês referido na data de entrada.
        /// </summary>
        /// <param name="data">(DateTime) Data de entrada.</param>
        /// <returns>(Json) Resultado do calculo ou mensagem de erro.</returns>
        [Route("quintodia")]
        public ActionResult Calculator(DateTime data)
        {
            try
            {
                CalculatorModel model = new CalculatorModel(data);

                string result = string.Format("A data inserida foi {0}. Este mês tem o dia {1} com sendo o seu quinto dia útil.", data.ToShortDateString(), model.GetResult());
                return Ok(new { status = 200, result });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = new[] { "Não foi possível concluir a requisição.", ex.Message } });
            }
        }
    }
}
