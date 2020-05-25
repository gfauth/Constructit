namespace ControleCondominal.Models
{
    public class Familia
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int Apartamento { get; set; }
        public Condominio Condominio { get; set; }
    }
}
