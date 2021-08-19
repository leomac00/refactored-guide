using System.Collections.Generic;
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
  public class VacinacoesController : Controller
  {
    private readonly ApplicationDBContext database;
    public VacinacoesController(ApplicationDBContext dbContext)
    {
      this.database = dbContext;
    }
    [HttpPost]
    public IActionResult Registrar(VacinacaoDTO vacDTO)
    {
      if (ModelState.IsValid)
      {
        //Variaveis auxiliares
        var vacinacoes = database.Vacinacoes.Include(p => p.Pessoa).ToList();
        var pessoasVacinadas = new List<Pessoa>();
        var loteComVacina = database.LotesVacinas.Include(l => l.Vacina).First(l => l.Id == vacDTO.LoteId);
        foreach (var vacinacao in vacinacoes)
        {
          pessoasVacinadas.Add(vacinacao.Pessoa);
        }
        //Criacao do objeto de Vacinacao
        var vac = new Vacinacao()
        {
          Pessoa = database.Pessoas.First(p => p.Id == vacDTO.PessoaId),
          Data = vacDTO.Data,
          Lote = database.LotesVacinas.First(l => l.Id == vacDTO.LoteId),
          Local = database.LocaisVacinacoes.First(l => l.Id == vacDTO.LocalId),
        };
        if (loteComVacina.Vacina.Posologia)
        {
          vac.Dose = pessoasVacinadas.Contains(vac.Pessoa) ? true : false;
        }
        else
        {
          vac.Dose = true;
        }
        vac.Status = true; //false = já tomou vacina ou foi deletado; true = ainda está elegivel para tomar vacina
        //Inserção do objeto criado no DB
        loteComVacina.QtdRestante--;
        database.Vacinacoes.Add(vac);
        database.SaveChanges();
        return RedirectToAction("Vacinacoes", "Admin");
      }
      else
      {
        return RedirectToAction("LotesVacinas", "Admin");
      }
    }
    [HttpPost]
    public IActionResult Editar(VacinacaoDTO vacDTO)
    {
      if (ModelState.IsValid)
      {
        var loteComVacina = database.LotesVacinas.Include(l => l.Vacina).First(l => l.Id == vacDTO.LoteId);
        var vac = database.Vacinacoes.First(v => v.Id == vacDTO.Id);
        vac.Pessoa = database.Pessoas.First(p => p.Id == vacDTO.PessoaId);
        vac.Data = vacDTO.Data;
        vac.Lote = database.LotesVacinas.First(l => l.Id == vacDTO.LoteId);
        vac.Local = database.LocaisVacinacoes.First(l => l.Id == vacDTO.LocalId);
        vac.Dose = vacDTO.Dose;
        loteComVacina.QtdRestante--;

        database.SaveChanges();
        return RedirectToAction("Vacinacoes", "Admin");
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
        var vac = database.Vacinacoes.First(v => v.Id == id);
        vac.Status = false;
        database.SaveChanges();
      }
      return RedirectToAction("Vacinacoes", "Admin");
    }
  }
}