using AuthExample.Models;
using Newtonsoft.Json;
using System.IO;
using System.Threading.Tasks;

namespace AuthExample.Utils
{
    public class KeySaveGrab
    {
        public static async Task SaveKeyAsync(string path, string key)
        {
            var keySaveHandler = JsonConvert.SerializeObject(
                new Key
                {
                   KeyAuth = key
                }, Formatting.Indented
            );
            await File.AppendAllTextAsync(path, keySaveHandler);
        }
        public static Key GetKey(string path) => JsonConvert.DeserializeObject<Key>(
            File.ReadAllText(path)
        );
    }
}
