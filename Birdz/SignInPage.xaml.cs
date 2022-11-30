namespace Birdz;

public partial class SignInPage : ContentPage
{
    AccountPreparation LoginLogic = new AccountPreparation();

    public SignInPage()
	{
		InitializeComponent();
	}

   async void SignInClicked(object sender, EventArgs e)
    {
        String username = Username.Text;
        String password = Password.Text;

        if (LoginLogic.AddEntry(username, password))
        {
            await Navigation.PushAsync(new EntryInfoPage());
        }
        else
        {
            await DisplayAlert("ERROR", "Username Taken", "OK");
        }

    }

    void LogInClicked(object sender, EventArgs e)
    {
        LogIn.Clicked += async (sender, args) =>
        {
            await Navigation.PushAsync(new SignInPage());
        };
    }
    void ForgotPasswordClicked(object sender, EventArgs e)
    {

    }
}
