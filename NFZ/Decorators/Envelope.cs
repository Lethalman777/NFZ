using NFZ.Entities;

namespace NFZ.Decorators
{
    public class Envelope : Packaging
    {
        public Envelope(Order order) : base(order) { }

        public float Cena(Packaging packaging)
        {
            return packaging.Cena() + 2;
        }

        public String Opis(Packaging packaging)
        {
            return packaging.Opis() + "Koperta";
        }
    }
}
