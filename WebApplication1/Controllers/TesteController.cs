﻿using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models.Request;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TesteController : PrincipalController
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Olá mundo, minha primeira requisição GET");
        }

        [HttpGet("ObterPorId/{id}")]
        public IActionResult Get(int id)
        {
            return Ok($"Olá mundo,exemplo rota com id = {id}");

        }

        [HttpPost]
        public IActionResult Post(TesteViewModel testeViewModel)
        {
            if (!ModelState.IsValid)
            {
                return ApiBadRequestResponse(ModelState);

            }
            return ApiResponse(testeViewModel, "Registro criado com sucesso!");
        }
    }
}
