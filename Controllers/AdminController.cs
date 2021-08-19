using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using DesafioMVC.Models;
using DesafioMVC.Data;
using DesafioMVC.DTO;
using System.Linq;
using System;


namespace DesafioMVC.Controllers
{
  [Authorize]
  public class AdminController : Controller
  {
    private readonly ApplicationDBContext database;
    List<Pessoa> _pessoasVacinaveis = new List<Pessoa>();
    public AdminController(ApplicationDBContext dbContext)
    {
      this.database = dbContext;
    }
    public IActionResult Index()
    {
      return View();
    }
    public IActionResult Enderecos()
    {
      var lista = database.Enderecos.Where(e => e.Status == true).ToList();
      return View(lista);
    }
    public IActionResult RegistrarEndereco()
    {
      ViewBag.Estados = Ufs.ToList();
      return View();
    }
    public IActionResult EditarEndereco(int id)
    {
      var end = database.Enderecos.First(e => e.Id == id);
      if (end.Status)
      {
        EnderecoDTO endDTO = new EnderecoDTO()
        {
          Cep = end.Cep,
          Logradouro = end.Logradouro,
          Numero = end.Numero,
          Complemento = end.Complemento,
          Cidade = end.Cidade,
          Estado = end.Estado,
        };
        ViewBag.Estados = Ufs.ToList();
        return View(endDTO);
      }
      else
      {
        return RedirectToAction("Enderecos", "Home");
      }
    }
    public IActionResult LocaisVacinacao()
    {
      var lista = database.LocaisVacinacoes.Include(l => l.Endereco).Where(e => e.Status == true).ToList();
      return View(lista);
    }
    public IActionResult RegistrarLocal()
    {
      ViewBag.Enderecos = database.Enderecos.Where(e => e.Status == true).ToList();
      return View();
    }
    public IActionResult EditarLocal(int id)
    {
      var local = database.LocaisVacinacoes.Include(l => l.Endereco).First(e => e.Id == id);
      if (local.Status)
      {
        LocalVacinacaoDTO localDTO = new LocalVacinacaoDTO()
        {
          Nome = local.Nome,
          LocalId = local.Endereco.Id
        };
        ViewBag.Enderecos = database.Enderecos.Where(e => e.Status == true).ToList();
        return View(localDTO);
      }
      else
      {
        return RedirectToAction("LocaisVacinacao", "Home");
      }
    }
    public IActionResult Vacinas()
    {
      var lista = database.Vacinas.Where(e => e.Status == true).ToList();
      return View(lista);
    }
    public IActionResult RegistrarVacina()
    {
      return View();
    }
    public IActionResult EditarVacina(int id)
    {
      var vac = database.Vacinas.First(v => v.Id == id);
      if (vac.Status)
      {
        VacinaDTO vacDTO = new VacinaDTO()
        {
          Nome = vac.Nome,
          Laboratorio = vac.Laboratorio,
          Posologia = vac.Posologia,
          Intervalo = vac.Intervalo,
        };
        return View(vacDTO);
      }
      else
      {
        return RedirectToAction("LocaisVacinacao", "Home");
      }
    }
    public IActionResult LotesVacinas()
    {
      AtualizarLotes();
      var lista = database.LotesVacinas.Include(l => l.Vacina).ToList();
      return View(lista);
    }
    public IActionResult RegistrarLote()
    {
      ViewBag.Vacinas = database.Vacinas.Where(e => e.Status == true).ToList();
      return View();
    }
    public IActionResult EditarLote(int id)
    {
      AtualizarLotes();
      var lote = database.LotesVacinas.Include(l => l.Vacina).First(l => l.Id == id);
      if (lote.Status)
      {
        LoteVacinaDTO loteDTO = new LoteVacinaDTO();

        loteDTO.VacinaId = lote.Vacina.Id;
        loteDTO.Lote = lote.Lote;
        loteDTO.QtdRecebida = lote.QtdRecebida;
        loteDTO.QtdRestante = lote.QtdRestante;
        loteDTO.DataRecebimento = lote.DataRecebimento;
        loteDTO.DataValidade = lote.DataValidade;

        ViewBag.Vacinas = database.Vacinas.Where(e => e.Status == true).ToList();
        return View(loteDTO);
      }
      else
      {
        return RedirectToAction("LotesVacinas", "Home");
      }
    }
    public IActionResult Pessoas()
    {
      var lista = database.Pessoas.Include(p => p.Endereco).Where(p => p.Status == true).ToList();
      return View(lista);
    }
    public IActionResult RegistrarPessoa()
    {
      ViewBag.Enderecos = database.Enderecos.Where(e => e.Status == true).ToList();

      return View();
    }
    public IActionResult EditarPessoa(int id)
    {
      var p = database.Pessoas.Include(p => p.Endereco).First(p => p.Id == id);
      if (p.Status)
      {
        ViewBag.Enderecos = database.Enderecos.Where(e => e.Status == true).ToList();
        PessoaDTO pDTO = new PessoaDTO()
        {
          Nome = p.Nome,
          Cpf = p.Cpf,
          Nascimento = p.Nascimento,
          EnderecoId = p.Endereco.Id
        };
        return View(pDTO);
      }
      else
      {
        return RedirectToAction("LotesVacinas", "Home");

      }

    }
    public IActionResult SelecionarVacina()
    {
      AtualizarLotes();
      var Hoje = DateTime.Now.Date;
      ViewBag.Lotes = database.LotesVacinas.Where(l => l.Status == true && l.DataValidade >= Hoje && l.QtdRestante > 0);
      return View();
    }
    [HttpPost]
    public IActionResult VacinarPessoa(SelecaoVacinaDTO loteDTO)
    {
      AtualizarPessoasVacinaveis(loteDTO);
      ViewBag.Pessoas = _pessoasVacinaveis;
      ViewBag.Locais = database.LocaisVacinacoes.Where(e => e.Status == true).ToList();
      ViewBag.LoteId = database.LotesVacinas.Include(l => l.Vacina).First(l => l.Id == loteDTO.LoteId).Id;
      return View();
    }
    public IActionResult Relatorios()
    {
      return View();
    }
    public IActionResult RelatorioSegundaDose()
    {
      var lista = database.Vacinacoes.Include(v => v.Lote).Include(v => v.Lote.Vacina).Include(v => v.Local).Include(v => v.Pessoa).Where(v => v.Status == true && v.Pessoa.Status == true && v.Lote.Vacina.Posologia == true).ToList();
      List<Vacinacao> listaRepetidos = new List<Vacinacao>();
      foreach (var vac in lista)
      {
        var i = 0;
        foreach (var vaci in lista)
        {
          if (vac.Pessoa == vaci.Pessoa) i++;
        }
        if (i >= 2) listaRepetidos.Add(vac);
      }
      foreach (var vac in listaRepetidos)
      {
        lista.Remove(vac);
      }
      return View(lista);
    }
    public IActionResult Vacinacoes()
    {
      var lista = database.Vacinacoes.Include(v => v.Lote).Include(v => v.Lote.Vacina).Include(v => v.Local).Include(v => v.Pessoa).Where(v => v.Status == true).ToList();
      return View(lista);
    }
    public IActionResult EditarVacinacao(int id)
    {
      var vacinacao = database.Vacinacoes.Include(v => v.Pessoa).Include(v => v.Lote).Include(v => v.Local).First(v => v.Id == id);
      var loteAtual = database.LotesVacinas.Include(l => l.Vacina).First(v => vacinacao.Lote.Id == v.Id);
      var PosologiaAtual = loteAtual.Vacina.Posologia;

      var vacinacaoDTO = new VacinacaoDTO()
      {
        PessoaId = vacinacao.Pessoa.Id,
        Data = vacinacao.Data,
        LoteId = vacinacao.Lote.Id,
        LocalId = vacinacao.Local.Id,
        Dose = vacinacao.Dose
      };
      vacinacao.Lote.QtdRestante++;
      SelecaoVacinaDTO loteDTO = new SelecaoVacinaDTO()
      {
        LoteId = vacinacao.Lote.Id
      };
      AtualizarPessoasVacinaveis(loteDTO);
      ViewBag.Pessoas = _pessoasVacinaveis;
      ViewBag.Lotes = database.LotesVacinas.Where(l => l.Status == true).Where(l => l.QtdRestante > 0).Include(l => l.Vacina).Where(l => l.Vacina.Posologia == PosologiaAtual).ToList();
      ViewBag.Locais = database.LocaisVacinacoes.Where(e => e.Status == true).ToList();
      return View(vacinacaoDTO);
    }
    public IActionResult LotesVencimento()
    {
      AtualizarLotes();
      var hoje = DateTime.Now.Date;
      var hojeMaisTrinta = hoje.AddDays(30);
      var lista = database.LotesVacinas.Include(l => l.Vacina).Where(e => e.Status == true && e.DataValidade <= hojeMaisTrinta).ToList();
      ViewBag.hojeMaisTrinta = hojeMaisTrinta.ToString("dd/MM/yyyy");
      return View(lista);
    }
    public IActionResult PopularDBWarning()
    {
      return View();
    }
    [HttpPost]
    public IActionResult PopularDb([FromBody] AcessoDTO dados)
    {
      //Variaveis auxiliares
      var locaisDb = database.LocaisVacinacoes.ToList();
      var vacinacoesDb = database.Vacinacoes.ToList();
      var enderecosDb = database.Enderecos.ToList();
      var lotesDb = database.LotesVacinas.ToList();
      var vacinasDb = database.Vacinas.ToList();
      var pessoasDb = database.Pessoas.ToList();
      var tabelasPopuladas = "";
      var hoje = DateTime.Now;
      var qtdPopuladas = 0;

      //---------- Excução ----------
      AtualizarLotes();

      //Popular Vacinas
      if (!vacinasDb.Any(v => v.Nome == "DoseDuplaVac"))
      {
        var vacina1 = new Vacina()
        {
          Nome = "DoseDuplaVac",
          Laboratorio = "Laboratorios DoseDupla",
          Posologia = true,
          Intervalo = 90,
          Status = true
        };
        var vacina2 = new Vacina()
        {
          Nome = "DoseUnicaVac",
          Laboratorio = "Laboratorios DoseUnica",
          Posologia = false,
          Intervalo = 0,
          Status = true
        };
        var vacina3 = new Vacina()
        {
          Nome = "BrazilVac",
          Laboratorio = "Laboratorios do Brasil",
          Posologia = true,
          Intervalo = 70,
          Status = true
        };

        database.Vacinas.Add(vacina1);
        database.Vacinas.Add(vacina2);
        database.Vacinas.Add(vacina3);
        database.SaveChanges();

        tabelasPopuladas += " Vacinas;";
        qtdPopuladas++;
      }

      //Popular Lotes de vacinas
      if (!lotesDb.Any(l => l.Lote == "ghi789"))
      {
        var lote1 = new LoteVacina()
        {
          Vacina = database.Vacinas.First(l => l.Nome == "DoseDuplaVac"),
          Lote = "abc123",
          QtdRecebida = 100,
          QtdRestante = 99,
          DataRecebimento = hoje,
          DataValidade = hoje.AddDays(30),
          Status = true
        };
        var lote2 = new LoteVacina()
        {
          Vacina = database.Vacinas.First(l => l.Nome == "DoseUnicaVac"),
          Lote = "def456",
          QtdRecebida = 150,
          QtdRestante = 149,
          DataRecebimento = hoje,
          DataValidade = hoje.AddDays(45),
          Status = true
        };
        var lote3 = new LoteVacina()
        {
          Vacina = database.Vacinas.First(l => l.Nome == "BrazilVac"),
          Lote = "ghi789",
          QtdRecebida = 200,
          QtdRestante = 199,
          DataRecebimento = hoje,
          DataValidade = hoje.AddDays(60),
          Status = true
        };


        database.LotesVacinas.Add(lote1);
        database.LotesVacinas.Add(lote2);
        database.LotesVacinas.Add(lote3);
        database.SaveChanges();
        tabelasPopuladas += " Lotes de vacinas;";
        qtdPopuladas++;
      }

      //Popular Enderecos
      if (!enderecosDb.Any(e => e.Cep == "12070360"))
      {
        var endereco1 = new Endereco()
        {
          Cep = "12031030",
          Logradouro = "Rua Dolores Barreto Coelho",
          Numero = "143",
          Complemento = "Casa",
          Cidade = "Taubaté",
          Estado = "SP",
          Status = true
        };
        var endereco2 = new Endereco()
        {
          Cep = "12070360",
          Logradouro = " Praça da Inconfidência",
          Numero = "67",
          Complemento = "",
          Cidade = "Taubaté",
          Estado = "SP",
          Status = true
        };
        var endereco3 = new Endereco()
        {
          Cep = "12050500",
          Logradouro = "Rua Praça Antonio Lucci",
          Numero = "60",
          Complemento = "",
          Cidade = "Taubaté",
          Estado = "SP",
          Status = true
        };
        var endereco4 = new Endereco()
        {
          Cep = "12070620",
          Logradouro = "Rua Ana Vieira de Almeida",
          Numero = "128",
          Complemento = "",
          Cidade = "Taubaté",
          Estado = "SP",
          Status = true
        };

        database.Enderecos.Add(endereco1);
        database.Enderecos.Add(endereco2);
        database.Enderecos.Add(endereco3);
        database.Enderecos.Add(endereco4);
        database.SaveChanges();
        tabelasPopuladas += " Enderecos;";
        qtdPopuladas++;

      }

      //Popular Locais de vacincação
      if (!locaisDb.Any(l => l.Nome == "PAMO Estiva"))
      {
        var localVacinacao1 = new LocalVacinacao()
        {
          Nome = "Casa",
          Endereco = database.Enderecos.First(l => l.Cep == "12031030"),
          Status = true
        };
        var localVacinacao2 = new LocalVacinacao()
        {
          Nome = "PAMO Vila São José",
          Endereco = database.Enderecos.First(l => l.Cep == "12050500"),
          Status = true
        };
        var localVacinacao3 = new LocalVacinacao()
        {
          Nome = "PAMO Estiva",
          Endereco = database.Enderecos.First(l => l.Cep == "12070360"),
          Status = true
        };

        database.LocaisVacinacoes.Add(localVacinacao1);
        database.LocaisVacinacoes.Add(localVacinacao2);
        database.LocaisVacinacoes.Add(localVacinacao3);
        database.SaveChanges();
        tabelasPopuladas += " Locais de Vacinação;";
        qtdPopuladas++;
      }

      //Popular Pessoas
      if (!pessoasDb.Any(p => p.Nome == "Astrogildo Joelson"))
      {
        var pessoa1 = new Pessoa()
        {
          Cpf = "22227777777",
          Nome = "Joao Bezerra",
          Nascimento = hoje.AddYears(-20),
          Endereco = database.Enderecos.First(l => l.Cep == "12031030"),
          Status = true
        };
        var pessoa2 = new Pessoa()
        {
          Cpf = "87878787878",
          Nome = "Astrogildo Joelson",
          Nascimento = hoje.AddYears(-25),
          Endereco = database.Enderecos.First(l => l.Cep == "12031030"),
          Status = true
        };
        var pessoa3 = new Pessoa()
        {
          Cpf = "12312312312",
          Nome = "Euzebio Maria",
          Nascimento = hoje.AddYears(-30),
          Endereco = database.Enderecos.First(l => l.Cep == "12070620"),
          Status = true
        };

        database.Pessoas.Add(pessoa1);
        database.Pessoas.Add(pessoa2);
        database.Pessoas.Add(pessoa3);
        database.SaveChanges();
        tabelasPopuladas += " Pessoas;";
        qtdPopuladas++;
      }

      //Popular Vacinações
      if (!vacinacoesDb.Any(v => v.Lote == database.LotesVacinas.First(l => l.Lote == "abc123")))
      {
        var vacinacao1 = new Vacinacao()
        {
          Pessoa = database.Pessoas.First(p => p.Nome == "Joao Bezerra"),
          Data = hoje,
          Lote = database.LotesVacinas.First(l => l.Lote == "abc123"),
          Local = database.LocaisVacinacoes.First(l => l.Nome == "PAMO Vila São José"),
          Dose = false,
          Status = true
        };
        var vacinacao2 = new Vacinacao()
        {
          Pessoa = database.Pessoas.First(p => p.Nome == "Astrogildo Joelson"),
          Data = hoje,
          Lote = database.LotesVacinas.First(l => l.Lote == "def456"),
          Local = database.LocaisVacinacoes.First(l => l.Nome == "PAMO Vila São José"),
          Dose = true,
          Status = true
        };
        var vacinacao3 = new Vacinacao()
        {
          Pessoa = database.Pessoas.First(p => p.Nome == "Euzebio Maria"),
          Data = hoje,
          Lote = database.LotesVacinas.First(l => l.Lote == "ghi789"),
          Local = database.LocaisVacinacoes.First(l => l.Nome == "PAMO Estiva"),
          Dose = false,
          Status = true
        };


        database.Vacinacoes.Add(vacinacao1);
        database.Vacinacoes.Add(vacinacao2);
        database.Vacinacoes.Add(vacinacao3);
        database.SaveChanges();
        tabelasPopuladas += " Vacinações;";
        qtdPopuladas++;
      }

      tabelasPopuladas.TrimStart();
      tabelasPopuladas = tabelasPopuladas == "" ? "Banco de dados já populado" : tabelasPopuladas;
      return Ok(new { qtd = qtdPopuladas, msg = tabelasPopuladas });
    }






    //Auxiliares
    public void AtualizarPessoasVacinaveis(SelecaoVacinaDTO loteDTO)
    {
      //Variaveis auxiliares
      var loteAtual = database.LotesVacinas.Include(l => l.Vacina).First(l => l.Id == loteDTO.LoteId);
      var tipoDose = loteAtual.Vacina.Posologia;
      var pessoas = database.Pessoas.Where(p => p.Status == true).ToList();
      var vacinacoes = database.Vacinacoes.Include(p => p.Pessoa).Include(l => l.Lote).Where(p => p.Status == true).ToList();
      var pessoasVacinaveis = new List<Pessoa>();
      var pessoasVacinadas = new List<Pessoa>();
      foreach (var vacinacao in vacinacoes)
      {
        pessoasVacinadas.Add(vacinacao.Pessoa);
      }

      //Condições para pessoas serem vacinaveis
      if (tipoDose == true)// => Dose dupla
      {
        foreach (var pessoa in pessoas)
        {
          if (!pessoasVacinadas.Contains(pessoa))
          {
            _pessoasVacinaveis.Add(pessoa);
          }
          else
          {
            var vacinacoesPessoa = database.Vacinacoes.Include(l => l.Lote).Include(l => l.Lote.Vacina).Include(l => l.Pessoa).Where(v => v.Pessoa == pessoa && v.Status == true).ToList();
            if (vacinacoesPessoa.All(v => v.Dose == false) && vacinacoesPessoa.Any(v => v.Lote.Vacina.Nome == loteAtual.Vacina.Nome)) _pessoasVacinaveis.Add(pessoa);
          }
        }
      }
      else if (tipoDose == false)// => Dose única
      {
        foreach (var pessoa in pessoas)
        {
          if (!pessoasVacinadas.Contains(pessoa)) _pessoasVacinaveis.Add(pessoa);
        }
      }
    }
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
    public class AcessoDTO
    {
      public string dados { get; set; }
    }
    string[] Ufs = new string[]
        {
          "AC",
          "AL",
          "AP",
          "AM",
          "BA",
          "CE",
          "DF",
          "ES",
          "GO",
          "MA",
          "MT",
          "MS",
          "MG",
          "PA",
          "PB",
          "PR",
          "PE",
          "PI",
          "RJ",
          "RN",
          "RS",
          "RO",
          "RR",
          "SC",
          "SP",
          "SE",
          "TO",
        };

  }
}
