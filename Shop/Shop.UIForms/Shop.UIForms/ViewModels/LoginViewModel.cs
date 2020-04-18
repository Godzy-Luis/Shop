using GalaSoft.MvvmLight.Command;
using Shop.UIForms.Views;
using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace Shop.UIForms.ViewModels
{
    public class LoginViewModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public ICommand LoginCommand 
        {
            get
            {
                return new RelayCommand(Login);
            } 
        }

        public LoginViewModel()
        {
            this.Email = "ing.luisenriquemtz93@gmail.com";
            this.Password = "Valentina09";
        }

        private async void Login()
        {
            if (string.IsNullOrEmpty(this.Email))
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    "Ingresa Correo",
                    "Aceptar");
                return;
            }

            if (string.IsNullOrEmpty(this.Password))
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    "Ingresa Password",
                    "Aceptar");
                return;
            }

            if (!this.Email.Equals("ing.luisenriquemtz93@gmail.com") && !this.Password.Equals("Valentina09"))
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    "Password Incorrecto",
                    "Aceptar");
                return;
            }

            //await Application.Current.MainPage.DisplayAlert(
            //    "OK",
            //    "Correcto",
            //    "Aceptar");

            MainViewModel.GetInstance().Products = new ProductsViewModel();
            await Application.Current.MainPage.Navigation.PushAsync(new ProductsPage());
        }
    }
}
