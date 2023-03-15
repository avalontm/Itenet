namespace Itenet
{
    public static class ImageHelper
    {
        public static async Task<Stream> ToStream(this ImageSource source)
        {
            var _source = await ((StreamImageSource)source).Stream(CancellationToken.None);

            using (MemoryStream ms = new MemoryStream())
            {
                _source.CopyTo(ms);
                _source.Dispose();
                return new MemoryStream(ms.ToArray());
            }
        }

        public static ImageSource FromArray(this byte[] source)
        {
            return ImageSource.FromStream(() =>
            {
                return new MemoryStream(source);
            });
        }

        public static byte[] ToArray(this Stream source)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                source.CopyTo(ms);
                source.Dispose();
                return ms.ToArray();
            }
        }
    }
}
