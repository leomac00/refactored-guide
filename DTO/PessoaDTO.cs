using System;
using System.ComponentModel.DataAnnotations;

namespace DesafioMVC.DTO
{
  public class PessoaDTO
  {

    [Required]
    public int Id { get; set; }

    [Required(ErrorMessage = "CPF é obrigatório")]
    [StringLength(14, ErrorMessage = "CPF Nao pode ter mais de 11 digitos")]
    [MinLength(14, ErrorMessage = "CPF deve ter 11 digitos")]
    public string Cpf { get; set; }


    [Required(ErrorMessage = "Nome é obrigatório")]
    [StringLength(100, ErrorMessage = "Nome deve ter entre 2 e 100 caracteres")]
    [MinLength(2, ErrorMessage = "Nome deve ter entre 2 e 100 caracteres")]
    public string Nome { get; set; }
    [Required(ErrorMessage = "Data de nascimento é obrigatória")]

    public DateTime Nascimento { get; set; }
    [Required(ErrorMessage = "Selecione um endereço")]
    public int EnderecoId { get; set; }
  }
}