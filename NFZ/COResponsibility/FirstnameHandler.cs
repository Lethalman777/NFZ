using NFZ.Entities;
using NFZ.Services;

namespace NFZ.COResponsibility
{
    public class FirstnameHandler : Handler
    {

        public override bool Handle(string login, string password, string confirmPassword, string firstname, string lastname)
        {
            if (firstname.Length == 0)
            {
                return false;
            }
            else
            {
                return HandleNext(login, password, confirmPassword, firstname, lastname);
            }
        }
    }
}
