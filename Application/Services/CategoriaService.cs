using Application.Interfaces;
using Application.ViewModels;
using AutoMapper;
using Domain;
using Domain.Entities;
using Domain.Interface;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class CategoriaService : ICategoriaService
    {
        #region - Construtores
        private readonly ICategoriaRepository _categoriaRepository;
        private IMapper _mapper;

        public CategoriaService(ICategoriaRepository categoriaRepository, IMapper mapper)
        {
            _categoriaRepository = categoriaRepository;
            _mapper = mapper;
        }
#endregion
#region - Funções
        public void Adicionar(NovaCategoriaViewModel novaCategoriaViewModel)
        {
            var novaCategoria = _mapper.Map<Categoria>(novaCategoriaViewModel);
            _categoriaRepository.Adicionar(novaCategoria);
        }

        public void Adicionar(Categoria categoria)
        {
            throw new NotImplementedException();
        }

        public void Atualizar(Categoria categoria)
        {
           
        }

        public void Atualizar(CategoriaViewModel categoria)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Categoria>> ObterPorCategoria(int codigo)
        {
            throw new NotImplementedException();
        }

        public Task<Categoria> ObterPorId(Guid id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CategoriaViewModel> ObterTodos()
        {
            return _mapper.Map<IEnumerable<CategoriaViewModel>>(_categoriaRepository.ObterTodos());
        }

        public void Remover(Categoria categoria)
        {
            throw new NotImplementedException();
        }

        public void Remover(CategoriaViewModel categoria)
        {
            throw new NotImplementedException();
        }

        IEnumerable<Categoria> ICategoriaService.ObterTodos()
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
