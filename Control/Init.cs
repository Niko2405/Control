using NLua;
using Serilog;
using Serilog.Sinks.SystemConsole.Themes;

namespace Control
{
	internal class Init
	{
		/// <summary>
		/// Create Filesystem
		/// </summary>
		public static void CreateFilesystem()
		{
			Utils.CreateDirectory(Control.DIR_MAIN);
			Utils.CreateDirectory(Control.DIR_CONFIGS);
			Utils.CreateDirectory(Control.DIR_LOGS);
			Utils.CreateDirectory(Control.DIR_CACHE);
			Utils.CreateDirectory(Control.DIR_USER);
			Utils.CreateDirectory(Control.DIR_VOICE);
			Utils.CreateDirectory(Control.DIR_SCRIPTS);
		}

		/// <summary>
		/// Setup System Logger
		/// </summary>
		public static void SetupLogger()
		{
			Log.Logger = new LoggerConfiguration().WriteTo.Console(theme: AnsiConsoleTheme.Code).WriteTo.File(Control.DIR_LOGS + "log.txt", rollOnFileSizeLimit: true, rollingInterval: RollingInterval.Day, shared: true).CreateLogger();
			Log.Information("Logger created");

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
			lua.DoString("print('Lua is ready')");
			Thread.Sleep(2000);
			Log.Information("Lua test OK");
		}

		public static void ShowInformation()
		{
			Console.WriteLine("VERSION:\t0.03");
			Console.WriteLine("Entwickler:\tNiko2405");
		}
	}
}
