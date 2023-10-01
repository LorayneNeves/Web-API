using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interface
{
    public interface IFornecedorRepository
    {
        public void Adicionar(Fornecedor novoFornecedor);
        public Fornecedor BuscarPorId(int codigo);

        public IEnumerable<Fornecedor> BuscarTodos();
        public IEnumerable<Fornecedor> BuscarTodosAtivos();
        public IEnumerable<Fornecedor> BuscarTodosInativos();
    }
}
