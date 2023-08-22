using WebApplication1.Models.CustomValidations;

namespace WebApplication1.Models.Request
{
    public class TesteViewModel
    {
        public string Nome { get; set; }
        public int Idade { get; set; }

        [CpfValidation(ErrorMessage = "CPF inválido.")]
        public string Cpf { get; set; }
     }
}

