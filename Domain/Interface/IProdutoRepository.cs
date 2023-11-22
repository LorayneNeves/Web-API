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

        IEnumerable<Produto> ObterPorNome(string nome);
        Task Adicionar(Produto produto);
        Task Desativar(Produto produto);
        Task Ativar(Produto produto);
        Task Atualizar(Produto produto);
        Task AtualizarValor(Produto produto);
        Task DebitarEstoque(Produto produto);
        Task ReporEstoque(Produto produto);
        Task AtualizarEstoque(Produto produto);
        

    }
}
