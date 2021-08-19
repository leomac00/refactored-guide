using System.Linq;
using DesafioMVC.Data;
using DesafioMVC.DTO;
using DesafioMVC.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DesafioMVC.Controllers
{
  [Authorize]
  public class LocaisVacinacaoController : Controller
  {
    private readonly ApplicationDBContext database;
    public LocaisVacinacaoController(ApplicationDBContext db)
    {
      this.database = db;
    }
    [HttpPost]
    public IActionResult Registrar(LocalVacinacaoDTO localDTO)
    {
      if (ModelState.IsValid)
      {
        LocalVacinacao end = new LocalVacinacao
        {
          Nome = localDTO.Nome,
          Endereco = database.Enderecos.First(l => l.Id == localDTO.LocalId),
          Status = true
        };
        database.LocaisVacinacoes.Add(end);
        database.SaveChanges();
        return RedirectToAction("LocaisVacinacao", "Admin");
      }
      else
      {
        return RedirectToAction("Erro", "Home");
      }

    }
    [HttpPost]
    public IActionResult Editar(LocalVacinacaoDTO localDTO)
    {
      if (ModelState.IsValid)
      {
        var local = database.LocaisVacinacoes.Include(l => l.Endereco).First(l => l.Id == localDTO.LocalId);
        local.Nome = localDTO.Nome;
        local.Endereco = database.Enderecos.First(l => l.Id == localDTO.LocalId);



        database.SaveChanges();
        return RedirectToAction("LocaisVacinacao", "Admin");
      }
      else
      {
        return RedirectToAction("Erro", "Home");
      }
    }
    [HttpPost]
    public IActionResult Deletar(int id)
    {
      if (id > 0)
      {
        var local = database.LocaisVacinacoes.First(l => l.Id == id);
        local.Status = false;
        database.SaveChanges();
      }
      return RedirectToAction("LocaisVacinacao", "Admin");
    }
  }
}
