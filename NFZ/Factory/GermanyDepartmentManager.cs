namespace NFZ.Factory
{
    public class GermanyDepartmentManager : DepartmentManager
    {
        public override Department CreateDepartment()
        {
            return new GermanyDepartment();
        }
    }
}
