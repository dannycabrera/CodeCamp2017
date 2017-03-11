using Foundation;
using System;
using WatchKit;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using System.Linq;

namespace CodeCamp2017.WatchAppExtension
{
    public partial class DestinationController : WKInterfaceController
    {
        public DestinationController (IntPtr handle) : base (handle)
        {
        }

		string _uberType = "";

		async public override void WillActivate ()
		{
			await GetPriceEstimates (_uberType);
		}

		public override void Awake (NSObject context)
		{
			base.Awake (context);

			lblTypeCost.SetText ("Estimating...");
			lblMiles.SetText ("Miles:");
			lblTime.SetText ("Time:");

			_uberType = context.ToString ();
		}

		private async Task GetPriceEstimates (string uberType)
		{
			var estimates = await Util.PriceEstimates (Util.start, Util.destination);
			//var estimates = "{\"prices\":[{\"localized_display_name\":\"uberX\",\"high_estimate\":6,\"minimum\":5,\"duration\":420,\"estimate\":\"$5-6\",\"distance\":1.66,\"display_name\":\"uberX\",\"product_id\":\"4dc6c333-0b25-4605-8806-c8cf88adb1f5\",\"low_estimate\":5,\"surge_multiplier\":1.0,\"currency_code\":\"USD\"},{\"localized_display_name\":\"uberPOOL\",\"high_estimate\":5,\"minimum\":null,\"duration\":420,\"estimate\":\"$4.50\",\"distance\":1.66,\"display_name\":\"uberPOOL\",\"product_id\":\"90384182-0269-4564-827d-e3c42c0eb83b\",\"low_estimate\":4,\"surge_multiplier\":1.0,\"currency_code\":\"USD\"},{\"localized_display_name\":\"uberXL\",\"high_estimate\":11,\"minimum\":8,\"duration\":420,\"estimate\":\"$8-11\",\"distance\":1.66,\"display_name\":\"uberXL\",\"product_id\":\"855e99ac-b151-49b8-a3ba-eb5c35e07d8e\",\"low_estimate\":8,\"surge_multiplier\":1.0,\"currency_code\":\"USD\"},{\"localized_display_name\":\"LUX\",\"high_estimate\":13,\"minimum\":11,\"duration\":420,\"estimate\":\"$10-13\",\"distance\":1.66,\"display_name\":\"LUX\",\"product_id\":\"9b248879-bac1-417a-a3f2-cd9cd13a1a2e\",\"low_estimate\":10,\"surge_multiplier\":1.0,\"currency_code\":\"USD\"},{\"localized_display_name\":\"LUX SUV\",\"high_estimate\":26,\"minimum\":26,\"duration\":420,\"estimate\":\"$25-26\",\"distance\":1.66,\"display_name\":\"LUX SUV\",\"product_id\":\"56e6cb82-409d-4ec5-9264-bd14eac9f83c\",\"low_estimate\":25,\"surge_multiplier\":1.0,\"currency_code\":\"USD\"}]}";

			JObject json = JObject.Parse (estimates);
			JArray prices = (JArray)json ["prices"];

			var uber = prices.Where (p => p ["localized_display_name"].ToString () == uberType).FirstOrDefault ();

			int totalSeconds = Convert.ToInt32 (uber ["duration"].ToString ());
			int minutes = totalSeconds / 60;

			lblTypeCost.SetText (string.Format ("{0}: {1}", uberType, uber ["estimate"]));
			lblMiles.SetText (string.Format ("Miles: {0}", uber ["distance"]));
			lblTime.SetText (string.Format ("Time: {0}", minutes));
		}
    }
}