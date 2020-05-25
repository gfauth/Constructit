using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace Dados.Models
{
    public class Morador
    {
        public int Id { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "O campo Nome é obrigatório.")]
        public string Nome { get; private set; }
        [Range(0,100)]
        public int QtdPets { get; private set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "O campo Família é obrigatório.")]
        public Familia Familia { get; private set; }


        public static List<Morador> GetAll(DatabaseContext _context)
        {
            List<Morador> result = _context.Moradors.OrderBy(order => order.Nome).ToList();
            return result;
        }

        public static ViewStatus TryDelete(DatabaseContext context, int id)
        {
            try
            {
                var item = context.Moradors.FirstOrDefault(x => x.Id == id);
                context.Moradors.Remove(item);
                int result = context.SaveChanges();

                if (result == 1)
                    return new ViewStatus(200);
                else
                    return new ViewStatus(string.Format("Ocorreu um erro enquanto tentava realziar a exclusão do Morador {0}.", item.Nome), 400);
            }
            catch (Exception ex)
            {
                return new ViewStatus(string.Format("{0} \r\n INNER: {1}", ex.Message, ex.InnerException.Message), 401);
            }
        }
    }
}
