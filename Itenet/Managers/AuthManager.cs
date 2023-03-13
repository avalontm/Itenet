using Itenet.Views;
using Plugin.Firebase.Auth;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Itenet
{
    public static class AuthManager
    {
        static ActionCodeSettings CreateActionCodeSettings()
        {
            var settings = new ActionCodeSettings();
            settings.Url = "https://itenet-25862.firebaseapp.com";
            settings.HandleCodeInApp = true;
            settings.IOSBundleId = "com.avalontm.itenet";
            settings.SetAndroidPackageName("com.avalontm.itenet", true, "21");
            return settings;
        }

        public static async Task<bool> Login()
        {
            try
            {
                await CrossFirebaseAuth.Current.SignInWithEmailAndPasswordAsync("avalontm22@gmail.com","cinder");

                return true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"[AuthManager] {ex}");
                return false;
            }
        }

        public static async Task<bool> Logout()
        {
            try
            {
                await CrossFirebaseAuth.Current.SignOutAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
