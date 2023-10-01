using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Fornecedor
    { 
        #region 1 - Contrutores
        public Fornecedor(int codigo, string razaoSocial, string cnpj, bool ativo, DateTime data, string email)
        {
            Codigo = codigo;
            RazaoSocial = razaoSocial;
            Cnpj = cnpj;
            Ativo = ativo;
            Data = data;
            Email = email;
        }
 #endregion
        #region 2 - Propriedades
        public int Codigo { get;private set; }
        public string RazaoSocial { get; private set; }
        public string Cnpj { get; private set; }
        public bool Ativo { get; private set; }
        public DateTime Data { get; private set; }
        public string Email { get; private set; }
        #endregion

        #region 3 - Comportamentos

        public void SetaCodigoProduto(int novocodigo) => Codigo = novocodigo;
        public void Ativar() => Ativo = true;
        public void Desativar() => Ativo = false;

        #endregion
    }
}
