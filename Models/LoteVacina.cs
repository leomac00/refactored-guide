using System;

namespace DesafioMVC.Models
{
    public class LoteVacina
    {
        public int Id { get; set; }
        public Vacina Vacina { get; set; }
        public string Lote { get; set; }
        public int QtdRecebida { get; set; }
        public int QtdRestante { get; set; }
        public DateTime DataRecebimento { get; set; }
        public DateTime DataValidade { get; set; }
        public bool Status { get; set; }//true=Lote ativo; false=lote inativo(por quantidade ou validade)
    }
}