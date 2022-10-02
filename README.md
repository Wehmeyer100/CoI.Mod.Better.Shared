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
	
new ResearchNodeUIData(masterResearch: 1,                                                 false : 2, Constants.UIStepSize : 3, Constants.UIStepSize * 2 : 4)

- 1: research parent
- 2: true for only grid | false for gird and befor research
- 3: Spacing left
- 4: Spacing bottem
                       
                       
For more infos, see you soon!
