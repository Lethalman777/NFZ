namespace NFZ.Decorators
{
    public class PalleteDecorator : PackagingDecorator
    {
        public PalleteDecorator(IPackaging packaging) : base(packaging) { }
        public override decimal Cena() //Nadpisanie metody Cena() z klasy PackagingDecorator
        {
            return base.Cena() + 70;
        }
        public override string Opis() //Nadpisanie metody Opis() z klasy PackagingDecorator
        {
            return base.Opis() + "paleta";
        }
    }
}
