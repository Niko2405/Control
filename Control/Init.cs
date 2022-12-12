using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Serilog;
using Serilog.Sinks.SystemConsole.Themes;
using NLua;

namespace GLaDOS
{
	internal class Init
	{
		/// <summary>
		/// Create Filesystem
		/// </summary>
		public static void CreateFilesystem()
		{
			Utils.CreateDirectory(ProgramData.DIR_ROOT);
			Utils.CreateDirectory(ProgramData.DIR_VOICES);
		}

		/// <summary>
		/// Setup System Logger
		/// </summary>
		public static void SetupLogger()
		{
			// log directory
			if (!System.IO.Directory.Exists(ProgramData.DIR_LOGS))
			{
				System.IO.Directory.CreateDirectory(ProgramData.DIR_LOGS);
			}
			Log.Logger = new LoggerConfiguration().WriteTo.Console(theme: AnsiConsoleTheme.Code).WriteTo.File(ProgramData.DIR_LOGS + "log.txt", rollOnFileSizeLimit: true, rollingInterval: RollingInterval.Day, shared: true).CreateLogger();
			Log.Information("Hello from Logger");
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
	}
}
