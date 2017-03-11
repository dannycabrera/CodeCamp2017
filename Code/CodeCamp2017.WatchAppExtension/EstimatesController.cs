using Foundation;
using System;
using WatchKit;
using Newtonsoft.Json.Linq;

namespace CodeCamp2017.WatchAppExtension
{
    public partial class EstimatesController : WKInterfaceController
    {
		JArray times = new JArray ();

        public EstimatesController (IntPtr handle) : base (handle)
        {
        }

		public override void Awake (NSObject context)
		{
			base.Awake (context);

			JObject json = JObject.Parse (context.ToString ());
			times = (JArray)json ["times"];
		}

		public override void WillActivate ()
		{
			LoadRows ();
		}

		void LoadRows ()
		{
			myTable.SetNumberOfRows ((nint)times.Count, "default");
			for (var i = 0; i < times.Count; i++) {

				var elementRow = (RowController)myTable.GetRowController (i);

				int totalSeconds = Convert.ToInt32 (times [i] ["estimate"].ToString ());
				int minutes = totalSeconds / 60;

				elementRow.myRowLabel.SetText (times [i] ["display_name"] + " - " + minutes + "m");
			}
		}

		public override void DidSelectRow (WKInterfaceTable table, nint rowIndex)
		{
			var rowData = times [(int)rowIndex];

			PushController ("DestinationController", rowData ["display_name"].ToString ());
		}
    }
}