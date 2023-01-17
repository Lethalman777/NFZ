namespace NFZ.Decorators
{
    public class CardboardDecorator : PackagingDecorator
    {
        public CardboardDecorator(IPackaging packaging) : base(packaging) { }
        public override decimal Cena() //Nadpisanie metody Cena() z klasy PackagingDecorator
        {
            return base.Cena() + 10;
        }
        public override string Opis() //Nadpisanie metody Opis() z klasy PackagingDecorator
        {
            return base.Opis() + "karton";
        }
    }
}
