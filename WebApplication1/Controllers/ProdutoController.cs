using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models.Request;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProdutoController : ControllerBase
    {
        [HttpGet("{codigo")]
       public IActionResult Get(int codigo)
        {
            return Ok();
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok();
        }

        [HttpPost]
        public IActionResult Post(NovoProdutoViewModel novoProdutoViewModel)
        {
            return Ok();

        }

        [HttpPut("{codigo}")]
        public IActionResult Put(int codigo,[FromBody] EditaProdutoViewModel editaProdutoViewModel)
        {
            return Ok();
        }

        [HttpDelete("{codigo}")]
        public IActionResult Delete(int codigo)
        {
            return Ok();
        }
    }
}
