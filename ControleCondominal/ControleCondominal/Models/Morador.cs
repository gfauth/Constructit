namespace ControleCondominal.Models
{
    public class Morador
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int QtdPets { get; set; }
        public Familia Familia { get; set; }
    }
}
