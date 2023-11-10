using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MauiCRUD.Views;

namespace MauiCRUD.ViewModels
{
    public partial class EditViewModel : ObservableObject
    {
        [ObservableProperty]
        string username;
        [ObservableProperty]
        string email;
        [ObservableProperty]
        DateTime birthday;

        [RelayCommand]
        private async Task GetUsers()
        {
            var users = await App.UserRepository.GetAllUser();

            foreach (var user in users)
            {
                if (user.Id == UsersViewModel.Id)
                {
                    Username = user.Name;
                    Email = user.Email;
                    Birthday = user.Birthday;
                }
            }
        }

        [RelayCommand]
        public async Task Save()
        {
            var users = await App.UserRepository.GetAllUser();

            foreach(var user in users)
            {
                if(user.Id == UsersViewModel.Id)
                {
                    user.Name = Username; 
                    user.Email = Email;
                    user.Birthday = Birthday;

                    await App.UserRepository.UpdateUser(user);
                    await Toast.Make("Usuário alterado!").Show();
                    Username = null;
                    Email = null;
                    Birthday = DateTime.Now;
                    await Shell.Current.GoToAsync($"//{nameof(UsersView)}");
                }
            }
        }

        [RelayCommand]
        public async Task Cancel()
        {
            await Shell.Current.GoToAsync($"//{nameof(UsersView)}");
        }
    }
}
