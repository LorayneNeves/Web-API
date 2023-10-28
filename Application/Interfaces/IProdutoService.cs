using Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IProdutoService
    {
        IEnumerable<ProdutoViewModel> ObterTodos();
        Task<ProdutoViewModel> ObterPorId(Guid id);
        Task<IEnumerable<ProdutoViewModel>> ObterPorCategoria(int codigo);

        IEnumerable<ProdutoViewModel> ObterPorNome(string nome);
        Task Adicionar(NovoProdutoViewModel produto);
        Task Atualizar(Guid id,ProdutoViewModel produto);
        Task Desativar(Guid id);
        Task Ativar(Guid id);
        Task DebitarEstoque(Guid id, int quantidade);
        Task ReporEstoque(Guid id, int quantidade);
        Task AtualizarValor(Guid id, ProdutoViewModel produto);
        Task AtualizarEstoque(Guid id, ProdutoViewModel produto);
    }
}
