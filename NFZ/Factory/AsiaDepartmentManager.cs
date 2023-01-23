namespace NFZ.Factory
{
    public class AsiaDepartmentManager : DepartmentManager
    {
        public override Department CreateDepartment()
        {
            return new AsiaDepartment();
        }
    }
}
