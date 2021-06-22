using System;
using System.Collections.Specialized;
using System.IO;
using System.Net;
using System.Text;
using Figgle;
using System.Threading;

namespace WebhookDeletorV1
{
	internal class Program
	{
		public static void Main(string[] args)
		{
			// Console.SetWindowSize(93, 19);
			Console.ForegroundColor = ConsoleColor.Blue;
			Console.Title = "[ DISCORD ] Webhook deleter / LOADING ...";

			Console.WriteLine(FiggleFonts.Rectangles.Render("WEBHOOK-DELETOR"));

			Console.Title = "[ DISCORD ] Webhook deleter";
			Console.ForegroundColor = ConsoleColor.Red;
			Console.Write("\n\nWebhook : ");
			string str = Console.ReadLine();
			Console.ForegroundColor = ConsoleColor.Yellow;
			string webhookurl = str;

			

			Program.deletewebhook(webhookurl, "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/85.0.4183.121 Safari/537.36");
			
			Thread.Sleep(700);

			Console.Title = "[ DISCORD ] Webhook deleter / LOADING ...";

			Thread.Sleep(700);

			Console.Clear();
			Console.Title = "[ DISCORD ] Webhook deleter / SUCCESS";
			Console.ForegroundColor = ConsoleColor.Magenta;
			Console.WriteLine(" ___ _   _  ___ ___ ___  ___ ___  ");
			Console.WriteLine("/ __| | | |/ __/ __/ _ \\/ __/ __|");
			Console.WriteLine("\\__ \\ |_| | (_| (_|  __/\\__ \\__ \\  ");
			Console.WriteLine("|___/\\____|\\___\\___\\___||___/___/ ");
			Console.ForegroundColor = ConsoleColor.Green;
			Thread.Sleep(100);
			Console.Write("\n WebHook : Good Deleted");
			Console.ReadKey();
		}

		public static string deletewebhook(string webhookurl, string UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/85.0.4183.121 Safari/537.36")
		{
			string result;
			try
			{
				HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(webhookurl);
				byte[] bytes = Encoding.ASCII.GetBytes("{}");
				httpWebRequest.Method = "DELETE";
				httpWebRequest.UserAgent = UserAgent;
				httpWebRequest.ContentLength = (long)bytes.Length;
				using (Stream requestStream = httpWebRequest.GetRequestStream())
				{
					requestStream.Write(bytes, 0, bytes.Length);
				}
				HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
				result = new StreamReader(httpWebResponse.GetResponseStream()).ReadToEnd();
			}
			catch (Exception ex)
			{
				Console.Clear();
				result = ex.ToString();
				Console.Write("Webhook invalid");
				
					Console.Beep();
					Console.Beep();
					Console.Beep();

				Console.ReadKey();
				Environment.Exit(0);
			}
			return result;
		}

		private static byte[] Post(string uri, NameValueCollection pairs)
		{
			byte[] result;
			using (WebClient webClient = new WebClient())
			{
				result = webClient.UploadValues(uri, pairs);
			}
			return result;
		}
	}
}
