using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models.Request;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TesteController : Controller
    {
        [HttpGet]
        public IActionResult Post(AlunoViewModel alunoViewModel)
        {
            if(alunoViewModel.Idade < 0)
            {
                return BadRequest("Idade invalida");
            }
           return Ok("Aluno criado com sucesso");
        }
    }
}
