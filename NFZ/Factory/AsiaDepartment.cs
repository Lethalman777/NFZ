namespace NFZ.Factory
{
    public class AsiaDepartment : Department 
    {
        public string ProductOrigin { get; set; }

        public override void Prepare()
        {
            Address = "Kanton, Shamian Dajie nr 63";
            NIP = "666-666-666";
            AccountNr = "PL 48 5211 33245 0000 1000 9867 90";
            ProductOrigin = "China";
        }
    }
}
