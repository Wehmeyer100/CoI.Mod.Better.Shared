using Mafi.Core;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace CoI.Mod.Better.Shared
{
	public class Constants
	{
		public const string SharedVersion = "0.1.0";
		public const bool   IgnoreHotfix  = false;
		public const int    UIStepSize    = 4;
		public const string JsonExt       = ".json";

		public static readonly GameVersion CurrentGameVersion      = new GameVersion();
		public static readonly GameVersion TargetSharedGameVersion = new GameVersion("Early Access", "0", "4", "12", "e");

		public static string ModRootDirPath => new FileSystemHelper().GetDirPath(FileType.Mod, false);
		public static string ModDirPath => Path.Combine(ModRootDirPath, ModInfo.Name);
		public static string LangDirPath    => Path.Combine(ModDirPath, "Lang");

		public static bool IsSharedCompatibility => CurrentGameVersion.Equals(TargetSharedGameVersion, IgnoreHotfix);
		public static bool IsCompatibility => CurrentGameVersion.Equals(ModInfo.TargetVersion, IgnoreHotfix);
	}
}