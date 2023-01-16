﻿namespace NFZ.Decorators
{
    public class CardboardDecorator : PackagingDecorator
    {
        public CardboardDecorator(IPackaging packaging) : base(packaging) { }
        public override float Cena() 
        {
            return base.Cena() + 10;
        }
        public override string Opis()
        {
            return base.Opis() + "karton";
        }
    }
}