using Newtonsoft.Json;

namespace AuthExample.Models
{
    public class UserData
    {
        [JsonProperty("auth")]
        public bool Authenticated { get; set; }

        [JsonProperty("username")]
        public string Username { get; set; }

        [JsonProperty("posts")]
        public string Posts { get; set; }

        [JsonProperty("likes")]
        public string Likes { get; set; }

        [JsonProperty("group")]
        public string Group { get; set; }
    }
}
