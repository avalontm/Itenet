using Plugin.Firebase.Storage;
using System.Diagnostics;
using System.Text;

namespace Itenet
{
    public static class StorageManager
    {
        public static async Task<string> Upload(Stream stream)
        {
            try
            {
                var storage = CrossFirebaseStorage.Current.GetRootReference();
                string File = $"{DateTime.Now.ToString("yyyyMMdd_HHmmss")}_{RandomDigits()}.png";

                await storage
                     .GetChild(File)
                     .PutStream(stream)
                     .AwaitAsync();

                return await storage.GetChild(File).GetDownloadUrlAsync();
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"[Upload] {ex}");
                return string.Empty;
            }
        }

        public static string RandomDigits(int length = 10)
        {
            var random = new Random();
            string s = string.Empty;
            for (int i = 0; i < length; i++)
                s = String.Concat(s, random.Next(10).ToString());
            return s;
        }
    }
}
