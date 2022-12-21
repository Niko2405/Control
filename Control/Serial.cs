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
		public static void SendData(string data)
		{
			SerialPort serialPort = new SerialPort(Server.COM_Port, Server.COM_Baud, Parity.None, 8, StopBits.One);
			try
			{
				Log.Information("Send data (" + data + ") to COM: " + Server.COM_Port);
				serialPort.Open();
				serialPort.WriteLine(data);
			}
			catch (Exception ex)
			{
				Log.Error(ex.ToString());
				Thread.Sleep(7500);
			}
			serialPort.Close();
		}

		public static string ReadData()
		{
			string data;
			SerialPort serialPort = new SerialPort(Server.COM_Port, Server.COM_Baud, Parity.None, 8, StopBits.One);
			try
			{
				Log.Information("Read data from COM: " + Server.COM_Port);
				serialPort.Open();
				serialPort.ReadTimeout = 5000;
				data = serialPort.ReadLine();
				serialPort.Close();
				return data.Trim();
			}
			catch (Exception ex)
			{
				Log.Error(ex.ToString());
				Thread.Sleep(7500);
				return "ERR";
			}
		}
	}
}
