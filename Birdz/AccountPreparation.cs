// Primary Author: DA
// Secondary Author: AR
// Reviewer: AR
namespace Birdz
{
    public class AccountPreparation
    {
        public static AccountDatabase database = new AccountDatabase();

        public AccountPreparation()
        {
        }
        public enum InvalidLoginAttempt
        {
            None,
            Password,
            Username,
            NullField
        }

        public InvalidLoginAttempt CheckValidLogin(String username, String password)
        {
            if (username == null || password == null)
            {
                return InvalidLoginAttempt.NullField;
            }
            if (database.UsernameExists(username))
            {
                return InvalidLoginAttempt.Username;
            }
            if (!database.GetPassword(username).Equals(password))
            {
                return InvalidLoginAttempt.Password;
            }
            return InvalidLoginAttempt.None;
        }

        public InvalidLoginAttempt CheckValidRegistration(String username, String password)
        {
            if (username == null || password == null)
            {
                return InvalidLoginAttempt.NullField;
            }
            if (!database.UsernameExists(username))
            {
                return InvalidLoginAttempt.Username;
            }
            if (!VerifyNewPassword(password))
            {
                return InvalidLoginAttempt.Password;
            }
            database.AddEntry(username, password);
            return InvalidLoginAttempt.None;
        }

        private bool VerifyNewPassword(String password)
        {
            //do this method
            return true;
        }

    }
}




