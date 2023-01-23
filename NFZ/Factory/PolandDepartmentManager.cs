namespace NFZ.Factory
{
    public class PolandDepartmentManager : DepartmentManager
    {
        public override Department CreateDepartment()
        {
            return new PolandDepartment();
        }
    }
}
