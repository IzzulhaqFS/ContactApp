using ContactApp.Repositories;
using ContactApp.ViewModels;
using ContactApp.Views;
using Microsoft.Extensions.Logging;

namespace ContactApp;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

		string dbPath = FileAccessHelper.GetLocalFilePath("contact.db3");
		builder.Services.AddSingleton(s => ActivatorUtilities.CreateInstance<ContactRepository>(s, dbPath));
		builder.Services.AddSingleton<ContactsPageViewModel>();
		builder.Services.AddSingleton<ContactsPage>();

        return builder.Build();
	}
}
