using Application.ViewModels;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface ICategoriaService
    {
        IEnumerable<Categoria> ObterTodos();
        Task<Categoria> ObterPorId(Guid id);
        Task<IEnumerable<Categoria>> ObterPorCategoria(int codigo);

        void Adicionar(NovaCategoriaViewModel categoria);
        void Atualizar(CategoriaViewModel categoria);
        void Remover(CategoriaViewModel categoria);
    }
}
