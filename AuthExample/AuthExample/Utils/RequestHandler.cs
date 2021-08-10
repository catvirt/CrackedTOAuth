using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace AuthExample.Utils
{
    public class RequestHandler
    {
        private readonly string _crackedToAdress = "https://cracked.to/auth.php";
        public async Task<string> SendAsync(HttpMethod httpMethod, Dictionary<string, string> postData = null)
        {
            if (postData is null)
            {
                throw new ArgumentNullException(nameof(postData));
            }

            var httpClient = new HttpClient(new HttpClientHandler()
            {
                UseCookies = false,
                AllowAutoRedirect = true
            })
            {
                Timeout = TimeSpan.FromSeconds(30)
            };

            using var sendRequest = new HttpRequestMessage(httpMethod, new Uri(_crackedToAdress))
            {
                Content = new FormUrlEncodedContent(postData)
            };

            var response = await httpClient.SendAsync(sendRequest);

            return await response.Content.ReadAsStringAsync();
        }
    }
}
