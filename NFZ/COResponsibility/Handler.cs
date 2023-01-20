namespace NFZ.COResponsibility
{
    public abstract class Handler
    {
        private Handler Next;

        public Handler SetNextHandler(Handler Next)
        {
            this.Next = Next;
            return Next;
        }

        public abstract bool Handle(string login, string password, string confirmPassword, string firstname, string lastname);

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
