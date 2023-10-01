using Application.ViewModels;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IFornecedorService
    {
        Task<IEnumerable<FornecedorViewModel>> ObterTodos();
        Task<FornecedorViewModel> ObterPorId(Guid id);
        Task<IEnumerable<FornecedorViewModel>> ObterPorCategoria(int codigo);
        public void Adicionar(NovoFornecedorViewModel novoFornecedor);
        public Fornecedor BuscarPorId(int codigo);

        public IEnumerable<Fornecedor> BuscarTodos();
        public IEnumerable<Fornecedor> BuscarTodosAtivos();
        public IEnumerable<Fornecedor> BuscarTodosInativos();
    }
}
