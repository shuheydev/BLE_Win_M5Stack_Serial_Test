using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Devices.SerialCommunication;
using Windows.Storage.Streams;
using Windows.UI.Xaml.Media.Animation;

namespace UWP_Bluetooth_Serial_Test
{
    public class SerialCommunication
    {
        string _portName;
        string _aqs;
        SerialDevice _device;

        DataReader _dataReader;
        DataWriter _dataWriter;

        public SerialCommunication()
        {
            _portName = "COM3";
            _aqs = SerialDevice.GetDeviceSelector(_portName);
        }

        public async Task Connect()
        {
            //COMポート名を使ってデバイス候補を検索
            var myDevices = await Windows.Devices.Enumeration.DeviceInformation.FindAllAsync(_aqs, null);

            if (myDevices.Count == 0)
            {
                return;
            }

            _device = await SerialDevice.FromIdAsync(myDevices[0].Id);
            _device.BaudRate = 115200;
            _device.DataBits = 8;
            _device.StopBits = SerialStopBitCount.One;
            _device.Parity = SerialParity.None;
            _device.Handshake = SerialHandshake.None;
            _device.ReadTimeout = TimeSpan.FromMilliseconds(1000);
            _device.WriteTimeout = TimeSpan.FromMilliseconds(1000);

            _dataReader = new DataReader(_device.InputStream);
            _dataWriter = new DataWriter(_device.OutputStream);
        }

        public async void Write()
        {
            _dataWriter.WriteString("Hello from M5Stack");
            await _dataWriter.StoreAsync();
        }


        public async Task<string> Read()
        {
            await _dataReader.LoadAsync(128);
            uint bytesToRead = _dataReader.UnconsumedBufferLength;
            string receivedStrings = _dataReader.ReadString(bytesToRead);
            if (string.IsNullOrEmpty(receivedStrings))
            {
                return string.Empty;
            }

            return receivedStrings;
        }
    }
}
