using Firebase.Storage;
using Microsoft.Maui.Storage;
using Plugin.Firebase.Android;
using Plugin.Firebase.Storage;
using System.Diagnostics;
using System.Text;

namespace Itenet
{
    public static class StorageManager
    {
        public static async Task Upload()
        {
            var customFileType = new FilePickerFileType(
                new Dictionary<DevicePlatform, IEnumerable<string>>
                {
                    { DevicePlatform.iOS, new[] { "image/jpeg", "image/webp", "image/gif", "image/png" } }, 
                    { DevicePlatform.Android, new[] { "image/jpeg", "image/webp", "image/gif", "image/png" } } 
                });

            PickOptions options = new()
            {
                PickerTitle = "Selecciona una imagen",
                FileTypes = customFileType,
            };

            var result = await FilePicker.Default.PickAsync(options);

            if (result != null)
            {
                try
                {
                    Stream fileToUpload = await result.OpenReadAsync();
                    
                    var storage = CrossFirebaseStorage.Current.GetRootReference();

                    await storage
                         .GetChild($"{DateTime.Now.ToString("yyyyMMdd_HHmmss")}_{result.FileName}")
                         .PutStream(fileToUpload)
                         .AwaitAsync();
                }
                catch (Exception ex)
                {
                    Debug.WriteLine($"[Upload] {ex}");
                }
            }
        }
    }
}
