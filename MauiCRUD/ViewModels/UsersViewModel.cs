using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MauiCRUD.Models;
using MauiCRUD.Views;
using System.Collections.ObjectModel;

namespace MauiCRUD.ViewModels
{
    public partial class UsersViewModel : ObservableObject
    {
        [ObservableProperty]
        ObservableCollection<Users> listUsers;

        public static int Id { get; set; }

        public UsersViewModel()
        {
            ListUsers = new ObservableCollection<Users>();
        }

        [RelayCommand]
        public async Task TapDelete(Users user)
        {
            var confirm = await App.Current.MainPage.DisplayAlert("AVISO", "Excluir usuário?", "SIM", "NÃO");
            if (confirm)
            {
                await App.UserRepository.DeleteUser(user);
                await GetUsers();
            }
        }

        [RelayCommand]
        public async Task TapEdit(Users user)
        {
            Id = user.Id;
            await Shell.Current.GoToAsync($"//{nameof(EditView)}");
        }

        [RelayCommand]
        private async Task GetUsers()
        {
            var users = await App.UserRepository.GetAllUser();
            MapToObservableCollection(users);
        }

        private void MapToObservableCollection(List<Users> users)
        {
            ListUsers.Clear();
            foreach (var user in users)
            {
                ListUsers.Add(user);
            }
        }

        [RelayCommand]
        public async Task GoBack()
        {
            await Shell.Current.GoToAsync($"//{nameof(CrudView)}");
        }
    }
}
