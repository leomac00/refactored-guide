using System;
using System.Collections.Generic;

namespace DesafioMVC.Models
{
  public class Pessoa
  {
    public int Id { get; set; }
    public string Cpf { get; set; }
    public string Nome { get; set; }
    public DateTime Nascimento { get; set; }
    public Endereco Endereco { get; set; }
    public bool Status { get; set; }//deleção booleana
  }
}