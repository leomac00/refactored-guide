namespace DesafioMVC.Models
{
  public class LocalVacinacao
  {
    public int Id { get; set; }
    public string Nome { get; set; }
    public Endereco Endereco { get; set; }
    public bool Status { get; set; }//deleção booleana
  }
}