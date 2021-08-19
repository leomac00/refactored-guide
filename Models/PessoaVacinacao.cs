namespace DesafioMVC.Models
{
    public class PessoaVacinacao
    {
        public int Id { get; set; }
        public int PessoaId { get; set; }
        public Pessoa Pessoa { get; set; }
        public int VacinacaoId { get; set; }
        public Vacinacao Vacinacao { get; set; }
    }
}