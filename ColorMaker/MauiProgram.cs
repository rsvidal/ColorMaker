using CommunityToolkit.Maui;

namespace ColorMaker;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();

		// RSV. Initialize toolkit
		// Se añade este complemento "CommunityTooklit.Maui" (Descargado e incluido en el proyecto desde Nuget)		
		// En esta aplicación se usa este complemento para usar la clase "Toast"
        builder.UseMauiApp<App>().UseMauiCommunityToolkit();

        builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

		return builder.Build();
	}
}
