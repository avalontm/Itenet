using Firebase.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public static async Task<List<FirebaseObject<T>>> Get<T>(string name)
        {
            var items = await firebaseClient.Child(name).OnceAsync<T>();
            return items.ToList();
        }
    }
}
