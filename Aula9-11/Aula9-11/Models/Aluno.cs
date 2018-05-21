using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Aula9_11.Models
{
    public class Aluno
    {
        public string Id { get; set; }
        [DisplayName("Primeiro nome")]
        [Required]
        public string Nome {get;set;}
        [DisplayName("Último nome")]
        [Required]
        public string Sobrenome { get; set; }
        [DisplayName("RA")]
        [Required]
        [RegularExpression("[0-9]{6}", ErrorMessage = "RA inválido!")]
        public string Ra { get; set; }

        public Aluno()
        {
            Id = Guid.NewGuid().ToString();
        }

    }
}