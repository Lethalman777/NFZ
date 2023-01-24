namespace NFZ.Factory
{
    //klasa dająca dostęp do tworzenia obiektów metodą fabrykującą
    public abstract class DepartmentManager
    {
        //metoda zwracająca stworzony obiekt
        public Department GetDepartment()
        {
            Department department = CreateDepartment();
            department.Prepare();
            return department;
        }

        //metoda tworząca wybrany obiekt
        public abstract Department CreateDepartment();
    }
}
