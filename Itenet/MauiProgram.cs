using Microsoft.Extensions.Logging;
using Microsoft.Maui.LifecycleEvents;
using Plugin.Firebase.CloudMessaging;
using Plugin.Firebase.Shared;
using CommunityToolkit.Maui;
using Plugin.Firebase.Auth;
using Plugin.Firebase.Storage;


#if IOS
using Plugin.Firebase.iOS;
#endif
#if ANDROID
using Plugin.Firebase.Android;
#endif

namespace Itenet;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
            .RegisterFirebaseServices()
            .UseMauiCommunityToolkit()
            .ConfigureFonts(fonts =>
			{
                fonts.AddFont("Inter-Regular.ttf", "InterRegular");
                fonts.AddFont("Inter-SemiBold.ttf", "InterSemiBold");
                fonts.AddFont("Poppins-Bold.ttf", "PoppinsBold");
            });

#if DEBUG
		builder.Logging.AddDebug();
#endif

        Controls.BorderlessEntry.Configure();
        Controls.BorderlessEditor.Configure();

        return builder.Build();
	}

    private static MauiAppBuilder RegisterFirebaseServices(this MauiAppBuilder builder)
    {
        builder.ConfigureLifecycleEvents(events =>
        {
#if IOS
            events.AddiOS(iOS => iOS.FinishedLaunching((app, launchOptions) => {
                CrossFirebase.Initialize(app, launchOptions, CreateCrossFirebaseSettings());
                return false;
            }));
#endif
#if ANDROID
            events.AddAndroid(android => android.OnCreate((activity, state) =>
                CrossFirebase.Initialize(activity, state, CreateCrossFirebaseSettings())));
#endif
        });

#if __MOBILE__
        builder.Services.AddSingleton(_ => CrossFirebaseAuth.Current);
        builder.Services.AddSingleton(_ => CrossFirebaseCloudMessaging.Current);
        builder.Services.AddSingleton(_ => CrossFirebaseStorage.Current);
#endif
        return builder;
    }
#if __MOBILE__
    private static CrossFirebaseSettings CreateCrossFirebaseSettings()
    {
        return new CrossFirebaseSettings(isAuthEnabled: true, 
            isCloudMessagingEnabled: true, 
            isStorageEnabled: true);
    }
#endif
}
