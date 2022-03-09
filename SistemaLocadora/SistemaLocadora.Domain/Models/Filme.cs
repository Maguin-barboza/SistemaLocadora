using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaLocadora.Domain.Models
{
    public class Filme
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public int ClassificacaoIndicativa { get; set; }
        public int Lancamento { get; set; }

        public IEnumerable<Locacao> Locacoes { get; set; }
    }
}