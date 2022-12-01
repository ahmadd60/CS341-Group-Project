using System;
using System.Windows;
namespace Birdz;

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

        if(Login.CheckValidLogIn(username, password))
        {
            await Navigation.PushAsync(new EntryInfoPage());
        }
        else
        {
            await DisplayAlert("ERROR", "Username Taken", "OK");
        }
    }

    async void RegisterClicked(object sender, EventArgs e)
    {
       await Navigation.PushAsync(new SignInPage());
    }


void ForgotPasswordClicked(object sender, EventArgs e)
    {
    }
}