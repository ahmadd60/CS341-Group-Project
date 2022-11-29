namespace Birdz;

public partial class SignInPage : ContentPage
{
    Login LoginLogic = new Login();

    public SignInPage()
	{
		InitializeComponent();
	}

    void SignInClicked(object sender, EventArgs e)
    {
        if (LoginLogic.AddEntry(Username.Text, Password.Text))
        {
            SignIn.Clicked += (sender, args) =>
            {
                Navigation.PushAsync(new EntryInfoPage());
            };
        }
        else
        {
            DisplayAlert("ERROR", "Username Taken", "OK");
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
