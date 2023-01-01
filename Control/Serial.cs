using Serilog;
using System.IO.Ports;

namespace Control
{
	internal class Serial
	{
		/// <summary>
		/// Send command to master module (arduino etc.) recv. message from module
		/// </summary>
		/// <param name="command"></param>
		/// <returns>Feedback</returns>
		public static string SendCommand(string command)
		{
			string send = command;
			string recv = "NONE";

			SerialPort serialPort = new SerialPort(Control.COM_Port, Control.COM_Baud, Parity.None, 8, StopBits.One);
			serialPort.WriteTimeout = 250;
			serialPort.ReadTimeout = 250;

			try
			{
				serialPort.Open();

				// write data without \n and \r
				serialPort.Write(send);

				// read data and remove \n and \r
				recv = serialPort.ReadLine().Replace("\n", "").Replace("\r", "");
			}
			catch (IOException)
			{
				Log.Error("Zeitüberschreitung am " + Control.COM_Port);
				Thread.Sleep(5000);
			}
			// close serial port
			if (serialPort.IsOpen)
			{
				serialPort.Close();
			}
			return recv;
		}
	}
}
