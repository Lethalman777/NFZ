using NFZ.Entities;

namespace NFZ.Decorators
{
    public class Packaging : IPackaging
    {
        private decimal cena { get; set; }
        private string opis { get; set; }
        public decimal Cena() { return cena; }
        public String Opis() { return opis="Opakowanie: "; }      
    }
}
