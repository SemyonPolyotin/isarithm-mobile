using System;
using Foundation;
using Isarithm.Common.Client.Account;
using Isarithm.Common.Client.Appliance;
using Isarithm.Common.Repository;
using Isarithm.Mobile.iOS.Sources.Utils;
using Isarithm.Mobile.iOS.Sources.ViewControllers.EditDevice;
using Plugin.BluetoothLE;
using UIKit;

namespace Isarithm.Mobile.iOS.Sources.ViewControllers.Device
{
    public partial class DeviceViewController : UIViewController
    {
        public int DeviceId;

        public DeviceViewController(IntPtr handle) : base(handle)
        {
        }

        [Action("UnwindToDeviceViewController:")]
        public void UnwindToDeviceViewController(UIStoryboardSegue segue)
        {
        }

        private IDisposable _scanner;

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            var deviceResponse = AccountService.Current.GetDeviceAsync(DeviceId).Result;
            if (deviceResponse == null)
            {
                // TODO: Display error
                return;
            }

            var modelResponse = ApplianceService.Current.GetModelAsync(deviceResponse.ModelId).Result;
            DeviceNameLabel.Text = deviceResponse.Name;
            if (modelResponse == null)
                return;
            DeviceModelLabel.Text = modelResponse.Name;
            DeviceModelImageView.Image = HttpUtil.LoadImage(modelResponse.Image).Result;
        }

        /// <summary>Синхронизация активностей с устройством</summary>
        protected void SynchronizeActivities(Guid deviceId)
        {
            // Включение адаптера 
            if (CrossBleAdapter.Current.CanControlAdapterState())
                CrossBleAdapter.Current.SetAdapterState(true);

            CrossBleAdapter.Current.WhenStatusChanged().Subscribe(status =>
            {
                if (status == AdapterStatus.PoweredOn)
                {
                    _scanner = CrossBleAdapter.Current.Scan().Subscribe(scanResult =>
                    {
                        var foundDevice = scanResult.Device;
                        if (foundDevice.Uuid == deviceId)
                        {
                            foundDevice.Connect();
                            // TODO: stop scanning
                            UploadActivity();
                        }
                    });
                }
            });
        }

        /// <summary>Загрузка активности на устройство</summary>
        /// <returns>Результат операции</returns>
        protected bool UploadActivity()
        {
            const int activityId = 0;
            var activity = ActivityRepository.GetActivity(activityId);

            // Включение 
            if (CrossBleAdapter.Current.CanControlAdapterState())
                CrossBleAdapter.Current.SetAdapterState(true);
            return true;
        }

        public override void PrepareForSegue(UIStoryboardSegue segue, NSObject sender)
        {
            if (segue.Identifier == "EditDeviceSegue")
            {
                if (segue.DestinationViewController is EditDeviceViewController resultViewController)
                    resultViewController.DeviceId = DeviceId;
            }
        }
    }
}