using System.ComponentModel.DataAnnotations;

namespace DesafioMVC.DTO
{
  public class SelecaoVacinaDTO
  {
    [Required(ErrorMessage = "Selecione um lote")]
    public int LoteId { get; set; }
  }
}