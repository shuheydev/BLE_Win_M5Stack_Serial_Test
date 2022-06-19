using System.IO.Ports;

const string comPort = "COM4"; // ポート番号は自分で確認してください
const int baudRate = 115200;

var serial = new SerialPort(comPort, baudRate);
serial.Open();
while (true)
{
    string message = serial.ReadLine();
    Console.WriteLine(message); // Hello World
}
