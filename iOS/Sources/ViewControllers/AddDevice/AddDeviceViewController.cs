using System;
using Foundation;
using Isarithm.Common.Client.Appliance;
using Isarithm.Mobile.iOS.Sources.ViewControllers.AddActivities;
using UIKit;

namespace Isarithm.Mobile.iOS.Sources.ViewControllers.AddDevice
{
    public partial class AddDeviceViewController : UIViewController
    {
        private readonly Guid _modelId = Guid.Parse("09f6df9b-8caa-490d-ae94-a8f41e01cb9e");

        public AddDeviceViewController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            var modelResponse = ApplianceService.Current.GetModelAsync(_modelId).Result;
            if (modelResponse == null)
            {
                return;
            }

            ModelTextField.Text = modelResponse.Name;
            NameTextField.Text = "Isarithm";
        }

        public override void PrepareForSegue(UIStoryboardSegue segue, NSObject sender)
        {
            base.PrepareForSegue(segue, sender);

            if (segue.DestinationViewController is AddActivitiesViewController resultViewController)
            {
                resultViewController.ModelId = _modelId;
                resultViewController.Name = NameTextField.Text;
            }
        }
    }
}