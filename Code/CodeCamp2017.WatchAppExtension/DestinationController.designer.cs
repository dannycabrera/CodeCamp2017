// WARNING
//
// This file has been generated automatically by Xamarin Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using WatchKit;

namespace CodeCamp2017.WatchAppExtension
{
    [Register ("DestinationController")]
    partial class DestinationController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        WatchKit.WKInterfaceLabel lblMiles { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        WatchKit.WKInterfaceLabel lblTime { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        WatchKit.WKInterfaceLabel lblTypeCost { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (lblMiles != null) {
                lblMiles.Dispose ();
                lblMiles = null;
            }

            if (lblTime != null) {
                lblTime.Dispose ();
                lblTime = null;
            }

            if (lblTypeCost != null) {
                lblTypeCost.Dispose ();
                lblTypeCost = null;
            }
        }
    }
}