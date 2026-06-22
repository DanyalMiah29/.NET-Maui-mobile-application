using RecipeVault.Views;

namespace RecipeVault;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();

        // Register modal / detail routes (not in flyout)
        Routing.RegisterRoute("recipeDetail", typeof(RecipeDetailPage));
        Routing.RegisterRoute("register",     typeof(RegisterPage));
    }
}
