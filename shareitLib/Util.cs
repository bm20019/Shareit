namespace shareitLib;

using System.Net;
using System.Net.NetworkInformation;

public class Util
{
    public Util()
    {
    }

    public static IPAddress GetIPAddress()
    {
        var networkInterfaces = NetworkInterface.GetAllNetworkInterfaces();
        foreach (var networkInterface in networkInterfaces)
        {
            var ipProperties = networkInterface.GetIPProperties();
            var unicastAddresses = ipProperties.UnicastAddresses;

            foreach (var unicastAddress in unicastAddresses)
            {
                if (!IPAddress.IsLoopback(unicastAddress.Address) && unicastAddress.Address.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                {
                    var ipAddress = unicastAddress.Address;
                    return ipAddress;
                }
            }
        }
        return System.Net.IPAddress.Parse("127.0.0.1");
    }
}
