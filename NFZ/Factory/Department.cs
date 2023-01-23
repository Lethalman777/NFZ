namespace NFZ.Factory
{
    public abstract class Department
    {
        public string Address { get; set; }

        public string NIP { get; set; }

        public string AccountNr { get; set; }

        public abstract void Prepare();
    }
}
