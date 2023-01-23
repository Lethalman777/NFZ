namespace NFZ.Factory
{
    public class GermanyDepartment : Department
    {
        public string SwiftNr { get; set; }

        public override void Prepare()
        {
            Address = "Werner-Heisenberg-Allee 25";
            NIP = "555-555-555";
            AccountNr = "PL 69 5211 7543 0000 1000 9867 90";
            SwiftNr = "REYG 8769870 GR";
        }
    }
}
