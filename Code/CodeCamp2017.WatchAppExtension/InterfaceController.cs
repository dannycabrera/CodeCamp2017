using System;
using System.Collections.Generic;
using WatchKit;
using Foundation;

namespace CodeCamp2017.WatchAppExtension
{
	public partial class InterfaceController : WKInterfaceController
	{
		protected InterfaceController (IntPtr handle) : base (handle)
		{
			// Note: this .ctor should not contain any initialization logic.
		}

		public override void Awake (NSObject context)
		{
			base.Awake (context);

			WCSessionManager.SharedManager.ApplicationContextUpdated += SharedManager_ApplicationContextUpdated;

			// Configure interface objects here.
			Console.WriteLine ("{0} awake with context", this);

			lblStart.SetText (string.Format ($"From: {Util.start.Lat},{Util.start.Lon}"));
			lblDestination.SetText (string.Format ($"To: {Util.destination.Lat},{Util.destination.Lon}"));
		}

		async void SharedManager_ApplicationContextUpdated (WatchConnectivity.WCSession session, System.Collections.Generic.Dictionary<string, object> applicationContext)
		{
			Console.WriteLine ("SharedManager_ApplicationContextUpdated...");
			var message = (string)applicationContext ["MessagePhone"];

			if (message != null) {
				//do somethign with message

				Console.WriteLine ("SharedManager_ApplicationContextUpdated: " + message);

				var coordinates = message.Split (",".ToCharArray ());
				Util.destination = new Model.Location () { Lat = coordinates [0], Lon = coordinates [1] };

				InvokeOnMainThread (() => {
					lblDestination.SetText (string.Format ("To: {0},{1}", Util.destination.Lat, Util.destination.Lon));
				});

				var json = await Util.TimeEstimates (Util.start);

				InvokeOnMainThread (() => {
					PushController ("EstimatesController", json);
				});
			}
		}

		public override void WillActivate ()
		{
			// This method is called when the watch view controller is about to be visible to the user.
			Console.WriteLine ("{0} will activate", this);
		}

		public override void DidDeactivate ()
		{
			// This method is called when the watch view controller is no longer visible to the user.
			Console.WriteLine ("{0} did deactivate", this);
			WCSessionManager.SharedManager.ApplicationContextUpdated -= SharedManager_ApplicationContextUpdated;
		}

		partial void OnGetTimeEstimates ()
		{
			PresentTextInputController (new [] { "South Beach", "Hard Rock Stadium" }, WKTextInputMode.Plain, async delegate (NSArray results) {

				if (results != null) {

					var selected = results.GetItem<NSString> (0);

					if (selected == "South Beach")
						Util.destination = new Model.Location () { Lat = "25.764441", Lon = "-80.130716" };
					else if (selected == "Hard Rock Stadium")
						Util.destination = new Model.Location () { Lat = "25.957801", Lon = "-80.238733" };

					lblDestination.SetText (string.Format ($"To: {Util.destination.Lat},{Util.destination.Lon}"));

					var json = await Util.TimeEstimates (Util.start);

					PushController ("EstimatesController", json);
				}
			});
		}
	}
}
