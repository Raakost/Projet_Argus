using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ArgusCore.Gatherers.Utils
{
    public class WebHandler
    {
        private int maxTryCount = 5;
        private int tryCount = 0;

        public WebHandler()
        {
        }
        // Downloads url to a string and returns it.
        public string DownloadString(string url)
        {
            string data = "";
            using (var client = new WebClient())
            {
                try
                {
                    client.Encoding = Encoding.UTF8;
                    data = client.DownloadString(url);
                }
                catch (ArgumentNullException)
                {
                    return data;
                }
                catch (NotSupportedException)
                {
                    return data;
                }
                catch (WebException ex)
                {
                    if (ex.Status == WebExceptionStatus.ProtocolError && ex.Response != null)
                    {
                        var resp = (HttpWebResponse)ex.Response;
                        if (resp.StatusCode == HttpStatusCode.NotFound)
                        {
                            // If a 404 error is caught. 
                            // The retry counter is increased and retries the download after 15 seconds.
                            if (tryCount < maxTryCount)
                            {
                                tryCount = tryCount + 1;
                                Thread.Sleep(15 * 1000);
                                DownloadString(url);
                            }
                            else if (tryCount >= maxTryCount)
                            {
                                // If the max retries have been exceeded a WebException is thrown.
                                tryCount = 0;
                                throw new WebException();
                            }
                        }
                    }
                    return data;
                }
            }
            tryCount = 0;
            return data;
        }

    }
}
