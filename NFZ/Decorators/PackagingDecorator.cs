namespace NFZ.Decorators
{
    public class PackagingDecorator : IPackaging
    {
        private IPackaging _packaging;
        public PackagingDecorator(IPackaging packaging)
        {
            _packaging = packaging;
        }
        public virtual decimal Cena() { return _packaging.Cena(); } //Meoda virtualna zwracająca cenę opakowania
        public virtual String Opis() { return _packaging.Opis(); } //Metoda virtualna zwracająca opis opakowania
    }
}
