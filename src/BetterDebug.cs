using UnityEngine;

namespace CoI.Mod.Better.Shared
{
	public class BetterDebug
	{
		public static void Warning(string message)
		{
			Debug.LogWarning(ModInfo.Name + " (" + Constants.SharedVersion + ": " + ModInfo.Version + ") >> " + message);
		}

		public static void Info(string message)
		{
			Debug.Log(ModInfo.Name + " (" + Constants.SharedVersion + ": " + ModInfo.Version + ") >> " + message);
		}
	}
}