using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Gerenciamento.Models
{
    public class Naturalidade
    {
        public int id { get; set; }

        public string Descricao { get; set; }

        [DataType(DataType.Date)]
        public DateTime DataCriacao { get; set; }

        public static int NumeroDeNaturalidades;

    }
}
