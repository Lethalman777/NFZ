using NFZ.Entities;

namespace NFZ.Decorators
{
    public class Packaging : Order
    {
        private Order order { get; set; }
        private float cena { get; set; }
        private String opis { get; set; }
        public Packaging(Order order)
        {
            this.order = order;
            this.cena = 1;
            this.opis = "Opakowanie";
        }

        public float Cena()
        {
            return 1;
        }

        public String Opis()
        {
            return "Opakowanie: ";
        }
    }
}
