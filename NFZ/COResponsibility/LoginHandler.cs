using NFZ.Entities;
using NFZ.Services;

namespace NFZ.COResponsibility
{
    public class LoginHandler : Handler
    {
        private IDatabaseService databaseService;

        public LoginHandler(IDatabaseService databaseService)
        {
            this.databaseService = databaseService;
        }

        public override bool Handle(string login, string password, string confirmPassword, string firstname, string lastname)
        {
            Worker account = databaseService.GetLogin(login);
            if (account == null)
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
