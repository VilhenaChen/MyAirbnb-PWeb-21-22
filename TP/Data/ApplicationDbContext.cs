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
        public DbSet<Tipo_Imovel> Tipo_Imovel { get; set; }
        public DbSet<Avaliacao_Cliente> Avaliacao_Cliente { get; set; }
        public DbSet<Avaliacao_Imovel> Avaliacao_Imovel { get; set; }
        public DbSet<Checklist> Checklist { get; set; }
        public DbSet<Item_Checklist> Item_Checklist { get; set; }
        public DbSet<Reserva> Reserva { get; set; }
    }
}
