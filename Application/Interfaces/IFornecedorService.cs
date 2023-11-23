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
        IEnumerable<FornecedorViewModel> ObterTodosF();
        Task<FornecedorViewModel> ObterPorId(Guid id);
        IEnumerable<FornecedorViewModel> ObterPorNome(string nome);
        Task Adicionar(NovoFornecedorViewModel fornecedorViewModel);
        Task Atualizar(Guid id, FornecedorViewModel fornecedor);
        Task Desativar(Guid id);
        Task Ativar(Guid id);
    }
}
