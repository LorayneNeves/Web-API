using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interface
{
    public interface IProdutoRepository
    {
        IEnumerable<Produto> ObterTodos();
        Task<Produto> ObterPorId(Guid id);
        Task<IEnumerable<Produto>> ObterPorCategoria(int codigo);

        Task Adicionar(Produto produto);
        Task Desativar(Produto produto);
        void Atualizar(Produto produto);
    }
}
