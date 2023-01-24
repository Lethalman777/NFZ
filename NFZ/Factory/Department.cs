namespace NFZ.Factory
{
    //klasa bazowa metody fabrykującej 
    public abstract class Department
    {
        public string Address { get; set; }

        public string NIP { get; set; }

        public string AccountNr { get; set; }

        //metoda tworząca dany obiekt
        public abstract void Prepare();
    }
}
