using NFZ.Entities;

namespace NFZ.Decorators
{
    public class Packaging : IPackaging
    {
        private float cena { get; set; }
        private string opis { get; set; }
        public float Cena() { return cena; }
        public String Opis() { return opis="Opakowanie"; }      
    }
}
