﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoM2.Models
{
    public class Cliente
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public string Endereco { get; set; }

        public string Contato { get; set; }

        public string Email { get; set; }
    }
}