using System;
using System.Collections.Generic;

namespace DesafioMVC.Models
{
  public class Vacinacao
  {
    public int Id { get; set; }
    public Pessoa Pessoa { get; set; }
    public DateTime Data { get; set; }
    public LoteVacina Lote { get; set; }
    public LocalVacinacao Local { get; set; }
    public bool Dose { get; set; }//true = terminou de vacinar; false = falta vacinar
    public bool Status { get; set; }//deleção booleana
  }
}