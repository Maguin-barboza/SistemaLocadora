using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaLocadora.Domain.Models
{
    public class Locacao
    {
        public int Id { get; set; }
        [Column("Id_Cliente")]
        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; }
        [Column("Id_Filme")]
        public int FilmeId { get; set; }
        public Filme Filme { get; set; }
        public DateTime DataLocacao { get; set; }
        public DateTime DataDevolucao { get; set; }
    }
}
