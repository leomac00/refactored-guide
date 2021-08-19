namespace DesafioMVC.Models
{
  public class Vacina
  {
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Laboratorio { get; set; }
    public bool Posologia { get; set; } //true=dose dupla; false=dose unica
    public int Intervalo { get; set; }
    public bool Status { get; set; }//deleção booleana
  }
}