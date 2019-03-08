using System;
using System.Diagnostics;
using Plugin.BluetoothLE;
using UIKit;

namespace Isarithm.Mobile.iOS.Sources.ViewControllers.Connect
{
    public partial class ConnectViewController : UIViewController
    {
        private IDisposable _scanner;

        public ConnectViewController(IntPtr handle) : base(handle)
        {
        }

        partial void ConnectButton_TouchUpInside(UIButton sender)
        {
            if (CrossBleAdapter.Current.CanControlAdapterState())
                CrossBleAdapter.Current.SetAdapterState(true);

            CrossBleAdapter.Current.WhenStatusChanged().Subscribe(status =>
            {
                if (status == AdapterStatus.PoweredOn)
                {
                    _scanner = CrossBleAdapter.Current.Scan().Subscribe(scanResult =>
                    {
                        var foundDevice = scanResult.Device;
                        if (foundDevice.Name == "Isarithm")
                        {
                            Debug.Write("Found Isarithm!");
                            _scanner.Dispose();
                            BendButton.Enabled = true;
                            DefaultButton.Enabled = true;
                            ExpandButton.Enabled = true;
                        }
                    });
                }
            });
        }

        public override void ViewDidUnload()
        {
            _scanner.Dispose();
        }

        partial void BendButton_TouchUpInside(UIButton sender)
        {
            throw new NotImplementedException();
        }

        partial void DefaultButton_TouchUpInside(UIButton sender)
        {
            Debug.Write("1");
            throw new NotImplementedException();
        }

        partial void ExpandButton_TouchUpInside(UIButton sender)
        {
            throw new NotImplementedException();
        }
    }
}