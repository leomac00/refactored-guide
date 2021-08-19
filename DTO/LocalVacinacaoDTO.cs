using System.ComponentModel.DataAnnotations;

namespace DesafioMVC.DTO
{
  public class LocalVacinacaoDTO
  {
    [Required]
    public int Id { get; set; }


    [Required(ErrorMessage = "Nome do local é obrigatório")]
    [StringLength(100, ErrorMessage = "Nome do local deve ter entre 2 e 100 caracteres")]
    [MinLength(2, ErrorMessage = "Nome do local deve ter entre 2 e 100 caracteres")]
    public string Nome { get; set; }


    [Required(ErrorMessage = "Local é obrigatorio")]
    public int LocalId { get; set; }
  }
}