using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace ControleCondominal.Models
{
    public class Relatorio
    {
        public int Id { get; set; }
        public string Bairro { get; set; }
        [DisplayName("Bichos de Estimação")]
        public int QtdPets { get; set; }
    }
}
