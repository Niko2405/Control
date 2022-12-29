namespace Control
{
	internal class Program
	{
		private static void Start()
		{
			Init.CreateFilesystem();
			Init.SetupLogger();
			Init.TestLua();
			Init.ShowInformation();
			Thread.Sleep(5000);
			Control.RunTerminal();
		}
		static void Main(string[] args)
		{
			// set console color
			Console.ForegroundColor = ConsoleColor.White;
			Console.BackgroundColor = ConsoleColor.Black;

			Start();
		}
	}
}