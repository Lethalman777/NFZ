namespace NFZ.Decorators
{
    public class PackagingDecorator : IPackaging
    {
        private IPackaging _packaging;
        public PackagingDecorator(IPackaging packaging)
        {
            _packaging = packaging;
        }
        public virtual float Cena() { return _packaging.Cena(); }
        public virtual String Opis() { return _packaging.Opis(); }
    }
}
