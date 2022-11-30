namespace Birdz
{
    public class Login
    {
        static LoginDB database = new LoginDB();

        public Login()
        {
        }

        public bool AddEntry(String username, String password)
        {
            if (VerifyUsernameUnique(username))
            {
                database.AddEntry(username, password);
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool VerifyUsernameUnique(String username)
        {
            return database.VerifyUsernameUnique(username);
        }
    }
}

