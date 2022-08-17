using Microsoft.VisualBasic.Devices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TitanAPI.Encryption;
using TitanAPI.Web;

namespace TitanAPI.API
{
    public struct LoginCredentials
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string DealerID { get; set; }
    }

    public class Login
    {
        private static AuthenticationWebServiceWrapper authentication = new AuthenticationWebServiceWrapper();

        public static string Logon(LoginCredentials credentials)
        {
            string userid = credentials.UserName;
            string password = credentials.Password;
            string dealerid = credentials.DealerID;

            Version version = Utils.Utilities.GetHighestDotNetVersionFromRegistry() ?? new Version("0.0");
            ComputerInfo computerInfo = new ComputerInfo();
            string servicePack = Environment.OSVersion.ServicePack;
            string text = $"{computerInfo.OSFullName} [{servicePack}]".Replace("[]", string.Empty).Trim();
            Screen primaryScreen = Screen.PrimaryScreen;
            int num = primaryScreen?.Bounds.Width ?? (-1);
            int num2 = primaryScreen?.Bounds.Height ?? (-1);
            int num3 = ((Screen.AllScreens != null) ? Screen.AllScreens.Length : (-1));
            string machine = string.Concat(Environment.MachineName, ";", version, ";", text, ";", Environment.ProcessorCount, ";", computerInfo.TotalPhysicalMemory / 1024uL / 1024uL, ";", Assembly.GetEntryAssembly().GetName().Name, ";", num, ";", num2, ";", num3);

            TimeSpan utcOffset = TimeZone.CurrentTimeZone.GetUtcOffset(DateTime.Now);
            authentication.Url = WebService.GetWebServerEndpoint("Authentication");
            authentication.Timeout = 1000000;
            authentication.KeepAlive = true;

            string logonResponse = authentication.LogonAuthentication(CustomEncryption.Encrypt(userid),
                CustomEncryption.Encrypt(password),
                CustomEncryption.Encrypt(machine),
                CustomEncryption.Encrypt(dealerid),
                string.Empty,
                utcOffset.Ticks.ToString(),
                CustomEncryption.Encrypt(WindowsIdentity.GetCurrent().Name),
                -1);

            return logonResponse;
        }
    }
}
