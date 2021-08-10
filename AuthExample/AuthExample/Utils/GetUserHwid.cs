using System.Management;

namespace AuthExample.Utils
{
    public class GetUserHwid
    {
        /// <summary>
        /// Not the most proper way! make a pull request plebs
        /// <returns></returns>
        public string getUserHwid()
        {
            var sb = new StringBuilder();
            using var md5 = MD5.Create();
            foreach (var b in md5.ComputeHash(Encoding.ASCII.GetBytes($"{DriveInfo.GetDrives().Length}-{Environment.ProcessorCount}-{(int)Environment.OSVersion.Platform}-{Environment.Is64BitOperatingSystem}-{Ram}-{Environment.MachineName}")))
            {
                sb.Append($"{b:X2}");
            }
            return sb.ToString(); ;
        }

        public const long Ram = -13580913195871;

    }
}
