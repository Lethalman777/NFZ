using NFZ.Entities;
using NFZ.Services;

namespace NFZ.COResponsibility
{
    public class PasswordHandler : Handler
    {
        private IDatabaseService databaseService;

        public PasswordHandler(IDatabaseService databaseService)
        {
            this.databaseService = databaseService;
        }

        public override bool Handle(string login, string password, string confirmPassword, string firstname, string lastname)
        {
            Worker account = databaseService.GetLogin(login);
            if (account.Password == password)
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
