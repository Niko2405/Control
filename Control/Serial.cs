using Serilog;
using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

			SerialPort serialPort = new SerialPort(Server.COM_Port, Server.COM_Baud, Parity.None, 8, StopBits.One);
			serialPort.WriteTimeout = 250;
			serialPort.ReadTimeout = 250;

			try
			{
				serialPort.Open();
				serialPort.Write(send);
				recv = serialPort.ReadLine().Replace("\n", "").Replace("\r", "");
			}
			catch (IOException)
			{
				Log.Error("Zeitüberschreitung am " + Server.COM_Port);
				Thread.Sleep(5000);
			}
			if (serialPort.IsOpen)
			{
				serialPort.Close();
			}
			return recv;
		}
	}
}
