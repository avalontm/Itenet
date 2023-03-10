using Firebase.Auth;
using Firebase.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Itenet.Managers
{
    public static class StorageManager
    {
        public static async Task Upload()
        {
            /*
            // Get any Stream - it can be FileStream, MemoryStream or any other type of Stream
            var stream = File.Open(@"C:\Users\you\file.png", FileMode.Open);
       
                  //authentication
                  var auth = new FirebaseAuthProvider(new FirebaseConfig("api_key"));
            var a = await auth.SignInWithEmailAndPasswordAsync("email", "password");

            // Constructr FirebaseStorage, path to where you want to upload the file and Put it there
            var task = new FirebaseStorage(
                "gs://itenet-25862.appspot.com",

                 new FirebaseStorageOptions
                 {
                     AuthTokenAsyncFactory = () => Task.FromResult(a.FirebaseToken),
                     ThrowOnCancel = true,
                 })
                .Child("data")
                .Child("random")
                .Child("file.png")
                .PutAsync(stream);

            // Track progress of the upload
            task.Progress.ProgressChanged += (s, e) => Console.WriteLine($"Progress: {e.Percentage} %");

            // await the task to wait until upload completes and get the download url
            var downloadUrl = await task;
            */
            
        }
    }
}
