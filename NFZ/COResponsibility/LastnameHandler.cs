using NFZ.Entities;
using NFZ.Services;

namespace NFZ.COResponsibility
{
    public class LastnameHandler : Handler
    {

        public override bool Handle(string login, string password, string confirmPassword, string firstname, string lastname)
        {
            if (lastname.Length == 0)
            {
                return true;
            }
            else
            {
                return HandleNext(login, password, confirmPassword, firstname, lastname);
            }
        }
    }
}
