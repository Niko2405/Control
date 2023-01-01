using System.Net.NetworkInformation;

namespace Control
{
	internal class Control
	{
		public const string DIR_MAIN = "data/";
		public const string DIR_LOGS = DIR_MAIN + "logs/";
		public const string DIR_USER = DIR_MAIN + "usr/";
		public const string DIR_CACHE = DIR_MAIN + "cache/";
		public const string DIR_CONFIGS = DIR_MAIN + "configs/";
		public const string DIR_VOICE = DIR_MAIN + "voices/";
		public const string DIR_SCRIPTS = DIR_MAIN + "scripts/";

		public static string COM_Port { get; set; } = "com1";
		public static int COM_Baud { get; set; } = 9600;

		public static void RunTerminal()
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
									string recv = Serial.SendCommand("TEST");
									if (recv.Equals("OK"))
									{
										return "Serial Test ist OK";
									}
									else if (!recv.Equals("OK"))
									{
										return "Serial Test nicht in Ordnung";
									}
								}
							}
						}
					}
				}
				else if (input_list[a] == "set")
				{
					for (int b = 0; b < input_list.Length; b++)
					{
						if (input_list[b] == "com_port")
						{
							if (input_list.Length >= 3)
							{
								Control.COM_Port = input_list[2];
								return "set variable Server.COM_Port = " + input_list[2];
							}
						}
						else if (input_list[b] == "com_baud")
						{
							if (input_list.Length >= 3)
							{
								try
								{
									Control.COM_Baud = int.Parse(input_list[2]);
									return "set variable Server.COM_Baud = " + input_list[2];
								}
								catch (Exception)
								{
									return "parameter error";
								}
							}
						}
					}
				}
				else if (input_list[a] == "help")
				{
					if (input_list.Length >= 2)
					{
						for (int b = 0; b < input_list.Length; b++)
						{
							if (input_list[b] == "mm" || input_list[b] == "mastermodule")
							{
								return "\thelp for mm or Mastermodule\nmm send\t\tSend command over the given serial port to an arduino or other devices";
                            }
						}
					}
					else if (input_list.Length == 1)
					{
						return "\tglobal help\nstart\t\tStart programs or tests\nset\t\tSet variables";
					}
				}
				// mm = MasterModule
				else if (input_list[a] == "mm" || input_list[a] == "mastermodule")
				{
					for (int b = 0; b < input_list.Length; b++)
					{
						if (input_list[b] == "send")
						{
							if (input_list.Length >= 3)
							{
								// removes "mm" and "send", also two whitespaces
								string MasterModuleCommand = command.Replace("mm", "").Replace("send", "").Remove(0, 2);
								string recv = Serial.SendCommand(MasterModuleCommand);
								return recv;
								//return MasterModuleCommand + " len: (" + MasterModuleCommand.Length + ")";
							}
						}
					}
				}
			}
			return "Eingabe konnte nicht verarbeitet werden";
		}
	}
}
