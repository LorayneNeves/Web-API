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
        IEnumerable<CategoriaViewModel> ObterTodas();
        Task<CategoriaViewModel> ObterPorId(Guid id);

        Task Adicionar(NovaCategoriaViewModel categoriaViewModel);
        void Atualizar(NovaCategoriaViewModel categoriaViewModel);

    }
}
