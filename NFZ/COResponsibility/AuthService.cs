namespace NFZ.COResponsibility
{
    //klasa zawierająca handler walidacji
    public class AuthService
    {
        private Handler handler;

        public AuthService(Handler handler)
        {
            this.handler = handler;
        }

        //metoda obsługująca logowanie
        public bool LogIn(string login, string password)
        {
            if(handler.Handle(login, password, "", "", ""))
            {
                return true;
            }
            return false;
        }

        //metoda obsługująca rejestracje
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
