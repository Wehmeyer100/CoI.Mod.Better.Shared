﻿using Mafi;
using UnityEngine;

namespace CoI.Mod.Better.Shared
{
	public class BetterShared
	{
		public static void PrintInit()
		{
			if (!Constants.IsCompatibility)
			{
				Debug.LogWarning("###############################################################");
				Debug.LogWarning("####################### WARNING ###############################");
				Debug.LogWarning("###############################################################");
				Debug.LogWarning(ModInfo.Name + " (" + Constants.SharedVersion + ": " + ModInfo.Version + ") >> This mod is not compatible with the current game version and can cause problems!!!");
				Debug.LogWarning(ModInfo.Name + " (" + Constants.SharedVersion + ": " + ModInfo.Version + ") >> CurrentGameVersion: " + Constants.CurrentGameVersion.ToString());
				Debug.LogWarning(ModInfo.Name + " (" + Constants.SharedVersion + ": " + ModInfo.Version + ") >> TargetSharedGameVersion: " + Constants.TargetSharedGameVersion.ToString());
				Debug.LogWarning(ModInfo.Name + " (" + Constants.SharedVersion + ": " + ModInfo.Version + ") >> TargetVersion: " + ModInfo.TargetVersion.ToString());
				if (!ModInfo.GithubUrl.IsEmpty())
					Debug.LogWarning(ModInfo.Name + " (" + Constants.SharedVersion + ": " + ModInfo.Version + ") >> Check for updates: " + ModInfo.GithubUrl);
				Debug.LogWarning("###############################################################");
			}

			Debug.Log(ModInfo.Name + " (" + Constants.SharedVersion + ": " + ModInfo.Version + ") >> Directories ..");
			Debug.Log(" - MOD_ROOT_DIR_PATH: " + Constants.ModRootDirPath);
			Debug.Log(" - MOD_DIR_PATH: " + Constants.ModDirPath);
		}
	}
}