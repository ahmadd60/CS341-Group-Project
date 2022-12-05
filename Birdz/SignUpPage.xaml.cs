namespace Birdz;

public partial class SignUpPage : ContentPage
{
    AccountPreparation NewAccount = new AccountPreparation();

    public SignUpPage()
    {
        InitializeComponent();
    }

    async void RegisterClicked(object sender, EventArgs e)
    {
        String username = Username.Text;
        String password = Password.Text;

        AccountPreparation.InvalidLoginAttempt error = NewAccount.CheckValidRegistration(username, password);
        if (error.ToString().Equals("None"))
        {
            await Navigation.PushAsync(new EntryInfoPage());
        }
        else
        {
            BadEntry(error);
        }
    }

    async void BadEntry(AccountPreparation.InvalidLoginAttempt error)
    {
        String errorString = error.ToString();
        String message = "";
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

}
