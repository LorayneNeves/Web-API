using Data.Mappings;
using Domain;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class GestaoProdutoContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public GestaoProdutoContext(DbContextOptions<GestaoProdutoContext> options) : base(options) { }

        public Microsoft.EntityFrameworkCore.DbSet<Produto> Produtos { get; set; }
        public Microsoft.EntityFrameworkCore.DbSet<Usuario> Usuarios { get; set; }       

    }
}
