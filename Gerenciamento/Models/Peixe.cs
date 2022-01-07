using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;



namespace Gerenciamento.Models
{
    public class Peixe
    {
   
        public int id { get; set; }

        public string Nome { get; set; }

        public decimal Ph { get; set; }

        public decimal Temperatura { get; set; }

        public decimal TamanhoMin { get; set; }

        public decimal TamanhoMax { get; set; }

        public string Informacoes { get; set; }

        [DataType(DataType.Date)]
        public DateTime DataCriacao { get; set; }
        
        public int NaturalidadeId { get; set; }     
    }
}
