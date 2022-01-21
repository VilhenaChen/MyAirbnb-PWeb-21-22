﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TP.Data;

namespace TP.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.13")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("TP.Models.Avaliacao_Cliente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Avaliacao")
                        .HasColumnType("int");

                    b.Property<int>("ClienteId")
                        .HasColumnType("int");

                    b.Property<string>("Comentarios")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("GestorId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ClienteId");

                    b.HasIndex("GestorId");

                    b.ToTable("Avaliacao_Cliente");
                });

            modelBuilder.Entity("TP.Models.Avaliacao_Imovel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Avaliacao")
                        .HasColumnType("int");

                    b.Property<int>("ClienteId")
                        .HasColumnType("int");

                    b.Property<string>("Comentarios")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ReservaId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ClienteId");

                    b.HasIndex("ReservaId");

                    b.ToTable("Avaliacao_Imovel");
                });

            modelBuilder.Entity("TP.Models.Checklist", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Completa")
                        .HasColumnType("bit");

                    b.Property<int?>("ImovelId")
                        .HasColumnType("int");

                    b.Property<string>("Momento")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ReservaId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ImovelId");

                    b.HasIndex("ReservaId");

                    b.ToTable("Checklist");
                });

            modelBuilder.Entity("TP.Models.Cliente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("UtilizadorId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UtilizadorId");

                    b.ToTable("Cliente");
                });

            modelBuilder.Entity("TP.Models.Funcionario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("GestorId")
                        .HasColumnType("int");

                    b.Property<string>("UtilizadorId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("GestorId");

                    b.HasIndex("UtilizadorId");

                    b.ToTable("Funcionario");
                });

            modelBuilder.Entity("TP.Models.Gestor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("UtilizadorId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UtilizadorId");

                    b.ToTable("Gestor");
                });

            modelBuilder.Entity("TP.Models.Imovel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Codigo_Postal")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Distrito")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Extras")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("GestorId")
                        .HasColumnType("int");

                    b.Property<string>("Localidade")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Morada")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Pais")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Preco")
                        .HasColumnType("float");

                    b.Property<int>("Tipo_ImovelId")
                        .HasColumnType("int");

                    b.Property<string>("Tipologia")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("GestorId");

                    b.HasIndex("Tipo_ImovelId");

                    b.ToTable("Imovel");
                });

            modelBuilder.Entity("TP.Models.Item_Checklist", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ChecklistId")
                        .HasColumnType("int");

                    b.Property<string>("Descricao")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Validada")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("ChecklistId");

                    b.ToTable("Item_Checklist");
                });

            modelBuilder.Entity("TP.Models.Reserva", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Check_In")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Check_Out")
                        .HasColumnType("datetime2");

                    b.Property<int>("ClienteId")
                        .HasColumnType("int");

                    b.Property<string>("Comentarios_Check_Out")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Confirmacao")
                        .HasColumnType("bit");

                    b.Property<string>("Estado")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("FuncionarioId")
                        .HasColumnType("int");

                    b.Property<int>("ImovelId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ClienteId");

                    b.HasIndex("FuncionarioId");

                    b.HasIndex("ImovelId");

                    b.ToTable("Reserva");
                });

            modelBuilder.Entity("TP.Models.Tipo_Imovel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Tipo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Tipo_Imovel");
                });

            modelBuilder.Entity("TP.Models.Utilizador", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Data_Nascimento")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("TP.Models.Utilizador", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("TP.Models.Utilizador", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TP.Models.Utilizador", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("TP.Models.Utilizador", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TP.Models.Avaliacao_Cliente", b =>
                {
                    b.HasOne("TP.Models.Cliente", "Cliente")
                        .WithMany("Minhas_Avaliacoes")
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TP.Models.Gestor", "Gestor")
                        .WithMany("Avaliacoes_Clientes")
                        .HasForeignKey("GestorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cliente");

                    b.Navigation("Gestor");
                });

            modelBuilder.Entity("TP.Models.Avaliacao_Imovel", b =>
                {
                    b.HasOne("TP.Models.Cliente", "Cliente")
                        .WithMany("Avaliacoes_Imoveis")
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TP.Models.Reserva", "Reserva")
                        .WithMany("Avaliacao_Imovel")
                        .HasForeignKey("ReservaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cliente");

                    b.Navigation("Reserva");
                });

            modelBuilder.Entity("TP.Models.Checklist", b =>
                {
                    b.HasOne("TP.Models.Imovel", null)
                        .WithMany("Verificacoes")
                        .HasForeignKey("ImovelId");

                    b.HasOne("TP.Models.Reserva", null)
                        .WithMany("Verificacoes")
                        .HasForeignKey("ReservaId");
                });

            modelBuilder.Entity("TP.Models.Cliente", b =>
                {
                    b.HasOne("TP.Models.Utilizador", "Utilizador")
                        .WithMany("Cliente")
                        .HasForeignKey("UtilizadorId");

                    b.Navigation("Utilizador");
                });

            modelBuilder.Entity("TP.Models.Funcionario", b =>
                {
                    b.HasOne("TP.Models.Gestor", "Gestor")
                        .WithMany("Funcionarios")
                        .HasForeignKey("GestorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TP.Models.Utilizador", "Utilizador")
                        .WithMany("Funcionario")
                        .HasForeignKey("UtilizadorId");

                    b.Navigation("Gestor");

                    b.Navigation("Utilizador");
                });

            modelBuilder.Entity("TP.Models.Gestor", b =>
                {
                    b.HasOne("TP.Models.Utilizador", "Utilizador")
                        .WithMany("Gestor")
                        .HasForeignKey("UtilizadorId");

                    b.Navigation("Utilizador");
                });

            modelBuilder.Entity("TP.Models.Imovel", b =>
                {
                    b.HasOne("TP.Models.Gestor", "Gestor")
                        .WithMany("Imoveis")
                        .HasForeignKey("GestorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TP.Models.Tipo_Imovel", "Tipo_Imovel")
                        .WithMany("Imovel")
                        .HasForeignKey("Tipo_ImovelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Gestor");

                    b.Navigation("Tipo_Imovel");
                });

            modelBuilder.Entity("TP.Models.Item_Checklist", b =>
                {
                    b.HasOne("TP.Models.Checklist", "Checklist")
                        .WithMany("Items")
                        .HasForeignKey("ChecklistId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Checklist");
                });

            modelBuilder.Entity("TP.Models.Reserva", b =>
                {
                    b.HasOne("TP.Models.Cliente", "Cliente")
                        .WithMany("Reservas")
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TP.Models.Funcionario", "Funcionario")
                        .WithMany("Reservas")
                        .HasForeignKey("FuncionarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TP.Models.Imovel", "Imovel")
                        .WithMany("Reservas")
                        .HasForeignKey("ImovelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cliente");

                    b.Navigation("Funcionario");

                    b.Navigation("Imovel");
                });

            modelBuilder.Entity("TP.Models.Checklist", b =>
                {
                    b.Navigation("Items");
                });

            modelBuilder.Entity("TP.Models.Cliente", b =>
                {
                    b.Navigation("Avaliacoes_Imoveis");

                    b.Navigation("Minhas_Avaliacoes");

                    b.Navigation("Reservas");
                });

            modelBuilder.Entity("TP.Models.Funcionario", b =>
                {
                    b.Navigation("Reservas");
                });

            modelBuilder.Entity("TP.Models.Gestor", b =>
                {
                    b.Navigation("Avaliacoes_Clientes");

                    b.Navigation("Funcionarios");

                    b.Navigation("Imoveis");
                });

            modelBuilder.Entity("TP.Models.Imovel", b =>
                {
                    b.Navigation("Reservas");

                    b.Navigation("Verificacoes");
                });

            modelBuilder.Entity("TP.Models.Reserva", b =>
                {
                    b.Navigation("Avaliacao_Imovel");

                    b.Navigation("Verificacoes");
                });

            modelBuilder.Entity("TP.Models.Tipo_Imovel", b =>
                {
                    b.Navigation("Imovel");
                });

            modelBuilder.Entity("TP.Models.Utilizador", b =>
                {
                    b.Navigation("Cliente");

                    b.Navigation("Funcionario");

                    b.Navigation("Gestor");
                });
#pragma warning restore 612, 618
        }
    }
}
