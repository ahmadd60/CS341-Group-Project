namespace Birdz;

// Primary Author: DA
// Secondary Author: AR
// Reviewer: AR
public partial class LoginPage : ContentPage
{
    AccountPreparation Login = new AccountPreparation();
    string username;
    string password;

    public LoginPage()
    {
        InitializeComponent();
    }


    async void SignInClicked(object sender, EventArgs e)
    {
        username = Username.Text;
        password = Password.Text;

        AccountPreparation.InvalidLoginAttempt error = Login.CheckValidLogin(username, password);
        if (error.Equals(AccountPreparation.InvalidLoginAttempt.None))
        {
            await Navigation.PushAsync(new JournalListView());

            //Application.Current.MainPage = new AppShell();
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
        //Application.Current.MainPage = new SignUpPage();
    }


    void ForgotPasswordClicked(object sender, EventArgs e)
    {
    }
}