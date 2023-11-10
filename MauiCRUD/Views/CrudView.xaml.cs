using MauiCRUD.ViewModels;

namespace MauiCRUD.Views;

public partial class CrudView : ContentPage
{
	public CrudView(CrudViewModel viewModel)
	{
		InitializeComponent();

		this.BindingContext = viewModel;
	}
}