using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using WebApplication1.Configurations;

namespace WebApplication1.Controllers
{
     public abstract class PrincipalController : ControllerBase
     {
         protected IActionResult ApiResponse<T>(T data, string message = null)
         {
             var response = new RetornoApiCustomizado<T>
             {
                 Sucesso = true,
                 Menssagem = message,
                 Dados = data,
                 Status = 200
             };
             return Ok(response);
         }
         protected IActionResult ApiBadRequestResponse(ModelStateDictionary modelState, string message = "Dados inválidos")
         {
             var erros = modelState.Values.SelectMany(e => e.Errors);
            var response = new RetornoApiCustomizado<object>
            {
                Sucesso = false,
                Menssagem = message,
                Dados = erros.Select(n => n.ErrorMessage).ToArray(),
                Status = 400
             };
             return BadRequest(response);
         }
     }
 }
