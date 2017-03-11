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
    [Register ("RowController")]
    partial class RowController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        public WatchKit.WKInterfaceLabel myRowLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        WatchKit.WKInterfaceGroup rowGroup { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (myRowLabel != null) {
                myRowLabel.Dispose ();
                myRowLabel = null;
            }

            if (rowGroup != null) {
                rowGroup.Dispose ();
                rowGroup = null;
            }
        }
    }
}