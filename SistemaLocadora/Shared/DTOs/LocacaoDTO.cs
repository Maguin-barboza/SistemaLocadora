using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaLocadora.Shared.DTOs
{
    public class LocacaoDTO
    {
        public int Id { get; set; }
        public int ClienteId { get; set; }
        public string? ClienteNome { get; set; } = string.Empty;
        public int FilmeId { get; set; }
        public string? FilmeTitulo { get; set; } = string.Empty;
        public DateTime? DataLocacao { get; set; } = DateTime.Now.Date;
        public DateTime? DataDevolucao { get; set; }
    }
}
