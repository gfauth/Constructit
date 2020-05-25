using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Dados.Models
{
    public class Condominio
    {
        public int Id { get; private set; }
        
        [Required(AllowEmptyStrings =false, ErrorMessage = "O campo Nome é obrigatório.")]
        public string Nome { get; private set; }
        
        [Required(AllowEmptyStrings = false, ErrorMessage = "O campo Bairro é obrigatório.")]
        public string Bairro { get; private set; }

        public static List<Condominio> GetAll(DatabaseContext _context)
        {
            List<Condominio> result = _context.Condominios.OrderBy(order => order.Nome).ToList();
            return result;
        }

        public static ViewStatus TryDelete(DatabaseContext context, int id)
        {
            try
            {
                var item = context.Condominios.FirstOrDefault(x => x.Id == id);
                context.Condominios.Remove(item);
                int result = context.SaveChanges();

                if (result == 1)
                    return new ViewStatus(200);
                else
                    return new ViewStatus(string.Format("Ocorreu um erro enquanto tentava realziar a exclusão do Condomínio {0}.", item.Nome), 400);
            }
            catch(Exception ex)
            {
                return new ViewStatus(string.Format("{0} \r\n INNER: {1}", ex.Message, ex.InnerException.Message), 401);
            }
        }
    }
}
