using Application.Interfaces;
using Application.Services;
using Application.ViewModels;
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

        [HttpPost(Name = "AdicionarCategoria")]
        public IActionResult Post(Application.ViewModels.NovaCategoriaViewModel novaCategoriaViewModel)
        {
            _categoriaService.AdicionarCategoria(novaCategoriaViewModel);

            return Ok();
        }
        [HttpGet(Name = "ObterTodos")]
        public IActionResult Get()
        {
            return Ok(_categoriaService.ObterTodos());
        }

        [HttpDelete(Name = "RemoverCategoria")]
        public IActionResult Delete(CategoriaViewModel categoriaViewModel)
        {
            _categoriaService.RemoverCategoria(categoriaViewModel);
            return Ok(_categoriaService.ObterTodos());
        }
    }
}
