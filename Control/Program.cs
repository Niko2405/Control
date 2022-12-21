namespace Control
{
	internal class Program
	{
		private static void Start()
		{
			Init.CreateFilesystem();
			Init.SetupLogger();
			Init.TestLua();
			Thread.Sleep(2500);
			Server.RunTerminal();
		}
		static void Main(string[] args)
		{
			for (int i = 0; i < args.Length; i++)
			{
				if (args[i] == "--server")
				{
					Server.enabled = true;
					Client.enabled = false;
				}
				if (args[i] == "--client")
				{
					Client.enabled = true;
					Server.enabled = false;
				}
				Console.ForegroundColor = ConsoleColor.White;
				Console.BackgroundColor = ConsoleColor.Black;
			}
			if (!Server.enabled && !Client.enabled)
			{
				System.Console.WriteLine("No start arguments found");
			}
			Start();
		}
	}
}