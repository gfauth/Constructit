using ControleCondominal.Database;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace ControleCondominal.Models
{
    public class Condominio
    {
        public int Id { get; private set; }
        
        public string Nome { get; set; }
        
        public string Bairro { get; set; }
    }
}
