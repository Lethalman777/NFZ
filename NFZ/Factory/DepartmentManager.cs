namespace NFZ.Factory
{
    public abstract class DepartmentManager
    {
        public Department GetDepartment()
        {
            Department department = CreateDepartment();
            department.Prepare();
            return department;
        }

        public abstract Department CreateDepartment();
    }
}
