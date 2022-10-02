namespace CoI.Mod.Better.Shared
{
	public class ModInfo
	{
		public static string Version
		{
			get => _version;
			set => _version = value;
		}
		private static string _version = "(#Not set!#)";

		public static string Name
		{
			get => _name;
			set => _name = value;
		}
		private static string _name = "(CoI.Mod.Better.Shared)";

		public static string Directory
		{
			get => _directory;
			set => _directory = value;
		}
		private static string _directory = "(CoI.Mod.Better.Shared)";

		public static GameVersion TargetVersion
		{
			get => _targetVersion;
			set => _targetVersion = value;
		}
		private static GameVersion _targetVersion = new GameVersion("Early Access", "0", "4", "12", "e");
		

		public static string GithubUrl
		{
			get => _githubUrl;
			set => _githubUrl = value;
		}
		private static string _githubUrl = "";
	}
}