using NFZ.Entities;

namespace NFZ.Decorators
{
    public class Pallete : Packaging
    {
        public Pallete(Order order) : base(order) { }

        public float Cena(Packaging packaging)
        {
            return packaging.Cena() + 70;
        }

        public String Opis(Packaging packaging)
        {
            return packaging.Opis()+ "Paleta";
        }
    }
}
