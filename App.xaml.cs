using RecipeVault.Interfaces;

namespace RecipeVault;

public partial class App : Application
{
    private readonly ILocalDatabaseService _db;

    public App(AppShell shell, ILocalDatabaseService db)
    {
        InitializeComponent();
        _db      = db;
        MainPage = shell;
    }

    protected override async void OnStart()
    {
        base.OnStart();
        // Ensure local DB is ready before any ViewModel tries to use it
        await _db.InitAsync();
    }
}
