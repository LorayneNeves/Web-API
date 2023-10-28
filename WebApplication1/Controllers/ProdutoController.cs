using Application.Interfaces;
using Application.ViewModels;
using Microsoft.AspNetCore.Mvc;
using OpenQA.Selenium.Support.UI;


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

        [HttpGet]
        [Route("ObterPorId/{id}")]
        [ActionName("ObterPorId")]
        public IActionResult ObterPorId(Guid id)
        {
            return Ok(_produtoService.ObterPorId(id));
        }

        [HttpGet]
        [Route("ObterPorNome/{nome}")]
        [ActionName("ObterPorNome")]
        public IActionResult ObterPorNome(string nome)
        {
            return Ok(_produtoService.ObterPorNome(nome));
        }

        [HttpPut]
        [Route("Desativar/{id}")]
        [ActionName("Desativar")]
        public async Task<IActionResult> Desativar(Guid id)
        {
            await _produtoService.Desativar(id);

            return Ok("Produto desativado com sucesso");
        }

        [HttpPut]
        [Route("Ativo/{id}")]
        [ActionName("Ativar")]
        public async Task<IActionResult> Ativar(Guid id)
        {
                await _produtoService.Ativar(id);
                return Ok("Produto ativado com sucesso");
        }

        [HttpPut]
        [Route("AtualizarValor/{id}")]
        [ActionName("AtualizarValor")]
        public async Task<IActionResult> AtualizarValor(Guid id, [FromBody] ProdutoViewModel produtoViewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _produtoService.AtualizarValor(id, produtoViewModel);
            return Ok("Valor do produto atualizado com sucesso");
        }

        [HttpPut]
        [Route("DebitarEstoque/{id}")]
        [ActionName("DebitarEstoque")]
        public async Task<IActionResult> DebitarEstoque(Guid id, [FromBody] int quantidade)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _produtoService.DebitarEstoque(id, quantidade);
            return Ok("Produto debitado com sucesso");
        } 
        
        [HttpPut]
        [Route("ReporEstoque/{id}")]
        [ActionName("ReporEstoque")]
        public async Task<IActionResult> ReporEstoque(Guid id, [FromBody] int quantidade)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _produtoService.ReporEstoque(id, quantidade);
            return Ok("Produto acrescentado com sucesso");
        }

        [HttpPut]
        [Route("Atualizar/{id}")]
        public async Task<IActionResult> Put(Guid id, [FromBody] ProdutoViewModel produtoViewModel)
        {
            await _produtoService.Atualizar(id,produtoViewModel);

            return Ok("Produto atualizado com sucesso");
        }
    }
}