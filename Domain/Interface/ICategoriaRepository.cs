using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interface
{
    public interface ICategoriaRepository
    {
        IEnumerable<Categoria> ObterTodos();
        Task<Categoria> ObterPorId(Guid id);
        Task<IEnumerable<Categoria>> ObterPorCategoria(int codigo);

        public void AdicionarCategoria(Categoria categoria);
        public void AtualizarCategoria(Categoria categoria);
        public void RemoverCategoria(int codigo, List<Categoria> categoria);
    }
}
