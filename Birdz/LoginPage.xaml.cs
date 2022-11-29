namespace Birdz;

public partial class LoginPage : ContentPage
{
    Login LoginLogic = new Login();

    public LoginPage()
    {
        InitializeComponent();
    }

    void SignInClicked(object sender, EventArgs e)
    {
        if (!LoginLogic.AddEntry("duaaahmad", "1234567890")) DisplayAlert("ERROR", "Username Taken", "OK");
    }
}