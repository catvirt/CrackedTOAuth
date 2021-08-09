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
            var mbs = new ManagementObjectSearcher("Select ProcessorId From Win32_processor");

            var mbsList = mbs.Get();

            foreach (var mo in mbsList)
            {
                return mo["ProcessorId"].ToString();
            }

            return null;
        }

    }
}
