using MauiCRUD.ViewModels;

namespace MauiCRUD.Views;

public partial class UsersView : ContentPage
{
	UsersViewModel viewModel;
	public UsersView(UsersViewModel viewModel)
	{
		InitializeComponent();
		this.BindingContext = this.viewModel = viewModel;
	}

    protected override void OnAppearing()
    {
        base.OnAppearing();
		viewModel.GetUsersCommand.Execute(null);
    }

}