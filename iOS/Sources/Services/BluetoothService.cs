using System;
using System.Diagnostics;
using System.Threading.Tasks;
using CoreBluetooth;

namespace Isarithm.Mobile.iOS.Sources.Services
{
	public class BluetoothService : IDisposable
	{
		private readonly CBCentralManager _manager = new CBCentralManager();

		public EventHandler DiscoveredDevice;
		public EventHandler StateChanged;

		public BluetoothService()
		{
			_manager.DiscoveredPeripheral += DiscoveredPeripheral;
			_manager.UpdatedState += UpdatedState;
		}

		public void Dispose()
		{
			_manager.DiscoveredPeripheral -= DiscoveredPeripheral;
			_manager.UpdatedState -= UpdatedState;
		}

		public async Task Scan(int scanDuration, string serviceUuid = "")
		{
			Debug.WriteLine("Scanning started");
			var uuids = string.IsNullOrEmpty(serviceUuid)
				? new CBUUID[0]
				: new[] {CBUUID.FromString(serviceUuid)};
			_manager.ScanForPeripherals(uuids);

			await Task.Delay(scanDuration);
			StopScan();
		}

		public void StopScan()
		{
			this._manager.StopScan();
			Debug.WriteLine("Scanning stopped");
		}

		private void DiscoveredPeripheral(object sender, CBDiscoveredPeripheralEventArgs args)
		{
			var device = $"{args.Peripheral.Name} - {args.Peripheral.Identifier?.Description}";
			Debug.WriteLine($"Discovered {device}");
			DiscoveredDevice?.Invoke(sender, args);
		}

		private void UpdatedState(object sender, EventArgs args)
		{
			Debug.WriteLine($"State = {_manager.State}");
			StateChanged?.Invoke(sender, null);
		}
	}
}