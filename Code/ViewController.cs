using System;

using UIKit;

namespace CodeCamp2017
{
	public partial class ViewController : UIViewController
	{
		protected ViewController (IntPtr handle) : base (handle)
		{
			// Note: this .ctor should not contain any initialization logic.
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			// Perform any additional setup after loading the view, typically from a nib.

			WCSessionManager.SharedManager.ApplicationContextUpdated += SharedManager_ApplicationContextUpdated;

			btnSendToWatch.TouchUpInside += delegate {

				WCSessionManager.SharedManager.UpdateApplicationContext (new System.Collections.Generic.Dictionary<string, object> () { { "MessagePhone", txtCoordinates.Text } });

			};
		}

		public override void ViewDidUnload ()
		{
			base.ViewDidUnload ();

			WCSessionManager.SharedManager.ApplicationContextUpdated -= SharedManager_ApplicationContextUpdated;
		}

		// Receiving data from Watch
		void SharedManager_ApplicationContextUpdated (WatchConnectivity.WCSession session, System.Collections.Generic.Dictionary<string, object> applicationContext)
		{
			var message = (string)applicationContext ["MessageWatch"];

			if (message != null) {
				Console.WriteLine ($"Application context update received: {message}");
				InvokeOnMainThread (() => {
					//Update UI
				});
			}
		}
	}
}
