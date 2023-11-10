using MauiCRUD.ViewModels;

namespace MauiCRUD.Views;

public partial class EditView : ContentPage
{
	EditViewModel viewModel;
	public EditView(EditViewModel viewModel)
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