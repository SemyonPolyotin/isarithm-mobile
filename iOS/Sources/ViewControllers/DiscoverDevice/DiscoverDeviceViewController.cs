using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Acr.Collections;
using Foundation;
using Isarithm.Mobile.iOS.Sources.ViewControllers.AddActivities;
using Plugin.BluetoothLE;
using UIKit;

namespace Isarithm.Mobile.iOS.Sources.ViewControllers.DiscoverDevice
{
    public partial class DiscoverDeviceViewController : UITableViewController
    {
        private List<DiscoveredDevice> _discoveredDevices;

        private IDisposable _status;
        private IDisposable _scanner;

        public DiscoverDeviceViewController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            _discoveredDevices = new List<DiscoveredDevice>();
            DiscoverDeviceTableView.Source = new DiscoverDevicesTvs(_discoveredDevices);

            if (CrossBleAdapter.Current.CanControlAdapterState())
                CrossBleAdapter.Current.SetAdapterState(true);

            _status = CrossBleAdapter.Current.WhenStatusChanged().Subscribe(status =>
            {
                if (status == AdapterStatus.PoweredOn)
                {
                    _scanner = CrossBleAdapter.Current.Scan().Subscribe(scanResult =>
                    {
                        var foundDevice = scanResult.Device;
                        if (_discoveredDevices.Where(p => p.Name == foundDevice.Name).IsEmpty())
                        {
                            _discoveredDevices.Add(new DiscoveredDevice(foundDevice.Name, foundDevice.Uuid.ToString()));
                            DiscoverDeviceTableView.ReloadData();
                            Debug.WriteLine(scanResult.Device.Name);
                        }
                    });
                }
            });
        }

        public override void PrepareForSegue(UIStoryboardSegue segue, NSObject sender)
        {
            base.PrepareForSegue(segue, sender);

            UnloadScanner();
        }

        public override void ViewDidUnload()
        {
            UnloadScanner();
        }

        private void UnloadScanner()
        {
            _status.Dispose();
            _scanner.Dispose();
        }
    }
}