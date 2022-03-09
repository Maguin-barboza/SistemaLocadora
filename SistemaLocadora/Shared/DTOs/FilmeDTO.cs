using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaLocadora.Shared.DTOs
{
    public class FilmeDTO
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public int ClassificacaoIndicativa { get; set; }
        public bool Lancamento { get; set; }
    }
}
