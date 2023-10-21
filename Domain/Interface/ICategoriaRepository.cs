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
        IEnumerable<Categoria> ObterTodas();
        Task<Categoria> ObterPorId(Guid id);
        Task Adicionar(Categoria categoria);
        Task Desativar(Categoria categoria);
        void Atualizar(Categoria categoria);
    }
}
