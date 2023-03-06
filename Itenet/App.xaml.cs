using Plugin.Firebase.CloudMessaging;
using System.Diagnostics;

namespace Itenet;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();
        FireBaseManager.Init();
        MainPage = new AppShell();
	}

    protected override void OnStart()
    {
        base.OnStart();
        Debug.WriteLine($"[OnStart]");

#if __MOBILE__
        CrossFirebaseCloudMessaging.Current.NotificationTapped += Current_NotificationTapped;
        CrossFirebaseCloudMessaging.Current.Error += Current_Error;
        CrossFirebaseCloudMessaging.Current.TokenChanged += Current_TokenChanged;
#endif
        onToken();
    }

    async Task onToken()
    {
#if __MOBILE__
        string token = await CrossFirebaseCloudMessaging.Current.GetTokenAsync();
        string model = DeviceInfo.Current.Model;
        string name = DeviceInfo.Current.Name;
        string platform = DeviceInfo.Current.Platform.ToString();

        Debug.WriteLine($"[FCM TOKEN] {token}");
#endif
    }

#if __MOBILE__
    private void Current_NotificationTapped(object sender, Plugin.Firebase.CloudMessaging.EventArgs.FCMNotificationTappedEventArgs e)
    {
        Debug.WriteLine($"[FCM ERROR] {e.Notification.Title}");
    }


    private void Current_Error(object sender, Plugin.Firebase.CloudMessaging.EventArgs.FCMErrorEventArgs e)
    {
        Debug.WriteLine($"[FCM ERROR] {e.Message}");
    }

    private void Current_TokenChanged(object sender, Plugin.Firebase.CloudMessaging.EventArgs.FCMTokenChangedEventArgs e)
    {
        Debug.WriteLine($"[FCM TOKEN] {e.Token}");
    }
#endif
}
