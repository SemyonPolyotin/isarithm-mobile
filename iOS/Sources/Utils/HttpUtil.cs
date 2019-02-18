using System;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;
using Foundation;
using UIKit;

namespace Isarithm.Mobile.iOS.Sources.Utils
{
    public static class HttpUtil
    {
        public static async Task<UIImage> LoadImage(string imageUrl)
        {
            var httpClient = new HttpClient();
            // TODO: Catch uri exceptions
            var uri = new Uri(imageUrl);
            try
            {
                var content = await httpClient.GetByteArrayAsync(uri).ConfigureAwait(false);
                return UIImage.LoadFromData(NSData.FromArray(content));
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
            }

            return null;
        }
    }
}