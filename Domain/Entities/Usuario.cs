using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    [Table("Usuarios")]
    public class Usuario
    {
        public Usuario(string login, string senha, bool ativo)
        {
            Login = login;
            Senha = senha;
            Ativo = ativo;
        }
        #region construtor
        public Usuario(Guid id,string login, string senha, bool ativo)
        {
            
            Login = login;
            Senha = senha;
            Ativo = ativo;
        }

        #endregion
        #region Propiedades
        public string Login { get; private set; }
        public string Senha { get; private set; }
        public bool Ativo { get; private set; }
        #endregion

        #region funções

        #endregion
    }
}
