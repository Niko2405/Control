using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GLaDOS
{
	internal class Utils
	{
		public static void CreateFile(string path, string filename)
		{
			if (File.Exists(path + filename))
			{
				return;
			}
			else
			{
				File.Create(path + filename);
				Log.Information(path + filename + " File created");
			}
		}

		public static void DeleteFile(string path, string filename)
		{
			if (!File.Exists(path + filename))
			{
				return;
			}
			else
			{
				File.Delete(path + filename);
				Log.Information(path + filename + " deleted");
			}
		}

		public static void CreateDirectory(string path)
		{
			if (Directory.Exists(path))
			{
				return;
			}
			else
			{
				Directory.CreateDirectory(path);
				Log.Information("Directory " + path + " created");
			}
		}

		public static void DeleteDirectory(string path)
		{
			if (!Directory.Exists(path))
			{
				return;
			}
			else
			{
				Directory.Delete(path);
				Log.Information("Directory " + path + " deleted");
			}
		}

		/// <summary>
		/// Download file from server and saves in destination folder
		/// </summary>
		/// <param name="urlPath"></param>
		/// <param name="destination"></param>
		public static async void DownloadFromURL(string urlPath, string destination)
		{
			Log.Information("Download " + ProgramData.PRIMARY_URL + urlPath, "Web");
			try
			{
				using (HttpClient client = new HttpClient())
				{
					using (HttpResponseMessage response = await client.GetAsync(ProgramData.PRIMARY_URL + urlPath))
					using (Stream streamToReadFrom = await response.Content.ReadAsStreamAsync())
					{
						using (Stream streamToWriteTo = File.Open(destination, FileMode.Create))
						{
							await streamToReadFrom.CopyToAsync(streamToWriteTo);
						}
						response.Content = null;
					}
				}
			}
			catch (Exception)
			{
				Log.Error("Failed to download", "Web");
			}
			Thread.Sleep(1000);
		}

		/// <summary>
		/// get current terminal size (X,Y)
		/// </summary>
		/// <returns>Item1 = X and Item2 = Y</returns>
		public static Tuple<int, int> GetTerminalSize()
		{
			int x = Console.WindowWidth;
			int y = Console.WindowHeight;
			return Tuple.Create(x, y);
		}

		/// <summary>
		/// Get all files from path, optional extension like *.txt
		/// </summary>
		/// <param name="path"></param>
		/// <param name="extension"></param>
		/// <returns>File list</returns>
		public static string[] ListDirectory(string path, string extension = "")
		{
			List<string> fileList = new List<string>();
			try
			{
				DirectoryInfo directoryInfo = new DirectoryInfo(path);
				System.IO.FileInfo[] files = directoryInfo.GetFiles(extension);
				foreach (System.IO.FileInfo file in files)
				{
					fileList.Add(file.Name);
				}
				return fileList.ToArray();
			}
			catch (Exception ex)
			{
				Log.Error(ex.Message, "IO");
				fileList.Add("none");
				return fileList.ToArray();
			}
		}
	}
}