using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Services.Description;
using System.Web.Services.Protocols;

namespace TitanAPI.Web
{
    internal class AuthenticationWebService : WebService
    {
        [SoapDocumentMethod("http://tempuri.org/LogonAuthentication", RequestNamespace = "http://tempuri.org/", ResponseNamespace = "http://tempuri.org/", Use = SoapBindingUse.Literal, ParameterStyle = SoapParameterStyle.Wrapped)]
        public string LogonAuthentication(string logonID, string password, string userMachine, string dealerIDStr, string currentLanguage, string clientUtcOffset, string windowsIdentity, int employeeLogonKey)
        {
            return (string)Invoke("LogonAuthentication", new object[8] { logonID, password, userMachine, dealerIDStr, currentLanguage, clientUtcOffset, windowsIdentity, employeeLogonKey })[0];
        }
    }
}
