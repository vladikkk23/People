using People.BusinessLogic.Interfaces;

namespace People.BusinessLogic
{
    public class MyBusinessLogic
    {
        public ISession GetSessionBL()
        {
            return new SessionBL();
        }
    }
}
