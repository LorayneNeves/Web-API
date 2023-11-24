using AutoMapper;
using Domain.Entities;
using WebApplication1.Models;

namespace WebApplication1.Mapper
{
    public class ApplicationToDomain : Profile
    {
        public ApplicationToDomain() 
        {
            CreateMap<UsuarioViewModel, Usuario>()
                   .ConstructUsing(q => new Usuario(q.Id, q.UserName, q.Password, q.Ativo));
        
        }
        
    }
}
