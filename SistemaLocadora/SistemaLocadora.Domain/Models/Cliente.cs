using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaLocadora.Domain.Models
{
    public class Cliente
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string CPF { get; set; }
        public DateTime DataNascimento { get; set; }

        public IEnumerable<Locacao> Locacoes { get; set; }
    }
}
