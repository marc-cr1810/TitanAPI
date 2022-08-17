using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Services;
using System.Web.Services.Protocols;

namespace TitanAPI.Web
{
	[WebServiceBinding(Name = "AuthenticationWebServiceSoap", Namespace = "http://tempuri.org/")]
	internal class WebService : SoapHttpClientProtocol
	{
		public static readonly string WebServer = "au-web-03.titandms.net.au";

		public static string GetWebServerEndpoint(string asmxEndpointName)
        {
			return (WebServer.StartsWith("http") ? WebServer : ("https://" + WebServer)) + "/Titan1.36.13.0/WebServices/" + 
				(asmxEndpointName.EndsWith(".asmx") ? asmxEndpointName : asmxEndpointName + ".asmx");
		}

		public new string Url
		{
			get
			{
				return base.Url;
			}
			set
			{
				base.Url = value;
			}
		}

		private bool IsLocalFileSystemWebService(string url)
		{
			if (url == null || url == string.Empty)
			{
				return false;
			}
			Uri uri = new Uri(url);
			if (uri.Port >= 1024 && string.Compare(uri.Host, "localHost", StringComparison.OrdinalIgnoreCase) == 0)
			{
				return true;
			}
			return false;
		}
	}
}
