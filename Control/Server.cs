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

					// print userinput
					Console.SetCursorPosition(0, y - 1);
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
			return command;
		}
	}
}
