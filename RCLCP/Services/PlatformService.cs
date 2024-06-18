
using Microsoft.Maui.Devices;
using RCLCP.Interfaces;

namespace RCLCP.Services
{
    public class PlatformService : IPlatformService
    {
        public string GetPlatform()
        {

            if (DeviceInfo.Platform == DevicePlatform.Android)
            {
                return "Android";
            }
            else if (DeviceInfo.Platform == DevicePlatform.iOS)
            {
                return "iOS";
            }
            else if (DeviceInfo.Platform == DevicePlatform.WinUI)
            {
                return "Windows";
            }
            else
            {
                return "Unknown";
            }

        }
    }
}
