using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjetoM2.Models
{
    public class Pedido
    {
        public int Id { get; set; }

        public virtual Cliente Cliente { get; set; }

        public virtual int ReceitaID { get; set; }

        public virtual Receita Receita { get; set; }

        public int Quantidade { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        [DataType(DataType.Date, ErrorMessage = "Data em formato inválido")]
        public DateTime? Data { get; set; }

        public float Preco { get; set; }

        public bool Finalizado { get; set; }
    }
}