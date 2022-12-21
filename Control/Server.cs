using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Control
{
	internal class Server
	{
		public const string DIR_MAIN = "data/";
		public const string DIR_LOGS = DIR_MAIN + "logs/";
		public const string DIR_USER = DIR_MAIN + "usr/";
		public const string DIR_CACHE = DIR_MAIN + "cache/";
		public const string DIR_CONFIGS = DIR_MAIN + "configs/";
		public const string DIR_VOICE = DIR_MAIN + "voices/";
		public const string DIR_SCRIPTS = DIR_MAIN + "scripts/";

		public static string COM_Port { get; set; } = "COM4";
		public static int COM_Baud { get; set; } = 9600;
		public static bool enabled = false;

		public static void RunTerminal()
		{
			if (enabled)
			{
				string output = "";
				string? input;
				int x;
				int y;

				while (true)
				{
					// get current terminal size
					x = Utils.GetTerminalSize().Item1;
					y = Utils.GetTerminalSize().Item2;

					// print meesage from system
					Console.Clear();
					Console.SetCursorPosition(0, 0);
					Console.ForegroundColor = ConsoleColor.Red;
					Console.Write("Control");
					Console.ForegroundColor = ConsoleColor.White;
					Console.Write(">" + output);

					// userinput
					Console.SetCursorPosition(0, y - 1);
					Console.ForegroundColor = ConsoleColor.Green;
					Console.Write("User");
					Console.ForegroundColor = ConsoleColor.White;
					Console.Write(">");
					input = Console.ReadLine();

					// if input correct
					if (input != null)
					{
						output = RunCommand(input);
					}
				}
			}
		}
		private static string RunCommand(string command)
		{
			string[] input_list = command.ToLower().Split(" ");

			for (int a = 0; a < input_list.Length; a++)
			{
				if (input_list[a] == "hallo")
				{
					return "Hallo root";
				}
				else if (input_list[a] == "exit")
				{
					System.Environment.Exit(0);
					return null;
				}
				else if (input_list[a] == "start")
				{
					for (int b = 0; b < input_list.Length; b++)
					{
						if (input_list[b] == "test")
						{
							for (int c = 0; c < input_list.Length; c++)
							{
								if (input_list[c] == "audio")
								{
									return "Starte Audio Test";
								}
								else if (input_list[c] == "serial")
								{
									Serial.SendData("TEST");
									if (Serial.ReadData() == "OK")
									{
										return "Serial Test ist OK";
									}
									else
									{
										return "Serial Test nicht in Ordnung";
									}
								}
							}
						}
					}
				}
			}
			return "Eingabe konnte nicht verarbeitet werden";
		}
	}
}
