using SmoothieApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SmoothieApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Login : ContentPage
    {
        public Login()
        {
            InitializeComponent();
            Init();
            ActivitySpinner.IsVisible = false;
        }

        void Init()
        {
            BackgroundColor = Constants.BackgroundColour;
            Lbl_Username.TextColor = Constants.MainTextColour;
            Lbl_Password.TextColor = Constants.MainTextColour;
            LoginIcon.HeightRequest = Constants.LoginIconHeight;

            Entry_Username.Completed += (s, e) => Entry_Password.Focus();//after username has been set change focus to password
            Entry_Password.Completed += (s, e) => SignIn(s, e);//after passwrod has been set sign in
        }

        void SignIn(object sender, EventArgs e)
        {
            User user = new User(Entry_Username.Text, Entry_Password.Text);
            if (user.ValidateSignIn())
            {
                DisplayAlert("Login", "Login Success", "Ok");
            }
            else
            {
                DisplayAlert("Login", "Login error. Username or password was left empty.", "Ok");
            }
        }
    }
        
}