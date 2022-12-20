namespace Control
{
	internal class Program
	{
		private static void Start()
		{

		}
		static void Main(string[] args)
		{
			for (int i = 0; i < args.Length; i++)
			{
				Console.WriteLine(args[i]);
			}
			// Init
			// Auf Start Argumente warten
			// Programm dazu öffnen (Serial Test, Socket Test...)
		}
	}
}