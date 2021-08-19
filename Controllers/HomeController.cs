using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using DesafioMVC.Models;
using DesafioMVC.Data;
using DesafioMVC.DTO;
using Microsoft.EntityFrameworkCore;

namespace DesafioMVC.Controllers
{
  public class HomeController : Controller
  {
    private readonly ApplicationDBContext database;
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger, ApplicationDBContext dbContext)
    {
      this.database = dbContext;
      _logger = logger;
    }

    public IActionResult Index()
    {
      return View();
    }
    public IActionResult Privacy()
    {
      return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
      return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
    public IActionResult LocaisVacinacao()
    {
      var lista = database.LocaisVacinacoes.Include(l => l.Endereco).Where(e => e.Status == true).ToList();
      return View(lista);
    }
    public IActionResult Vacinas()
    {
      var lista = database.Vacinas.Where(e => e.Status == true).ToList();
      return View(lista);
    }
    public IActionResult Lotes()
    {
      AtualizarLotes();
      var lista = database.LotesVacinas.Include(l => l.Vacina).ToList();
      return View(lista);
    }
    public IActionResult Erro()
    {
      return View();
    }
    //Funções auxiliares
    public void AtualizarLotes()
    {
      var Hoje = DateTime.Now.Date;
      var lista = database.LotesVacinas.Include(l => l.Vacina).Where(e => e.Status == true).ToList();
      //Checa se lotes a serem listados tem validade anterior ao dia de hoje
      foreach (var lote in lista)
      {
        if (lote.DataValidade < Hoje)
        {
          lote.Status = false;
          database.SaveChanges();
        }
      }
    }
  }
}
