using System;
using System.Text;
using Plugin.BluetoothLE;
using UIKit;

namespace Isarithm.Mobile.iOS.Sources.ViewControllers.ControlDevice
{
    public partial class ControlDeviceViewController : UIViewController
    {
        private readonly Guid _bleCharServoControl = Guid.Parse("110eedd3-721d-4ad4-9bcd-8006b7fc4bf9");

        private IDisposable _scanner;

        private IDevice _device = null;

        public ControlDeviceViewController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            BendButton.Enabled = false;
            DefaultButton.Enabled = false;
            ExpandButton.Enabled = false;
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
                        if (foundDevice.Name != "Isarithm")
                            return;

                        _device = foundDevice;
                        _device.Connect();
                        BendButton.Enabled = true;
                        DefaultButton.Enabled = true;
                        ExpandButton.Enabled = true;
                        _scanner.Dispose();
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
            SendCommand(sender, "bend");
        }

        partial void DefaultButton_TouchUpInside(UIButton sender)
        {
            SendCommand(sender, "default");
        }

        partial void ExpandButton_TouchUpInside(UIButton sender)
        {
            SendCommand(sender, "expand");
        }

        private void SendCommand(UIButton sender, string command)
        {
            if (!_device.IsConnected())
            {
                BendButton.Enabled = false;
                DefaultButton.Enabled = false;
                ExpandButton.Enabled = false;
                return;
            }

            _device.WhenAnyCharacteristicDiscovered().Subscribe(characteristic =>
            {
                if (characteristic.Uuid == _bleCharServoControl)
                {
                    characteristic.Write(Encoding.UTF8.GetBytes(command));
                }
            });
        }
    }
}