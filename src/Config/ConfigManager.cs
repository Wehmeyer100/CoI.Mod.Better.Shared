using CoI.Mod.Better.Shared.Config;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace CoI.Mod.Better.Shared.Config
{
	public class ConfigManager
	{
		private static readonly JsonSerializerSettings JsonSerializerSettings = new JsonSerializerSettings()
		{
			Formatting = Formatting.Indented,
			MaxDepth = 500,
			MissingMemberHandling = MissingMemberHandling.Ignore,
			NullValueHandling = NullValueHandling.Ignore,
			ReferenceLoopHandling = ReferenceLoopHandling.Serialize
		};

		public static T LoadOrDefault<T>(string filePath, bool printAfter = false) where T : ConfigBase, new()
		{
			string configFile = GetFilePath(ModInfo.Directory, filePath);
			T result = new T();
			if (File.Exists(configFile))
			{
				string content = File.ReadAllText(configFile, Encoding.UTF8);
				try
				{
					result = JsonConvert.DeserializeObject<T>(content, JsonSerializerSettings);
				}
				catch (Exception)
				{
					result = new T();
				}
			}

			if (printAfter)
				result?.Print(result);

			return result;
		}

		public static T LoadOrCreate<T>(string filePath, bool printAfter = false) where T : ConfigBase, new()
		{
			string configFile = GetFilePath(ModInfo.Directory, filePath);
			T result = new T();
			if (File.Exists(configFile))
			{
				string content = File.ReadAllText(configFile, Encoding.UTF8);
				try
				{
					result = JsonConvert.DeserializeObject<T>(content, JsonSerializerSettings);
				}
				catch (Exception)
				{
					result = new T();
				}
			}

			File.WriteAllText(configFile, JsonConvert.SerializeObject(result, JsonSerializerSettings));

			if (printAfter)
				result?.Print(result);

			return result;
		}

		public static T Save<T>(string filePath, T result, bool printAfter = false) where T : ConfigBase
		{
			string configFile = GetFilePath(ModInfo.Directory, filePath);
			File.WriteAllText(configFile, JsonConvert.SerializeObject(result, JsonSerializerSettings));

			if (printAfter)
				result?.Print(result);

			return result;
		}

		public static string GetFilePath(string modDirectoryName, string filePath)
		{
			return Constants.ModDirPath + "/" + filePath + (!filePath.EndsWith(Constants.JsonExt) ? Constants.JsonExt : "");
		}
		
		
	}
}