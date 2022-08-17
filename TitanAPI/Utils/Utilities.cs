using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TitanAPI.Utils
{
    internal class Utilities
    {
		public static Version GetHighestDotNetVersionFromRegistry()
		{
			List<Version> list = new List<Version>();
			try
			{
				RegistryKey registryKey = RegistryKey.OpenRemoteBaseKey(RegistryHive.LocalMachine, string.Empty).OpenSubKey("SOFTWARE\\Microsoft\\NET Framework Setup\\NDP\\");
				string[] subKeyNames = registryKey.GetSubKeyNames();
				foreach (string text in subKeyNames)
				{
					if (!text.StartsWith("v") || text.StartsWith("v1"))
					{
						continue;
					}
					RegistryKey registryKey2 = registryKey.OpenSubKey(text);
					string text2 = (string)registryKey2.GetValue("Version", string.Empty);
					string text3 = registryKey2.GetValue("SP", string.Empty).ToString();
					string text4 = registryKey2.GetValue("Install", string.Empty).ToString();
					if (text4 != string.Empty && text3 != string.Empty && text4 == "1")
					{
						Version item = new Version(text2);
						if (!list.Contains(item))
						{
							list.Add(item);
						}
					}
					if (text2 != "")
					{
						continue;
					}
					string[] subKeyNames2 = registryKey2.GetSubKeyNames();
					foreach (string name in subKeyNames2)
					{
						RegistryKey registryKey3 = registryKey2.OpenSubKey(name);
						text2 = (string)registryKey3.GetValue("Version", string.Empty);
						if (text2 != string.Empty)
						{
							text3 = registryKey3.GetValue("SP", string.Empty).ToString();
						}
						text4 = registryKey3.GetValue("Install", string.Empty).ToString();
						if (!(text4 != string.Empty))
						{
							continue;
						}
						if (text3 != "" && text4 == "1")
						{
							Version item2 = new Version(text2);
							if (!list.Contains(item2))
							{
								list.Add(item2);
							}
						}
						else if (text4 == "1")
						{
							Version item3 = new Version(text2);
							if (!list.Contains(item3))
							{
								list.Add(item3);
							}
						}
					}
				}
			}
			catch
			{
			}
			if (list.Count > 0)
			{
				list.Sort();
				return list[list.Count - 1];
			}
			return null;
		}
	}
}
