using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace UWP_Bluetooth_Serial_Test
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        SerialCommunication _serialCommunication;

        DispatcherTimer _timer;

        public MainPage()
        {
            this.InitializeComponent();
            _serialCommunication = new SerialCommunication();
            _timer = new DispatcherTimer();
            _timer.Interval = TimeSpan.FromMilliseconds(1000);
            _timer.Tick += _timer_Tick;
        }

        private async void _timer_Tick(object sender, object e)
        {
            var receivedMessage = await _serialCommunication.Read();
            textBox.Text = receivedMessage;
        }

        private async void ConnectButton_Click(object sender, RoutedEventArgs e)
        {
            await _serialCommunication.Connect();
            //_timer.Start();
        }

        private void StartReadingButton_Click(object sender, RoutedEventArgs e)
        {
            _timer.Start();
        }
    }
}
