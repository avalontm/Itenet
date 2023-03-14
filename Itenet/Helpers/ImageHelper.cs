using Plugin.Firebase.Firestore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Itenet
{
    public static class ImageHelper
    {
        public static Stream ToStream(this ImageSource source)
        {
            if (source is StreamImageSource)
            {
               return ((StreamImageSource)source).Stream(CancellationToken.None).Result;
            }

            return new MemoryStream();
        }
    }
}
