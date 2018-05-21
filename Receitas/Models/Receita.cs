using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjetoM2.Models
{
    public class Receita
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        [DataType(DataType.MultilineText)]
        public string Descricao { get; set; }
        
        public float Preco { get; set; }

    }
}