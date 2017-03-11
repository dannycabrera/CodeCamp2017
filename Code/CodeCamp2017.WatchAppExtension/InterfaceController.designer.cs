// WARNING
//
// This file has been generated automatically by Xamarin Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;

namespace CodeCamp2017.WatchAppExtension
{
    [Register ("InterfaceController")]
    partial class InterfaceController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        WatchKit.WKInterfaceButton btnGetTimeEstimates { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        WatchKit.WKInterfaceLabel lblDestination { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        WatchKit.WKInterfaceLabel lblStart { get; set; }

        [Action ("OnGetTimeEstimates")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void OnGetTimeEstimates ();

        void ReleaseDesignerOutlets ()
        {
            if (btnGetTimeEstimates != null) {
                btnGetTimeEstimates.Dispose ();
                btnGetTimeEstimates = null;
            }

            if (lblDestination != null) {
                lblDestination.Dispose ();
                lblDestination = null;
            }

            if (lblStart != null) {
                lblStart.Dispose ();
                lblStart = null;
            }
        }
    }
}