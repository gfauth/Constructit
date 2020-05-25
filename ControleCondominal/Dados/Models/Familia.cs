using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace Dados.Models
{
    public class Familia
    {
        public int Id { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "O campo Nome é obrigatório.")]
        public string Nome { get; private set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "O campo Apartamento é obrigatório.")]
        public int Apartamento { get; private set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "O campo Condomínio é obrigatório.")]
        public Condominio Condominio { get; private set; }

        public static List<Familia> GetAll(DatabaseContext _context)
        {
            List<Familia> result = _context.Familias.OrderBy(order => order.Nome).ToList();
            return result;
        }

        public static ViewStatus TryDelete(DatabaseContext context, int id)
        {
            try
            {
                var item = context.Familias.FirstOrDefault(x => x.Id == id);
                context.Familias.Remove(item);
                int result = context.SaveChanges();

                if (result == 1)
                    return new ViewStatus(200);
                else
                    return new ViewStatus(string.Format("Ocorreu um erro enquanto tentava realziar a exclusão da Familia {0}.", item.Nome), 400);
            }
            catch (Exception ex)
            {
                return new ViewStatus(string.Format("{0} \r\n INNER: {1}", ex.Message, ex.InnerException.Message), 401);
            }
        }
    }
}
