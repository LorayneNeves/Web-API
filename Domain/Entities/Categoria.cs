using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Categoria
    {
        public Categoria(int codigo, string descricao)
        {
            Codigo = codigo;
            Descricao = descricao;
        }

        #region 2 - Propriedades

        public int Codigo { get; private set; }
        public string Descricao { get; private set; }
        #endregion
        #region 3 - Comportamentos
        public void AlterarDescricao(string descricao) => Descricao = descricao;
        public void SetaCodigoProduto(int novocodigo) => Codigo = novocodigo;
        #endregion
    }
}
