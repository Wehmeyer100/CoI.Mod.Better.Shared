# CoI.Mod.Better.Shared - Captain of Industry - Modder tools

Game Version(Comptability): 0.4.12C


#Set your mod data here:

	public #Your-Constructer#()
	{
		ModInfo.Name = ModName;
		ModInfo.Directory = ModName;
		ModInfo.Version = "0.2.0";
		ModInfo.TargetVersion = Constants.TargetSharedGameVersion;
		ModInfo.GithubUrl = "https://github.com/Wehmeyer100/CoI.Mod.Better/releases";
	}
    
#Example of generate a research:

	ResearchNodeProto researchT1 = GenerateResearchEdict(registrator, MyIDs.Research.GenerellEdictsResearchT1, Name +" I", BetterMod.Config.GenerellEdicts.ResearchCostT1, new ResearchNodeUIData(masterResearch, false, Constants.UIStepSize, Constants.UIStepSize * 2));
	ResearchNodeProto researchT2 = GenerateResearchEdict(registrator, MyIDs.Research.GenerellEdictsResearchT2, Name +" II", BetterMod.Config.GenerellEdicts.ResearchCostT2, researchT1, false);
      
#ResearchNodeUIData
new ResearchNodeUIData(masterResearch,                                                 false, Constants.UIStepSize, Constants.UIStepSize * 2)
		       research parent, true for only grid|false for gird and befor research,         Spacing left,           Spacing bottem
                       
                       
For more infos, see you soon!
