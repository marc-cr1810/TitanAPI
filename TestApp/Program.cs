using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TitanAPI.API;

namespace TestApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            LoginCredentials credentials;
            Console.Write("Titan Username: ");
            credentials.UserName = Console.ReadLine();
            Console.Write("Titan Password: ");
            credentials.Password = Console.ReadLine();
            credentials.DealerID = "Janrule";

            string result = Login.Logon(credentials);
            Console.WriteLine(result);

            while (true) { }
        }
    }
}
