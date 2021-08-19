using System.ComponentModel.DataAnnotations;

namespace DesafioMVC.DTO
{
  public class EnderecoDTO
  {
    [Required]
    public int Id { get; set; }

    [Required(ErrorMessage = "Cep é obrigatório")]
    [StringLength(10, ErrorMessage = "CEP não pode ter mais de 8 digitos")]
    [MinLength(10, ErrorMessage = "CEP deve ter 8 digitos")]
    public string Cep { get; set; }


    [Required(ErrorMessage = "Logradouro é obrigatório")]
    public string Logradouro { get; set; }



    [Required(ErrorMessage = "Numero é obrigatório")]
    public string Numero { get; set; }


    public string Complemento { get; set; }



    [Required(ErrorMessage = "Cidae é obrigatório")]
    public string Cidade { get; set; }



    [Required(ErrorMessage = "Estado é obrigatório")]
    public string Estado { get; set; }
  }
}