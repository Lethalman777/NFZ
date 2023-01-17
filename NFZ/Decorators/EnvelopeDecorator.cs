namespace NFZ.Decorators
{
    public class EnvelopeDecorator : PackagingDecorator
    {
        public EnvelopeDecorator(IPackaging packaging) : base(packaging) { }
        public override decimal Cena() //Nadpisanie metody Cena() z klasy PackagingDecorator
        {
            return base.Cena() + 2;
        }
        public override string Opis() //Nadpisanie metody Opis() z klasy PackagingDecorator
        {
            return base.Opis() + "koperta";
        }
    }
}
