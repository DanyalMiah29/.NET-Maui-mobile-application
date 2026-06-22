using Microsoft.Extensions.Logging;
using RecipeVault.Interfaces;
using RecipeVault.Services;
using RecipeVault.ViewModels;
using RecipeVault.Views;

namespace RecipeVault;

/// <summary>
/// Application bootstrap – registers all services, ViewModels and Views with the
/// built-in .NET MAUI DI container (IServiceCollection / IoC).
///
/// Design patterns demonstrated:
///   • Dependency Injection (IoC)  – IServiceCollection
///   • Singleton pattern           – auth and database services
///   • Factory Method              – AddTransient / AddSingleton
///   • Repository Pattern          – ILocalDatabaseService
///   • Strategy Pattern            – IRecipeApiService (swappable implementation)
/// </summary>
public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();

		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf",  "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

		// ── HttpClient (shared instance) ─────────────────────────────────────
		builder.Services.AddSingleton<HttpClient>();

		// ── Services (Singletons – stateful, shared session data) ────────────
		builder.Services.AddSingleton<IAuthService,          FirebaseAuthService>();
		builder.Services.AddSingleton<ILocalDatabaseService, LocalDatabaseService>();
		builder.Services.AddSingleton<IFirestoreService,     FirestoreService>();
		builder.Services.AddSingleton<IRecipeApiService,     MealDbApiService>();

		// ── ViewModels (Transient – new instance per page navigation) ─────────
		builder.Services.AddTransient<LoginViewModel>();
		builder.Services.AddTransient<RegisterViewModel>();
		builder.Services.AddTransient<HomeViewModel>();
		builder.Services.AddTransient<RecipeBrowseViewModel>();
		builder.Services.AddTransient<RecipeDetailViewModel>();
		builder.Services.AddTransient<FavoritesViewModel>();
		builder.Services.AddTransient<MealPlanViewModel>();
		builder.Services.AddTransient<ShoppingListViewModel>();
		builder.Services.AddTransient<ProfileViewModel>();

		// ── Views ─────────────────────────────────────────────────────────────
		builder.Services.AddTransient<LoginPage>();
		builder.Services.AddSingleton<AppShell>();
		builder.Services.AddTransient<RegisterPage>();
		builder.Services.AddTransient<HomePage>();
		builder.Services.AddTransient<RecipeBrowsePage>();
		builder.Services.AddTransient<RecipeDetailPage>();
		builder.Services.AddTransient<FavoritesPage>();
		builder.Services.AddTransient<MealPlanPage>();
		builder.Services.AddTransient<ShoppingListPage>();
		builder.Services.AddTransient<ProfilePage>();

#if DEBUG
		builder.Logging.AddDebug();
#endif

		return builder.Build();
	}
}
