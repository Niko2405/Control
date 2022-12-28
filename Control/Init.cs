using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Serilog;
using Serilog.Sinks.SystemConsole.Themes;
using NLua;

namespace Control
{
	internal class Init
	{
		/// <summary>
		/// Create Filesystem
		/// </summary>
		public static void CreateFilesystem()
		{
			if (Server.enabled)
			{
				Utils.CreateDirectory(Server.DIR_MAIN);
				Utils.CreateDirectory(Server.DIR_CONFIGS);
				Utils.CreateDirectory(Server.DIR_LOGS);
				Utils.CreateDirectory(Server.DIR_CACHE);
				Utils.CreateDirectory(Server.DIR_USER);
				Utils.CreateDirectory(Server.DIR_VOICE);
				Utils.CreateDirectory(Server.DIR_SCRIPTS);
			}
		}

		/// <summary>
		/// Setup System Logger
		/// </summary>
		public static void SetupLogger()
		{
			if (Server.enabled)
			{
				Log.Logger = new LoggerConfiguration().WriteTo.Console(theme: AnsiConsoleTheme.Code).WriteTo.File(Server.DIR_LOGS + "log.txt", rollOnFileSizeLimit: true, rollingInterval: RollingInterval.Day, shared: true).CreateLogger();
				Log.Information("Hello from Logger");
			}
			else if (Client.enabled)
			{
				//Log.Logger = new LoggerConfiguration().WriteTo.Console(theme: AnsiConsoleTheme.Code).WriteTo.File(Client.DIR_LOGS + "log.txt", rollOnFileSizeLimit: true, rollingInterval: RollingInterval.Day, shared: true).CreateLogger();
				Log.Information("Hello from Logger");
			}
		}

		/// <summary>
		/// Test Native Lua
		/// </summary>
		public static void TestLua()
		{
			Lua lua = new Lua();
			double x;

			Log.Information("Lua initialized");
			Thread.Sleep(1500);
			for (int i = 0; i < 64; i++)
			{
				x = (double)lua.DoString($"return 2 ^ {i}")[0];
				Log.Information($"Value = {x}");
			}
			Thread.Sleep(2000);
			lua.DoString("print('Hello from Lua')");
			Thread.Sleep(2000);
			Log.Information("Lua test OK");
		}

		public static void ShowInformation()
		{
			Console.WriteLine("VERSION:\t0.02");
			Console.WriteLine("Entwickler:\tNiko2405");
		}
	}
}
