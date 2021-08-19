using System;
using System.Linq;
using DesafioMVC.Data;
using DesafioMVC.DTO;
using DesafioMVC.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DesafioMVC.Controllers
{
  [Authorize]
  public class PessoasController : Controller
  {
    private readonly ApplicationDBContext database;
    public PessoasController(ApplicationDBContext db) => this.database = db;
    [HttpPost]
    public IActionResult Registrar(PessoaDTO pDTO)
    {
      if (ModelState.IsValid && pDTO.Nascimento <= DateTime.Now.AddHours(6))
      {
        Pessoa p = new Pessoa
        {
          Nome = pDTO.Nome,
          Cpf = pDTO.Cpf,
          Nascimento = pDTO.Nascimento,
          Endereco = database.Enderecos.First(p => p.Id == pDTO.EnderecoId),
          Status = true
        };
        database.Pessoas.Add(p);
        database.SaveChanges();
        return RedirectToAction("Pessoas", "Admin");
      }
      else
      {
        return RedirectToAction("Erro", "Home");
      }

    }
    [HttpPost]
    public IActionResult Editar(PessoaDTO pDTO)
    {
      if (ModelState.IsValid && pDTO.Nascimento <= DateTime.Now.AddHours(6))
      {
        var p = database.Pessoas.First(p => p.Id == pDTO.Id);
        p.Nome = pDTO.Nome;
        p.Cpf = pDTO.Cpf;
        p.Nascimento = pDTO.Nascimento;
        p.Endereco = database.Enderecos.First(e => e.Id == pDTO.EnderecoId);
        database.SaveChanges();
        return RedirectToAction("Pessoas", "Admin");
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
        var p = database.Pessoas.First(p => p.Id == id);
        p.Status = false;
        database.SaveChanges();
      }
      return RedirectToAction("Pessoas", "Admin");
    }
  }
}