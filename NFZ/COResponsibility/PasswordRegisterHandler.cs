using NFZ.Entities;
using NFZ.Services;

namespace NFZ.COResponsibility
{
    public class PasswordRegisterHandler : Handler
    {

        public override bool Handle(string login, string password, string confirmPassword, string firstname, string lastname)
        {
            if (password == null || (password.Length < 4 || password != confirmPassword))
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
