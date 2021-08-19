using System;
using System.ComponentModel.DataAnnotations;

namespace DesafioMVC.DTO
{
  public class VacinacaoDTO
  {
    [Required]
    public int Id { get; set; }



    [Required(ErrorMessage = "Selecione uma pessoa para vacinar")]
    public int PessoaId { get; set; }



    [Required(ErrorMessage = "Data da vacina é obrigatória")]
    public DateTime Data { get; set; }


    [Required(ErrorMessage = "Selecione um lote para utilizar")]
    public int LoteId { get; set; }


    [Required(ErrorMessage = "Selecione um local de vacinação")]
    public int LocalId { get; set; }

    public bool Dose { get; set; }
  }
}