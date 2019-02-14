using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using CoreBluetooth;
using Foundation;

namespace Isarithm.Mobile.iOS.Sources.Services
{
    public class BluetoothService : IDisposable
    {
        private const int ConnectionTimeout = 10000;
        private readonly CBCentralManager _manager = new CBCentralManager();

        public EventHandler<CBPeripheral> DiscoveredDevice;
        public EventHandler<CBCentralManagerState> StateChanged;

        public BluetoothService()
        {
            _manager.DiscoveredPeripheral += DiscoveredPeripheral;
            _manager.UpdatedState += UpdatedState;
        }

        public void Dispose()
        {
            _manager.DiscoveredPeripheral -= DiscoveredPeripheral;
            _manager.UpdatedState -= UpdatedState;
            StopScan();
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
            _manager.StopScan();
            Debug.WriteLine("Scanning stopped");
        }

        public async Task ConnectTo(CBPeripheral peripheral)
        {
            var taskCompletion = new TaskCompletionSource<bool>();
            var task = taskCompletion.Task;
            EventHandler<CBPeripheralEventArgs> connectedHandler = (s, e) =>
            {
                if (e.Peripheral.Identifier?.ToString() == peripheral.Identifier?.ToString())
                {
                    taskCompletion.SetResult(true);
                }
            };

            try
            {
                _manager.ConnectedPeripheral += connectedHandler;
                _manager.ConnectPeripheral(peripheral);
                await WaitForTaskWithTimeout(task, ConnectionTimeout);
                Debug.WriteLine($"Bluetooth device connected = {peripheral.Name}");
            }
            finally
            {
                _manager.ConnectedPeripheral -= connectedHandler;
            }
        }

        public void Disconnect(CBPeripheral peripheral)
        {
            _manager.CancelPeripheralConnection(peripheral);
            Debug.WriteLine($"Device {peripheral.Name} disconnected");
        }

        public CBPeripheral[] GetConnectedDevices(string serviceUuid)
        {
            return _manager.RetrieveConnectedPeripherals(new[] {CBUUID.FromString(serviceUuid)});
        }

        public async Task<CBService> GetService(CBPeripheral peripheral, string serviceUuid)
        {
            var service = GetServiceIfDiscovered(peripheral, serviceUuid);
            if (service != null)
            {
                return service;
            }

            var taskCompletion = new TaskCompletionSource<bool>();
            var task = taskCompletion.Task;
            EventHandler<NSErrorEventArgs> handler = (s, e) =>
            {
                if (GetServiceIfDiscovered(peripheral, serviceUuid) != null)
                {
                    taskCompletion.SetResult(true);
                }
            };

            try
            {
                peripheral.DiscoveredService += handler;
                peripheral.DiscoverServices(new[] {CBUUID.FromString(serviceUuid)});
                await WaitForTaskWithTimeout(task, ConnectionTimeout);
                return GetServiceIfDiscovered(peripheral, serviceUuid);
            }
            finally
            {
                peripheral.DiscoveredService -= handler;
            }
        }

        public static CBService GetServiceIfDiscovered(CBPeripheral peripheral, string serviceUuid)
        {
            serviceUuid = serviceUuid.ToLowerInvariant();
            return peripheral.Services
                ?.FirstOrDefault(x => x.UUID?.Uuid?.ToLowerInvariant() == serviceUuid);
        }

        public async Task<CBCharacteristic[]> GetCharacteristics(CBPeripheral peripheral, CBService service,
            int scanTime)
        {
            peripheral.DiscoverCharacteristics(service);
            await Task.Delay(scanTime);
            return service.Characteristics;
        }

        public async Task<NSData> ReadValue(CBPeripheral peripheral, CBCharacteristic characteristic)
        {
            var taskCompletion = new TaskCompletionSource<bool>();
            var task = taskCompletion.Task;
            EventHandler<CBCharacteristicEventArgs> handler = (s, e) =>
            {
                if (e.Characteristic.UUID?.Uuid == characteristic.UUID?.Uuid)
                {
                    taskCompletion.SetResult(true);
                }
            };

            try
            {
                peripheral.UpdatedCharacterteristicValue += handler;
                peripheral.ReadValue(characteristic);
                await WaitForTaskWithTimeout(task, ConnectionTimeout);
                return characteristic.Value;
            }
            finally
            {
                peripheral.UpdatedCharacterteristicValue -= handler;
            }
        }

        public async Task<NSError> WriteValue(CBPeripheral peripheral, CBCharacteristic characteristic, NSData value)
        {
            var taskCompletion = new TaskCompletionSource<NSError>();
            var task = taskCompletion.Task;
            EventHandler<CBCharacteristicEventArgs> handler = (s, e) =>
            {
                if (e.Characteristic.UUID?.Uuid == characteristic.UUID?.Uuid)
                {
                    taskCompletion.SetResult(e.Error);
                }
            };

            try
            {
                peripheral.WroteCharacteristicValue += handler;
                peripheral.WriteValue(value, characteristic, CBCharacteristicWriteType.WithResponse);
                await WaitForTaskWithTimeout(task, ConnectionTimeout);
                return task.Result;
            }
            finally
            {
                peripheral.WroteCharacteristicValue -= handler;
            }
        }

        private void DiscoveredPeripheral(object sender, CBDiscoveredPeripheralEventArgs args)
        {
            var device = $"{args.Peripheral.Name} - {args.Peripheral.Identifier?.Description}";
            Debug.WriteLine($"Discovered {device}");
            DiscoveredDevice?.Invoke(sender, args.Peripheral);
        }

        private void UpdatedState(object sender, EventArgs args)
        {
            Debug.WriteLine($"State = {_manager.State}");
            StateChanged?.Invoke(sender, _manager.State);
        }

        private static async Task WaitForTaskWithTimeout(Task task, int timeout)
        {
            await Task.WhenAny(task, Task.Delay(ConnectionTimeout));
            if (!task.IsCompleted)
            {
                throw new TimeoutException();
            }
        }
    }
}