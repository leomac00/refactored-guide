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
  public class EnderecosController : Controller
  {
    private readonly ApplicationDBContext database;
    public EnderecosController(ApplicationDBContext db)
    {
      this.database = db;
    }
    [HttpPost]
    public IActionResult Registrar(EnderecoDTO endDTO)
    {
      if (ModelState.IsValid)
      {
        Endereco end = new Endereco
        {
          Cep = endDTO.Cep,
          Logradouro = endDTO.Logradouro,
          Numero = endDTO.Numero,
          Complemento = endDTO.Complemento,
          Cidade = endDTO.Cidade,
          Estado = endDTO.Estado,
          Status = true
        };
        database.Enderecos.Add(end);
        database.SaveChanges();
        return RedirectToAction("Enderecos", "Admin");
      }
      else
      {
        return RedirectToAction("Erro", "Home");
      }
    }
    [HttpPost]
    public IActionResult Editar(EnderecoDTO endDTO)
    {
      if (ModelState.IsValid)
      {
        var end = database.Enderecos.First(e => e.Id == endDTO.Id);
        end.Cep = endDTO.Cep;
        end.Logradouro = endDTO.Logradouro;
        end.Numero = endDTO.Numero;
        end.Complemento = endDTO.Complemento;
        end.Cidade = endDTO.Cidade;
        end.Estado = endDTO.Estado;

        database.SaveChanges();
        return RedirectToAction("Enderecos", "Admin");
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
        var end = database.Enderecos.First(e => e.Id == id);
        end.Status = false;
        database.SaveChanges();
      }
      return RedirectToAction("Enderecos", "Admin");
    }
  }
}