using System.Linq;
using DesafioMVC.Data;
using DesafioMVC.DTO;
using DesafioMVC.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DesafioMVC.Controllers
{
  [Authorize]
  public class VacinasController : Controller
  {
    private readonly ApplicationDBContext database;
    public VacinasController(ApplicationDBContext db)
    {
      this.database = db;
    }
    [HttpPost]
    public IActionResult Registrar(VacinaDTO vacDTO)
    {
      if (ModelState.IsValid)
      {
        var vac = new Vacina()
        {
          Nome = vacDTO.Nome,
          Laboratorio = vacDTO.Laboratorio,
          Posologia = vacDTO.Posologia,
          Intervalo = vacDTO.Posologia ? vacDTO.Intervalo : 0,
          Status = true
        };
        database.Vacinas.Add(vac);
        database.SaveChanges();
        return RedirectToAction("Vacinas", "Admin");
      }
      else
      {
        return RedirectToAction("Erro", "Home");
      }
    }
    [HttpPost]
    public IActionResult Editar(VacinaDTO vacDTO)
    {
      if (ModelState.IsValid)
      {
        var vac = database.Vacinas.First(v => v.Id == vacDTO.Id);
        vac.Nome = vacDTO.Nome;
        vac.Laboratorio = vacDTO.Laboratorio;
        vac.Posologia = vacDTO.Posologia;
        vac.Intervalo = vacDTO.Intervalo;

        database.SaveChanges();
        return RedirectToAction("Vacinas", "Admin");
      }
      else
      {
        return RedirectToAction("Erro", "Home");
      }
    }
    [HttpPost]
    public ActionResult Deletar(int id)
    {
      if (id > 0)
      {
        var vac = database.Vacinas.First(v => v.Id == id);
        vac.Status = false;
        database.SaveChanges();
      }
      return RedirectToAction("Vacinas", "Admin");
    }
  }
}