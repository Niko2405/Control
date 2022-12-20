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
		public const string DIR_X = null;

		public static bool enabled = false;
	}
}
