﻿using WebApplication1.Models.CustomValidations;

namespace WebApplication1.Models.Request
{
    public class AlunoViewModel
    {
        public string Nome { get; set; }
        public int Idade { get; set; }

        [CpfValidation]
        public string cpf { get; set; }
    }
}
