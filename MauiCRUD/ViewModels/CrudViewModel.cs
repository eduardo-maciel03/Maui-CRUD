using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Maui.Alerts;
using MauiCRUD.Models;
using MauiCRUD.Views;

namespace MauiCRUD.ViewModels
{
    public partial class CrudViewModel : ObservableObject
    {
        [ObservableProperty]
        string username;
        [ObservableProperty]
        string email;
        [ObservableProperty]
        DateTime birthday;

        public CrudViewModel()
        {
            Birthday = DateTime.Now;
        }

        [RelayCommand]
        public async Task GetUsers()
        {
            await Shell.Current.GoToAsync($"//{nameof(UsersView)}");
            Username = null;
            Email = null;
            Birthday = DateTime.Now;
        }

        [RelayCommand]
        public async Task Save()
        {
            var user = new Users()
            {
                Name = Username,
                Email = Email,
                Birthday = Birthday
            };

            var users = await App.UserRepository.GetAllUser();

            foreach(var item in users)
            {
                if (Email == item.Email)
                {
                    await App.Current.MainPage.DisplayAlert("Erro", "Usuário já está registrado!", "OK");
                    return;
                }
            }

            if(Username != null && Email != null)
            {
                await App.UserRepository.AddUser(user);
                await Toast.Make("Usuário registrado!").Show();
                return;
            }
            else
            {
                await App.Current.MainPage.DisplayAlert("Erro","Preencha todos os campos!","OK");
                return;
            }
        }

        [RelayCommand]
        public async Task Edit()
        {
            var users = await App.UserRepository.GetAllUser();

            if(users == null)
            {
                await App.Current.MainPage.DisplayAlert("Erro", "Nenhum usuário cadastrado!", "OK");
                return;
            }

            foreach (var user in users)
            {
                if (Email == user.Email)
                {
                    user.Email = Email;
                    user.Name = Username;
                    user.Birthday = Birthday;
                    await App.UserRepository.UpdateUser(user);
                    return;
                }
            }

            await App.Current.MainPage.DisplayAlert("Erro", "Usuário inexistente!", "OK");
            return;
        }

    }
}
