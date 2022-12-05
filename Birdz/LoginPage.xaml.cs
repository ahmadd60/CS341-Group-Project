namespace Birdz;

// Primary Author: DA
// Reviewer: AR
public partial class LoginPage : ContentPage
{
    AccountPreparation Login = new AccountPreparation();

    public LoginPage()
    {
        InitializeComponent();
    }


    async void SignInClicked(object sender, EventArgs e)
    {
        String username = Username.Text;
        String password = Password.Text;
        AccountPreparation.InvalidLoginAttempt error = Login.CheckValidLogin(username, password);
        if (error.Equals(AccountPreparation.InvalidLoginAttempt.None))
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
            message = "Incorrect Password";
        }
        else if (errorString.Equals("Username"))
        {
            message = "Username not found. Try registering a new account!";
        }
        else
        {
            message = "One or more fields are empty!";
        }
        await DisplayAlert("Login Failed", message, "OK");
    }

    async void RegisterClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new SignUpPage());
    }


    void ForgotPasswordClicked(object sender, EventArgs e)
    {
    }
}