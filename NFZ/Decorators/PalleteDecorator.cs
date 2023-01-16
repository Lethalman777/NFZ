﻿namespace NFZ.Decorators
{
    public class PalleteDecorator : PackagingDecorator
    {
        public PalleteDecorator(IPackaging packaging) : base(packaging) { }
        public override decimal Cena()
        {
            return base.Cena() + 70;
        }
        public override string Opis()
        {
            return base.Opis() + "paleta";
        }
    }
}
