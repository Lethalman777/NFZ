namespace NFZ.COResponsibility
{
    public abstract class Handler
    {
        //następny handler w łańcuchu
        private Handler Next;

        //metoda ustawiająca kolejne ogniwo w łańcuchu
        public Handler SetNextHandler(Handler Next)
        {
            this.Next = Next;
            return Next;
        }

        //metoda spradzająca czy dany elememt formularza spełnia wymagania
        public abstract bool Handle(string login, string password, string confirmPassword, string firstname, string lastname);

        //metoda obsługująca przejście do następnego handlera
        protected bool HandleNext(string login, string password, string confirmPassword, string firstname, string lastname)
        {
            if(Next == null)
            {
                return true;
            }
            return Next.Handle(login, password, confirmPassword, firstname, lastname);
        }
    }
}
