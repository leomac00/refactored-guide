using System.Linq;
using DesafioMVC.Data;
using DesafioMVC.DTO;
using DesafioMVC.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DesafioMVC.Controllers
{
  [Authorize]
  public class LotesVacinasController : Controller
  {
    private readonly ApplicationDBContext database;
    public LotesVacinasController(ApplicationDBContext db)
    {
      this.database = db;
    }
    [HttpPost]
    public IActionResult Registrar(LoteVacinaDTO loteDTO)
    {
      if (ModelState.IsValid)
      {
        var lote = new LoteVacina()
        {
          Vacina = database.Vacinas.Where(v => v.Status == true).First(v => v.Id == loteDTO.VacinaId),
          Lote = loteDTO.Lote,
          QtdRecebida = loteDTO.QtdRecebida,
          QtdRestante = loteDTO.QtdRecebida,
          DataRecebimento = loteDTO.DataRecebimento,
          DataValidade = loteDTO.DataValidade,
          Status = true
        };
        database.LotesVacinas.Add(lote);
        database.SaveChanges();
        return RedirectToAction("LotesVacinas", "Admin");
      }
      else
      {
        return View("/Home/Erro");

      }
    }
    [HttpPost]
    public IActionResult Editar(LoteVacinaDTO loteDTO)
    {
      if (ModelState.IsValid)
      {
        var lote = database.LotesVacinas.First(l => l.Id == loteDTO.Id);
        lote.Vacina = database.Vacinas.First(v => v.Id == loteDTO.VacinaId);
        lote.Lote = loteDTO.Lote;
        lote.QtdRecebida = loteDTO.QtdRecebida;
        lote.QtdRestante = loteDTO.QtdRestante;
        lote.DataRecebimento = loteDTO.DataRecebimento;
        lote.DataValidade = loteDTO.DataValidade;

        database.SaveChanges();
        return RedirectToAction("LotesVacinas", "Admin");
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
        var lote = database.LotesVacinas.First(l => l.Id == id);
        lote.Status = false;
        database.SaveChanges();
      }
      return RedirectToAction("LotesVacinas", "Admin");
    }
  }
}