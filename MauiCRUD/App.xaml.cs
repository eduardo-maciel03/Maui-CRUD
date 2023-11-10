using MauiCRUD.Repositories;

namespace MauiCRUD
{
    public partial class App : Application
    {
        public static IUserRepository UserRepository { get; private set; }
        public App(IUserRepository userRepository)
        {
            InitializeComponent();

            MainPage = new AppShell();

            UserRepository = userRepository;
        }
    }
}