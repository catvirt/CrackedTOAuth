using AuthExample.Models;
using AuthExample.Utils;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;

namespace AuthExample.AuthController
{
    public class Auth
    {

        private static readonly RequestHandler requestHandler = new();

        private static readonly GetUserHwid getHwid = new();

        public static async Task<UserData> DoAuthAsync(string key)
        {
            var dictionaryValue = new Dictionary<string, string>
            {
                  { "a", "auth" },
                  { "k", key },
                  { "hwid", getHwid.getUserHwid() }
            };

            var request = await requestHandler.SendAsync(httpMethod: HttpMethod.Post, dictionaryValue);

            return JsonConvert.DeserializeObject<UserData>(request);
        }
    }
}
