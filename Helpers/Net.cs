using System;
using System.IO;
using System.Net;
using System.Text;

namespace SPACEBAR
{
	using System.Linq;

	/// <summary>
	/// Classe helper qui download des informations des tubes
	/// </summary>
	public static class Net
	{
		/// <summary>
		/// Se connecte sur une page web et retourne le HTML en string
		/// </summary>
		/// <param name="url">URL du site à aller chercher</param>
		/// <returns>Le code HTML du site</returns>
		public static string DownloadHTML(string url)
		{
			try
			{
				WebClient webClient = new WebClient();
				byte[] myDatabuffer = webClient.DownloadData(url);
				return Encoding.Default.GetString(myDatabuffer);
			}
			catch (Exception ex)
			{
				throw new Exception("Error while downloading HTML: " + ex.Message);
			}
		}

		/// <summary>
		/// Se connecte sur une page web et retourne le HTML en string
		/// </summary>
		/// <param name="url">URL du site à aller chercher</param>
		/// <param name="username">Nom d'utilisateur pour se connecter au site</param>
		/// <param name="password">Mot de passe pour se connecter au site</param>
		/// <returns>Le code HTML du site</returns>
		public static string DownloadHTML(string url, string username, string password)
		{
			try
			{
				var webClient = new WebClient();

				// Credentials management
				var cache = new CredentialCache();
				cache.Add(new Uri(url), "Basic", new NetworkCredential(username, password));
				webClient.Credentials = cache;

				byte[] myDatabuffer = webClient.DownloadData(url);
				return Encoding.Default.GetString(myDatabuffer);
			}
			catch (Exception ex)
			{
				throw new Exception("Error while downloading HTML: " + ex.Message);
			}
		}

		/// <summary>
		/// Download un fichier
		/// </summary>
		/// <param name="url">URL du fichier à downloader</param>
		/// <param name="fileName">Chemin où enregistrer le fichier</param>
		public static void DownloadFile(string url, string fileName)
		{
			var webClient = new WebClient();
			webClient.DownloadFile(url, fileName);
		}

		public static bool DoesUrlExists(string url)
		{
			try
			{
				WebRequest req = WebRequest.Create(url);
				HttpWebResponse response = (HttpWebResponse)req.GetResponse();
				
				// Si ça a pas planté, c'est que ça marche!
				return true;
			}
			catch (System.Net.WebException ex)
			{
				// Fail
				return false;
			}
		}

		/// <summary>
		/// Retourne l'adresse IP locale
		/// </summary>
		/// <param name="Get_LAN_IP">true si on veut l'adresse internet, false si on veut celle visible de l'internet</param>
		/// <returns></returns>
		public static string GetIPAdress(bool Get_LAN_IP)
		{
			if (Get_LAN_IP)
			{
				// http://agiledeveloper.wordpress.com/2007/05/20/obtaining-local-ip-address-in-c/
				var localIP = "";
				var host = Dns.GetHostEntry(Dns.GetHostName());
				foreach (var ip in host.AddressList.Where(ip => ip.AddressFamily.ToString() == "InterNetwork"))
				{
					localIP = ip.ToString();
				}
				return localIP;
			}
			else
			{
				const string IPDetectingSite = "http://www.ipchicken.com/";
				const string IpRegex = @"\b(?:[0-9]{1,3}\.){3}[0-9]{1,3}\b";

				var WebClient = new WebClient();
				var UTF8 = new UTF8Encoding();
				var HtmlCode = "";
				try
				{
					HtmlCode = UTF8.GetString(WebClient.DownloadData(IPDetectingSite));
				}
				catch (WebException e)
				{
					Console.Write(e.ToString());
				}

				var m = new System.Text.RegularExpressions.Regex(IpRegex).Match(HtmlCode);

				return m.Value;
			}
		}


	}
}
