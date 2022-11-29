using System;
using System.Windows;
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
        if(LoginLogic.CheckValidLogIn(Username.Text, Password.Text))
        {
            SignIn.Clicked += async (sender, args) =>
            {
                await Navigation.PushAsync(new EntryInfoPage());
            };
        }
        else
        {
            DisplayAlert("ERROR", "Username Taken", "OK");
        }
    }

    void RegisterClicked(object sender, EventArgs e)
    {
        Register.Clicked += async (sender, args) =>
        {
            await Navigation.PushAsync(new SignInPage());
        };
    }


void ForgotPasswordClicked(object sender, EventArgs e)
    {

    }
}