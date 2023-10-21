using Application.Interfaces;
using Application.ViewModels;
using Microsoft.AspNetCore.Mvc;


namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProdutoController : ControllerBase
    {
        private readonly IProdutoService _produtoService;

        public ProdutoController(IProdutoService produtoService)
        {
            _produtoService = produtoService;
        }

        [HttpPost(Name = "Adicionar")]
        public IActionResult Post(Application.ViewModels.NovoProdutoViewModel novoProdutoViewModel)
        {
            _produtoService.Adicionar(novoProdutoViewModel);

            return Ok();
        }
        [HttpGet(Name = "ObterTodos")]
        public IActionResult Get()
        {
            return Ok(_produtoService.ObterTodos());
        }

        [HttpPut]
        [Route("Desativar/{id}")]
        public async Task<IActionResult> Put(Guid id)
        {
            await _produtoService.Desativar(id);

            return Ok("Produto desativado com sucesso");
        }
    }
}