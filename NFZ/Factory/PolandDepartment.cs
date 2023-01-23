namespace NFZ.Factory
{
    public class PolandDepartment : Department
    {
        public string AccountantOfficeAddress { get; set; }

        public override void Prepare()
        {
            Address = "Śródmieście 31, 16-300 Augustów";
            NIP = "777-777-777";
            AccountNr = "PL 12 4567 33245 0000 1000 9867 90";
            AccountantOfficeAddress = "ul. Mazurska 7, 16-300 Augustów";
        }
    }
}
