using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using TP.Models;

namespace TP.Data
{
    public class ApplicationDbContext : IdentityDbContext<Utilizador>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Imovel> Imovel { get; set; }
        public DbSet<Gestor> Gestor { get; set; }
        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<Funcionario> Funcionario { get; set; }
    }
}
