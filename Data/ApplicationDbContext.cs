using System;
using System.Collections.Generic;
using System.Text;
using DesafioMVC.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;


namespace DesafioMVC.Data
{
  public class ApplicationDBContext : IdentityDbContext
  {

    public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options)
        : base(options)
    {
    }


    public DbSet<Endereco> Enderecos { get; set; }
    public DbSet<LocalVacinacao> LocaisVacinacoes { get; set; }
    public DbSet<LoteVacina> LotesVacinas { get; set; }
    public DbSet<Pessoa> Pessoas { get; set; }
    public DbSet<Vacina> Vacinas { get; set; }
    public DbSet<Vacinacao> Vacinacoes { get; set; }

  }
}
