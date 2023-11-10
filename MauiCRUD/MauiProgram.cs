using CommunityToolkit.Maui;
using MauiCRUD.Models;
using MauiCRUD.Repositories;
using MauiCRUD.ViewModels;
using MauiCRUD.Views;
using Microsoft.Extensions.Logging;

namespace MauiCRUD
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseMauiCommunityToolkit()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

#if DEBUG
		builder.Logging.AddDebug();
#endif
            builder.Services.AddSingleton<Users>();

            builder.Services.AddSingleton<IUserRepository, UserRepository>();

            builder.Services.AddSingleton<CrudView>();
            builder.Services.AddSingleton<CrudViewModel>();

            builder.Services.AddSingleton<UsersView>();
            builder.Services.AddSingleton<UsersViewModel>();

            builder.Services.AddSingleton<EditView>();
            builder.Services.AddSingleton<EditViewModel>();

            return builder.Build();
        }
    }
}