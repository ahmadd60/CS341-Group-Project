
namespace Birdz;

public partial class SignUpPage : ContentPage
{
    AccountPreparation NewAccount = new AccountPreparation();

    public SignUpPage()
    {
        InitializeComponent();
    }

    void RegisterClicked(object sender, EventArgs e)
    {
        string username = Username.Text;
        string password = Password.Text;

        AccountPreparation.InvalidLoginAttempt error = NewAccount.CheckValidRegistration(username, password);
        if (error.ToString().Equals("None"))
        {
            GoodEntry(username);
            Application.Current.MainPage = new AppShell();
        }
        else
        {
            BadEntry(error);
        }
    }

    async void BadEntry(AccountPreparation.InvalidLoginAttempt error)
    {
        string errorString = error.ToString();
        string message = "";
        if (errorString.Equals("Password"))
        {
            message = "Bad Password";
        }
        else if (errorString.Equals("Username"))
        {
            message = "Username taken! :(";
        }
        else
        {
            message = "One or more fields are empty!";
        }
        await DisplayAlert("Login Failed", message, "OK");
    }

    async void GoodEntry(string username)
    {
        await DisplayAlert("Chirp!", "Account successfuly registered to: " + username, "SWEET!");
    }

}
