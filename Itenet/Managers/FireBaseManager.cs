using FastMember;
using Firebase.Database;
using Firebase.Database.Query;
using Microsoft.Maui;
using Newtonsoft.Json;
using System.Diagnostics;
using static Android.Content.ClipData;

namespace Itenet
{
    public static class FireBaseManager
    {
        static FirebaseClient firebaseClient { set; get; }

        public static void Init()
        {
            var auth = "SYJM5x1e8ieh71wKw9XUkCPORg3s7sHX9zM4c09A"; // your app secret
            firebaseClient = new FirebaseClient(
              "https://itenet-25862-default-rtdb.firebaseio.com/",
              new FirebaseOptions
              {
                  AuthTokenAsyncFactory = () => Task.FromResult(auth)
              });
        }

        public static async Task<T> Get<T>(string name, int start = 1, int limit = 10)
        {
            List<object> items = new List<object>();
            var response = await firebaseClient.Child(name).OrderByKey().LimitToLast(limit).OnceAsync<object>();

            foreach (var item in response)
            {
                ObjectAccessor wrapped = ObjectAccessor.Create(item.Object);
                wrapped["id"] = item.Key;
                items.Add(item.Object);
            }

            items.Reverse();    
            Debug.WriteLine($"[ITEMS] {JsonConvert.SerializeObject(items)}");

            return JsonConvert.DeserializeObject<T>(JsonConvert.SerializeObject(items));
        }

        public static async Task<T> Post<T>(string name, T data)
        {
            var response = await firebaseClient.Child(name).PostAsync<T>(data);

            ObjectAccessor wrapped = ObjectAccessor.Create(response.Object);
            wrapped["id"] = response.Key;
            Debug.WriteLine($"[ITEM] {JsonConvert.SerializeObject(response.Object)}");
            return response.Object;
        }
    }
}
