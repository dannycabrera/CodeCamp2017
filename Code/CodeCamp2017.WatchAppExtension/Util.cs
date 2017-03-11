using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace CodeCamp2017.WatchAppExtension
{
	public static class Util
	{
		static string Token = "<SERVER TOKEN>";
		public static Model.Location start = new Model.Location () { Lat = "26.080343", Lon = "-80.242017" }; //nova
		public static Model.Location destination = new Model.Location () { Lat = "", Lon = "" };

		public static async Task<string> TimeEstimates (Model.Location start)
		{
			Console.WriteLine ("Getting time estimates...");

			using (HttpClient client = new HttpClient ()) {
				client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue ("Token", Token);
				var url = string.Format ("https://api.uber.com/v1/estimates/time?start_latitude={0}&start_longitude={1}", start.Lat, start.Lon);
				var json = await client.GetStringAsync (url);

				return json;
			}
		}

		public static async Task<string> PriceEstimates (Model.Location start, Model.Location destination)
		{
			Console.WriteLine ("Getting price estimates...");

			using (HttpClient client = new HttpClient ()) {
				client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue ("Token", Token);
				var url = string.Format ("https://api.uber.com/v1/estimates/price?start_latitude={0}&start_longitude={1}&end_latitude={2}&end_longitude={3}"
											, start.Lat, start.Lon, destination.Lat, destination.Lon);
				var json = await client.GetStringAsync (url);

				return json;
			}
		}
	}
}
