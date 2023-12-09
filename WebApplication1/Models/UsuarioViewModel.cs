using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class UsuarioViewModel
    {
        [SwaggerSchema(ReadOnly = true)]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public string Login { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public string Senha { get; set; }

        public bool Ativo { get; set; }
    }
}
