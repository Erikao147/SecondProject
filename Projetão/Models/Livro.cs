using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Projetão.Models
{
   [System.ComponentModel.DataAnnotations.Schema.Table("Livros")]
    public class Livro : BaseModel
    {
      public string Nome { get; set; }
      public string Resumo { get; set; }
      public string Quantidade { get; set; }
      public string Valor { get; set; }
      public string Lançamento { get; set; }

    }
}
