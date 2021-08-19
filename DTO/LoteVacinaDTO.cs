using System;
using System.ComponentModel.DataAnnotations;

namespace DesafioMVC.DTO
{
  public class LoteVacinaDTO
  {
    [Required]
    public int Id { get; set; }


    [Required(ErrorMessage = "Seleção da vacina é obrigatória")]
    public int VacinaId { get; set; }


    [Required(ErrorMessage = "Identificação do lote da vacina é obrigatório")]
    [StringLength(100, ErrorMessage = "Identificação do lote deve ter entre 2 e 100 caracteres")]
    [MinLength(2, ErrorMessage = "Identificação do lote ter entre 2 e 100 caracteres")]
    public string Lote { get; set; }


    [Required(ErrorMessage = "Quantidade recebida é obrigatória")]
    public int QtdRecebida { get; set; }


    public int QtdRestante { get; set; }


    [Required(ErrorMessage = "Data de recebimento é obrigatória")]
    public DateTime DataRecebimento { get; set; }


    [Required(ErrorMessage = "Data de validade é obrigatória")]
    public DateTime DataValidade { get; set; }

    //Auxiliares
    private readonly DateTime hoje = DateTime.Now;
  }
}