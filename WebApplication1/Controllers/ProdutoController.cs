using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models.Request;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProdutoController : ControllerBase
    {
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
        [HttpDelete]
        public IActionResult Delete()
        {
            return Ok();
        }
    }
}
