using Application.Interfaces;
using Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoriaController : ControllerBase
    {
        private readonly ICategoriaService _categoriaService;

        public CategoriaController(ICategoriaService categoriaService)
        {
            _categoriaService = categoriaService;
        }

        [HttpPost(Name = "Adicionar")]
        public IActionResult Post(Application.ViewModels.NovaCategoriaViewModel novaCategoriaViewModel)
        {
            _categoriaService.Adicionar(novaCategoriaViewModel);

            return Ok();
        }
        [HttpGet(Name = "ObterTodos")]
        public IActionResult Get()
        {
            return Ok(_categoriaService.ObterTodos());
        }

        [HttpDelete(Name = "Remover")]
        public IActionResult Delete()
        {
            return Ok(_categoriaService.ObterTodos());
        }
    }
}
