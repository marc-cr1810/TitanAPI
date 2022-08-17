using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace TitanAPI.Web
{
    internal class AuthenticationWebServiceWrapper : AuthenticationWebService
    {
		private bool _keepAlive = true;

		public bool KeepAlive
		{
			get
			{
				return _keepAlive;
			}
			set
			{
				_keepAlive = value;
			}
		}

		protected override WebRequest GetWebRequest(Uri uri)
		{
			HttpWebRequest httpWebRequest = (HttpWebRequest)base.GetWebRequest(uri);
			httpWebRequest.KeepAlive = _keepAlive;
			if (!_keepAlive)
			{
				httpWebRequest.ProtocolVersion = HttpVersion.Version10;
			}
			//httpWebRequest.Proxy = ClientSecurityManager.Proxy;
			return httpWebRequest;
		}
	}
}
