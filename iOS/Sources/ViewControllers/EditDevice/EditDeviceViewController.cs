using System;
using Isarithm.Common.Client.Account;
using Isarithm.Common.Client.Account.Model;
using Isarithm.Common.Client.Appliance;
using Plugin.Settings;
using UIKit;

namespace Isarithm.Mobile.iOS.Sources.ViewControllers.EditDevice
{
    public partial class EditDeviceViewController : UIViewController
    {
        public int DeviceId;

        private DeviceResponse _device;

        public EditDeviceViewController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            var deviceResponse = AccountService.Current.GetDeviceAsync(DeviceId).Result;
            if (deviceResponse == null)
                return;

            var modelResponse = ApplianceService.Current.GetModelAsync(deviceResponse.ModelId).Result;
            if (modelResponse == null)
                return;

            _device = deviceResponse;

            DeviceModelTextField.Text = modelResponse.Name;
            DeviceNameTextField.Text = deviceResponse.Name;
        }

        partial void SaveBarButtonItem_Activated(UIBarButtonItem sender)
        {
            if (!UpdateDevice())
            {
                var okAlertController = UIAlertController.Create("Error", "Can not perform saving your changes",
                    UIAlertControllerStyle.Alert);
                okAlertController.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Default, null));
                PresentViewController(okAlertController, true, null);
                return;
            }

            var board = UIStoryboard.FromName("Main", null);
            var ctrl = board.InstantiateViewController("DeviceViewController");
            ctrl.ModalTransitionStyle = UIModalTransitionStyle.CrossDissolve;
            PresentViewController(ctrl, true, null);
        }

        private bool UpdateDevice()
        {
            var newDeviceName = DeviceNameTextField.Text;
            if (newDeviceName == _device.Name)
                return true;

            var userId = CrossSettings.Current.GetValueOrDefault("LoggedInUser_id", Guid.Empty);
            if (userId == Guid.Empty)
                return false;

            var deviceRequest = new DeviceRequest
            {
                Name = newDeviceName
            };
            var res = AccountService.Current.UpdateDeviceOfUserAsync(userId, DeviceId, deviceRequest).Result;

            if (res == null)
                return false;

            return true;
        }
    }
}