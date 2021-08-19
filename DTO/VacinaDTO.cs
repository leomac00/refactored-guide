using System.ComponentModel.DataAnnotations;

namespace DesafioMVC.DTO
{
  public class VacinaDTO
  {
    [Required]
    public int Id { get; set; }

    [Required(ErrorMessage = "Nome da vacina é obrigatório")]
    [StringLength(100, ErrorMessage = "Nome da vacina deve ter entre 2 e 100 caracteres")]
    [MinLength(2, ErrorMessage = "Nome da vacina deve ter entre 2 e 100 caracteres")]
    public string Nome { get; set; }
    [Required(ErrorMessage = "Nome do laboratório é obrigatório")]
    [StringLength(100, ErrorMessage = "Nome do laboratório deve ter entre 2 e 100 caracteres")]
    [MinLength(2, ErrorMessage = "Nome do laboratório deve ter entre 2 e 100 caracteres")]
    public string Laboratorio { get; set; }
    [Required(ErrorMessage = "Posologia é obrigatório")]
    public bool Posologia { get; set; } //true=dose dupla; false=dose unica
    [Required(ErrorMessage = "Intervalo entre doses é obrigatório")]
    public int Intervalo { get; set; }
  }
}