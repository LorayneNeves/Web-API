using Application.Interfaces;
using Application.Services;
using Application.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FornecedorController : ControllerBase
    {
        private readonly IFornecedorService _fornecedorService;

        public FornecedorController(IFornecedorService fornecedorService)
        {
            _fornecedorService = fornecedorService;
        }

        [HttpPost]
        public IActionResult Post([FromBody] Application.ViewModels.NovoFornecedorViewModel novoFornecedorViewModel)
        {
            _fornecedorService.Adicionar(novoFornecedorViewModel);

            return Ok();
        }

        [HttpGet(Name = "ObterTodosF")]
        public IActionResult Get()
        {
            return Ok(_fornecedorService.ObterTodosF());
        }

        [HttpGet]
        [Route("ObterPorId/{id}")]
        [ActionName("ObterPorId")]
        public IActionResult ObterPorId(Guid id)
        {
            return Ok(_fornecedorService.ObterPorId(id));
        }

        [HttpGet]
        [Route("ObterPorNome/{nome}")]
        [ActionName("ObterPorNome")]
        public IActionResult ObterPorNome(string nome)
        {
            return Ok(_fornecedorService.ObterPorNome(nome));
        }

        [HttpPut]
        [Route("Desativar/{id}")]
        [ActionName("Desativar")]
        public async Task<IActionResult> Desativar(Guid id)
        {
            await _fornecedorService.Desativar(id);

            return Ok("Produto desativado com sucesso");
        }

        [HttpPut]
        [Route("Ativo/{id}")]
        [ActionName("Ativar")]
        public async Task<IActionResult> Ativar(Guid id)
        {
            await _fornecedorService.Ativar(id);
            return Ok("Produto ativado com sucesso");
        }


        [HttpPut]
        [Route("Atualizar/{id}")]
        public async Task<IActionResult> Put(Guid id, [FromBody] FornecedorViewModel fornecedorViewModel)
        {
            await _fornecedorService.Atualizar(id, fornecedorViewModel);

            return Ok("Produto atualizado com sucesso");
        }
    }
}
