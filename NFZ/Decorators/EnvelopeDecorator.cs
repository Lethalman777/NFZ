﻿namespace NFZ.Decorators
{
    public class EnvelopeDecorator : PackagingDecorator
    {
        public EnvelopeDecorator(IPackaging packaging) : base(packaging) { }
        public override float Cena()
        {
            return base.Cena() + 2;
        }
        public override string Opis()
        {
            return base.Opis() + "koperta";
        }
    }
}