using System;
using Foundation;
using Isarithm.Common.Client.Account;
using Isarithm.Common.Client.Appliance;
using Isarithm.Mobile.iOS.Sources.Utils;
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
            if (modelResponse != null)
            {
                DeviceModelLabel.Text = modelResponse.Name;
                DeviceModelImageView.Image = HttpUtil.LoadImage(modelResponse.Image).Result;
            }
        }
    }
}