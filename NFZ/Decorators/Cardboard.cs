using NFZ.Entities;

namespace NFZ.Decorators
{
    public class Cardboard : Packaging
    {
        public Cardboard(Order order) : base(order) { }

        public float Cena(Packaging packaging)
        {
            return packaging.Cena() + 10;
        }

        public String Opis(Packaging packaging)
        {
            return packaging.Opis() + "Karton";
        }
    }
}
