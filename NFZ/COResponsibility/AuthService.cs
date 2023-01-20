namespace NFZ.COResponsibility
{
    public class AuthService
    {
        private Handler handler;

        public AuthService(Handler handler)
        {
            this.handler = handler;
        }

        public bool LogIn(string login, string password)
        {
            if(handler.Handle(login, password, "", "", ""))
            {
                return true;
            }
            return false;
        }

        public bool Register(string login, string password, string confirmPassword, string firstname, string lastname)
        {
            if (handler.Handle(login, password, confirmPassword, firstname, lastname))
            {
                return true;
            }
            return false;
        }
    }
}
